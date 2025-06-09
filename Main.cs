using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsDemo
{
    public partial class Main : Form
    {
        private Simulador simulador;
        private Timer executionTimer;
        private bool isPaused = false;

        private int[] estadoAnteriorRegs = new int[32];
        private Dictionary<long, int> estadoAnteriorMem = new Dictionary<long, int>();

        public Main()
        {
            InitializeComponent();
            SetupExecutionTimer();
            ResetUIState();
        }

        private void SetupExecutionTimer()
        {
            executionTimer = new Timer();
            executionTimer.Interval = 50;
            executionTimer.Tick += ExecutionTimer_Tick;
        }

        #region Inicialização e Reset da UI

        private void ResetUIState()
        {
            if (simulador != null)
            {
                simulador.MemoriaModificada -= Simulador_MemoriaModificada;
            }
            simulador = null;

            lblClockValor.Text = "0";
            lblPCValor.Text = "N/A";
            txtInstrucaoAtual.Text = "";
            lblTempoTotal.Text = "0.000 ns";
            txtMemAddress.Text = "0x10010000";

            InitializeRegistersGrid();
            InitializeMemoryGrid(0x10010000);
            HighlightCurrentLine(-1);
            SetExecutionButtonsEnabled(false);

            Array.Clear(estadoAnteriorRegs, 0, 32);
            estadoAnteriorMem.Clear();
        }

        private void InitializeRegistersGrid()
        {
            gridRegistradores.Rows.Clear();
            if (gridRegistradores.Columns.Count == 0)
            {
                gridRegistradores.Columns.Add("Reg", "Reg.");
                gridRegistradores.Columns.Add("Nome", "Nome");
                gridRegistradores.Columns.Add("Hex", "Valor (Hex)");
                gridRegistradores.Columns.Add("Dec", "Valor (Dec)");
            }

            string[] nomes = {
                "$zero", "$at", "$v0", "$v1", "$a0", "$a1", "$a2", "$a3", "$t0", "$t1", "$t2", "$t3",
                "$t4", "$t5", "$t6", "$t7", "$s0", "$s1", "$s2", "$s3", "$s4", "$s5", "$s6", "$s7",
                "$t8", "$t9", "$k0", "$k1", "$gp", "$sp", "$fp", "$ra"
            };

            for (int i = 0; i < 32; i++)
            {
                gridRegistradores.Rows.Add($"${i}", nomes[i], "0x00000000", "0");
            }
            gridRegistradores.ClearSelection();
        }

        private void InitializeMemoryGrid(long startAddress)
        {
            gridMemoria.Rows.Clear();
            if (gridMemoria.Columns.Count == 0)
            {
                gridMemoria.Columns.Add("Endereco", "Endereço");
                gridMemoria.Columns.Add("Hex", "Valor (Hex)");
                gridMemoria.Columns.Add("Dec", "Valor (Dec)");
            }

            for (int i = 0; i < 128; i++)
            {
                long address = startAddress + i * 4;
                int val = 0;
                if (simulador != null && simulador.GetMemoria().TryGetValue(address, out int memVal))
                {
                    val = memVal;
                }
                gridMemoria.Rows.Add($"0x{address:X8}", $"0x{val:X8}", val.ToString());
            }
            gridMemoria.ClearSelection();
        }

        #endregion

        #region Event Handlers

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "Assembly files|*.txt;*.asm|All files|*.*" };
            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                var lines = File.ReadAllLines(dialog.FileName);
                txtCodigoAssembly.Text = string.Join(Environment.NewLine, lines);

                ResetUIState();
                simulador = new Simulador(lines);
                simulador.MemoriaModificada += Simulador_MemoriaModificada;
                estadoAnteriorRegs = simulador.GetRegistradores();
                estadoAnteriorMem = simulador.GetMemoria();
                UpdateInterface(true);
                SetExecutionButtonsEnabled(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetUIState();
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (simulador == null || simulador.Terminou) return;
            try
            {
                simulador.ProximoClock();
                UpdateInterface();
                if (simulador.Terminou)
                {
                    MessageBox.Show("A execução do programa terminou.", "Fim da Execução", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro de execução: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            if (simulador == null || simulador.Terminou) return;
            SetButtonState(false);
            isPaused = false;
            btnPausar.Text = "Pausar";
            executionTimer.Start();
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                executionTimer.Stop();
                btnPausar.Text = "Continuar";
            }
            else
            {
                executionTimer.Start();
                btnPausar.Text = "Pausar";
            }
        }

        private void btnResetar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoAssembly.Text)) return;
            try
            {
                var lines = txtCodigoAssembly.Lines;
                ResetUIState();
                simulador = new Simulador(lines);
                simulador.MemoriaModificada += Simulador_MemoriaModificada;
                estadoAnteriorRegs = simulador.GetRegistradores();
                estadoAnteriorMem = simulador.GetMemoria();
                UpdateInterface(true);
                SetExecutionButtonsEnabled(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao resetar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetUIState();
            }
        }

        private void btnMemGo_Click(object sender, EventArgs e)
        {
            try
            {
                string addressText = txtMemAddress.Text;
                long address = long.Parse(addressText.StartsWith("0x") ? addressText.Substring(2) : addressText, NumberStyles.HexNumber);
                InitializeMemoryGrid(address & 0xFFFFFFFC);
            }
            catch
            {
                MessageBox.Show("Endereço hexadecimal inválido. Use o formato '0x...'.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecutionTimer_Tick(object sender, EventArgs e)
        {
            if (simulador == null || simulador.Terminou)
            {
                executionTimer.Stop();
                UpdateInterface();
                SetButtonState(true);
                MessageBox.Show("A execução do programa terminou.", "Fim da Execução", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                simulador.ProximoClock();
                UpdateInterface();
            }
            catch (Exception ex)
            {
                executionTimer.Stop();
                SetButtonState(true);
                MessageBox.Show($"Erro de execução: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Simulador_MemoriaModificada(long address)
        {
            txtMemAddress.Text = $"0x{address:X8}";
            InitializeMemoryGrid(address);
            gridMemoria.Invalidate();
        }

        #endregion

        #region Atualização da UI
        private void UpdateInterface(bool fullMemUpdate = false)
        {
            if (simulador == null) return;

            var novosRegs = simulador.GetRegistradores();
            var novaMem = simulador.GetMemoria();

            lblClockValor.Text = simulador.Tempo.ToString();
            lblPCValor.Text = $"0x{simulador.PC:X8}";
            txtInstrucaoAtual.Text = simulador.InstrucaoAtual;

            double tempoNs = (simulador.FreqCpu > 0) ? ((double)simulador.Tempo / simulador.FreqCpu) * 1e9 : 0;
            lblTempoTotal.Text = $"{tempoNs:F3} ns";

            HighlightChanges(novosRegs, novaMem);
            estadoAnteriorRegs = novosRegs;
            estadoAnteriorMem = new Dictionary<long, int>(novaMem);

            if (fullMemUpdate)
            {
                btnMemGo_Click(null, null);
            }

            HighlightCurrentLine(simulador.LinhaAtual);
        }

        private void HighlightChanges(int[] novosRegs, Dictionary<long, int> novaMem)
        {
            foreach (DataGridViewRow row in gridRegistradores.Rows) row.DefaultCellStyle.BackColor = gridRegistradores.DefaultCellStyle.BackColor;
            foreach (DataGridViewRow row in gridMemoria.Rows) row.DefaultCellStyle.BackColor = gridMemoria.DefaultCellStyle.BackColor;

            for (int i = 0; i < 32; i++)
            {
                if (novosRegs[i] != estadoAnteriorRegs[i])
                {
                    gridRegistradores.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                gridRegistradores.Rows[i].Cells["Hex"].Value = $"0x{novosRegs[i]:X8}";
                gridRegistradores.Rows[i].Cells["Dec"].Value = novosRegs[i].ToString();
            }

            foreach (DataGridViewRow row in gridMemoria.Rows)
            {
                long addr = long.Parse(row.Cells["Endereco"].Value.ToString().Substring(2), NumberStyles.HexNumber);
                if (novaMem.TryGetValue(addr, out int novoValor))
                {
                    estadoAnteriorMem.TryGetValue(addr, out int valorAntigo);
                    if (novoValor != valorAntigo)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    row.Cells["Hex"].Value = $"0x{novoValor:X8}";
                    row.Cells["Dec"].Value = novoValor.ToString();
                }
            }
        }

        private void SetExecutionButtonsEnabled(bool isEnabled)
        {
            btnExecutar.Enabled = isEnabled;
            btnProximo.Enabled = isEnabled;
            btnResetar.Enabled = isEnabled;
        }

        private void SetButtonState(bool enabled)
        {
            btnAbrir.Enabled = enabled;
            SetExecutionButtonsEnabled(enabled);
            btnPausar.Enabled = !enabled;

            if (enabled)
            {
                btnPausar.Text = "Pausar";
                executionTimer.Stop();
            }
        }

        private void HighlightCurrentLine(int lineIndex)
        {
            txtCodigoAssembly.SelectAll();
            txtCodigoAssembly.SelectionBackColor = txtCodigoAssembly.BackColor;

            if (lineIndex >= 0 && lineIndex < txtCodigoAssembly.Lines.Length)
            {
                int start = txtCodigoAssembly.GetFirstCharIndexFromLine(lineIndex);
                int length = txtCodigoAssembly.Lines[lineIndex].Length;
                if (start >= 0 && length > 0)
                {
                    txtCodigoAssembly.Select(start, length);
                    txtCodigoAssembly.SelectionBackColor = Color.Yellow;
                    txtCodigoAssembly.ScrollToCaret();
                }
            }
            txtCodigoAssembly.DeselectAll();
        }
        #endregion
    }
}