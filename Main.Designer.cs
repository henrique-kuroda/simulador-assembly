using System;
using System.Windows.Forms;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsDemo
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnExecutar;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Button btnResetar;
        private System.Windows.Forms.RichTextBox txtCodigoAssembly;
        private System.Windows.Forms.DataGridView gridRegistradores;
        private System.Windows.Forms.DataGridView gridMemoria;
        private System.Windows.Forms.Label lblInstrucaoAtual;
        private System.Windows.Forms.TextBox txtInstrucaoAtual;
        private System.Windows.Forms.Label lblPC;
        private System.Windows.Forms.Label lblPCValor;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Label lblClockValor;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRegistradores;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.btnProximo = new System.Windows.Forms.Button();
            this.btnResetar = new System.Windows.Forms.Button();
            this.txtCodigoAssembly = new System.Windows.Forms.RichTextBox();
            this.gridRegistradores = new System.Windows.Forms.DataGridView();
            this.gridMemoria = new System.Windows.Forms.DataGridView();
            this.lblInstrucaoAtual = new System.Windows.Forms.Label();
            this.txtInstrucaoAtual = new System.Windows.Forms.TextBox();
            this.lblPC = new System.Windows.Forms.Label();
            this.lblPCValor = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.lblClockValor = new System.Windows.Forms.Label();
            this.chartRegistradores = new System.Windows.Forms.DataVisualization.Charting.Chart();

            ((System.ComponentModel.ISupportInitialize)(this.gridRegistradores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMemoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRegistradores)).BeginInit();
            this.SuspendLayout();

            this.btnAbrir.Location = new System.Drawing.Point(20, 20);
            this.btnAbrir.Size = new System.Drawing.Size(100, 30);
            this.btnAbrir.Text = "Abrir Arquivo";

            this.btnExecutar.Location = new System.Drawing.Point(130, 20);
            this.btnExecutar.Size = new System.Drawing.Size(100, 30);
            this.btnExecutar.Text = "Executar";

            this.btnProximo.Location = new System.Drawing.Point(240, 20);
            this.btnProximo.Size = new System.Drawing.Size(120, 30);
            this.btnProximo.Text = "Próximo Clock";

            this.btnResetar.Location = new System.Drawing.Point(370, 20);
            this.btnResetar.Size = new System.Drawing.Size(100, 30);
            this.btnResetar.Text = "Resetar";

            this.txtCodigoAssembly.Location = new System.Drawing.Point(20, 70);
            this.txtCodigoAssembly.Size = new System.Drawing.Size(600, 120);

            this.gridRegistradores.Location = new System.Drawing.Point(20, 200);
            this.gridRegistradores.Size = new System.Drawing.Size(280, 180);

            this.gridMemoria.Location = new System.Drawing.Point(310, 200);
            this.gridMemoria.Size = new System.Drawing.Size(310, 180);

            this.lblInstrucaoAtual.Location = new System.Drawing.Point(20, 390);
            this.lblInstrucaoAtual.Size = new System.Drawing.Size(100, 20);
            this.lblInstrucaoAtual.Text = "Instrução Atual:";

            this.txtInstrucaoAtual.Location = new System.Drawing.Point(130, 390);
            this.txtInstrucaoAtual.Size = new System.Drawing.Size(150, 20);

            this.lblPC.Location = new System.Drawing.Point(300, 390);
            this.lblPC.Size = new System.Drawing.Size(30, 20);
            this.lblPC.Text = "PC:";

            this.lblPCValor.Location = new System.Drawing.Point(330, 390);
            this.lblPCValor.Size = new System.Drawing.Size(100, 20);
            this.lblPCValor.Text = "0x00400000";

            this.lblClock.Location = new System.Drawing.Point(450, 390);
            this.lblClock.Size = new System.Drawing.Size(40, 20);
            this.lblClock.Text = "Clock:";

            this.lblClockValor.Location = new System.Drawing.Point(500, 390);
            this.lblClockValor.Size = new System.Drawing.Size(50, 20);
            this.lblClockValor.Text = "0";

            this.chartRegistradores.Location = new System.Drawing.Point(20, 420);
            this.chartRegistradores.Size = new System.Drawing.Size(600, 180);

            this.ClientSize = new System.Drawing.Size(650, 620);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.btnExecutar);
            this.Controls.Add(this.btnProximo);
            this.Controls.Add(this.btnResetar);
            this.Controls.Add(this.txtCodigoAssembly);
            this.Controls.Add(this.gridRegistradores);
            this.Controls.Add(this.gridMemoria);
            this.Controls.Add(this.lblInstrucaoAtual);
            this.Controls.Add(this.txtInstrucaoAtual);
            this.Controls.Add(this.lblPC);
            this.Controls.Add(this.lblPCValor);
            this.Controls.Add(this.lblClock);
            this.Controls.Add(this.lblClockValor);
            this.Controls.Add(this.chartRegistradores);
            this.Text = "Simulador MIPS";

            this.Load += new System.EventHandler(this.Main_Load);
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
            this.btnResetar.Click += new System.EventHandler(this.btnResetar_Click);

            ((System.ComponentModel.ISupportInitialize)(this.gridRegistradores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMemoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRegistradores)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
