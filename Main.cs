using System;
using System.Windows.Forms;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsDemo
{
    public partial class Main : Form
    {
        private int linhaAtual = 0;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Inicializa a grid de registradores
            var dtRegs = new DataTable();
            dtRegs.Columns.Add("Nome");
            dtRegs.Columns.Add("Valor");

            for (int i = 0; i < 32; i++)
            {
                dtRegs.Rows.Add($"$r{i}", "0x00000000");
            }
            gridRegistradores.DataSource = dtRegs;

            // Inicializa a grid de memória
            var dtMem = new DataTable();
            dtMem.Columns.Add("Endereço");
            dtMem.Columns.Add("Valor");

            for (int i = 0; i < 16; i++)
            {
                dtMem.Rows.Add($"0x1001000{i:X}", "0x00000000");
            }
            gridMemoria.DataSource = dtMem;

            // Configura o gráfico
            chartRegistradores.Series.Clear();
            var series = new Series("Uso")
            {
                ChartType = SeriesChartType.Column
            };
            for (int i = 0; i < 8; i++)
            {
                series.Points.AddXY($"$r{i}", i * 2);
            }
            chartRegistradores.Series.Add(series);
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Arquivos de texto (*.txt)|*.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtCodigoAssembly.Text = System.IO.File.ReadAllText(openFile.FileName);
                linhaAtual = 0;
            }
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Execução iniciada (simulação ainda não implementada).", "Executar");
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            int clockAtual = int.Parse(lblClockValor.Text);
            lblClockValor.Text = (clockAtual + 1).ToString();

            // Avança a execução linha por linha
            string[] linhas = txtCodigoAssembly.Lines;

            if (linhaAtual < linhas.Length)
            {
                // Remove destaque anterior
                txtCodigoAssembly.SelectAll();
                txtCodigoAssembly.SelectionBackColor = txtCodigoAssembly.BackColor;

                // Destaca linha atual
                int start = txtCodigoAssembly.GetFirstCharIndexFromLine(linhaAtual);
                int length = linhas[linhaAtual].Length;
                txtCodigoAssembly.Select(start, length);
                txtCodigoAssembly.SelectionBackColor = System.Drawing.Color.Yellow;

                // Atualiza PC e instrução (só simulação visual por enquanto)
                txtInstrucaoAtual.Text = linhas[linhaAtual];
                lblPCValor.Text = $"0x004000{clockAtual + 1:X2}";

                linhaAtual++;
            }
        }

        private void btnResetar_Click(object sender, EventArgs e)
        {
            lblClockValor.Text = "0";
            lblPCValor.Text = "0x00400000";
            txtInstrucaoAtual.Text = "";
            linhaAtual = 0;
            txtCodigoAssembly.SelectAll();
            txtCodigoAssembly.SelectionBackColor = txtCodigoAssembly.BackColor;
        }
    }
}
