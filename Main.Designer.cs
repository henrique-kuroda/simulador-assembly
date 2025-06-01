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
        private System.Windows.Forms.TableLayoutPanel mainLayout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
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
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.infoPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegistradores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMemoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRegistradores)).BeginInit();
            this.mainLayout.SuspendLayout();
            this.btnPanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(3, 3);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(75, 23);
            this.btnAbrir.TabIndex = 0;
            this.btnAbrir.Text = "Abrir Arquivo";
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnExecutar
            // 
            this.btnExecutar.Location = new System.Drawing.Point(84, 3);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(75, 23);
            this.btnExecutar.TabIndex = 1;
            this.btnExecutar.Text = "Executar";
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // btnProximo
            // 
            this.btnProximo.Location = new System.Drawing.Point(165, 3);
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(75, 23);
            this.btnProximo.TabIndex = 2;
            this.btnProximo.Text = "Próximo Clock";
            this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
            // 
            // btnResetar
            // 
            this.btnResetar.Location = new System.Drawing.Point(246, 3);
            this.btnResetar.Name = "btnResetar";
            this.btnResetar.Size = new System.Drawing.Size(75, 23);
            this.btnResetar.TabIndex = 3;
            this.btnResetar.Text = "Resetar";
            this.btnResetar.Click += new System.EventHandler(this.btnResetar_Click);
            // 
            // txtCodigoAssembly
            // 
            this.mainLayout.SetColumnSpan(this.txtCodigoAssembly, 2);
            this.txtCodigoAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCodigoAssembly.Location = new System.Drawing.Point(3, 43);
            this.txtCodigoAssembly.Name = "txtCodigoAssembly";
            this.txtCodigoAssembly.Size = new System.Drawing.Size(794, 162);
            this.txtCodigoAssembly.TabIndex = 1;
            this.txtCodigoAssembly.Text = "";
            // 
            // gridRegistradores
            // 
            this.gridRegistradores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRegistradores.Location = new System.Drawing.Point(3, 211);
            this.gridRegistradores.Name = "gridRegistradores";
            this.gridRegistradores.Size = new System.Drawing.Size(394, 218);
            this.gridRegistradores.TabIndex = 2;
            // 
            // gridMemoria
            // 
            this.gridMemoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMemoria.Location = new System.Drawing.Point(403, 211);
            this.gridMemoria.Name = "gridMemoria";
            this.gridMemoria.Size = new System.Drawing.Size(394, 218);
            this.gridMemoria.TabIndex = 3;
            // 
            // lblInstrucaoAtual
            // 
            this.lblInstrucaoAtual.Location = new System.Drawing.Point(0, 0);
            this.lblInstrucaoAtual.Name = "lblInstrucaoAtual";
            this.lblInstrucaoAtual.Size = new System.Drawing.Size(100, 23);
            this.lblInstrucaoAtual.TabIndex = 0;
            // 
            // txtInstrucaoAtual
            // 
            this.txtInstrucaoAtual.Location = new System.Drawing.Point(109, 3);
            this.txtInstrucaoAtual.Name = "txtInstrucaoAtual";
            this.txtInstrucaoAtual.Size = new System.Drawing.Size(150, 20);
            this.txtInstrucaoAtual.TabIndex = 1;
            // 
            // lblPC
            // 
            this.lblPC.Location = new System.Drawing.Point(0, 0);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(100, 23);
            this.lblPC.TabIndex = 0;
            // 
            // lblPCValor
            // 
            this.lblPCValor.Location = new System.Drawing.Point(3, 26);
            this.lblPCValor.Name = "lblPCValor";
            this.lblPCValor.Size = new System.Drawing.Size(100, 23);
            this.lblPCValor.TabIndex = 3;
            this.lblPCValor.Text = "0x00400000";
            // 
            // lblClock
            // 
            this.lblClock.Location = new System.Drawing.Point(0, 0);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(100, 23);
            this.lblClock.TabIndex = 0;
            // 
            // lblClockValor
            // 
            this.lblClockValor.Location = new System.Drawing.Point(215, 26);
            this.lblClockValor.Name = "lblClockValor";
            this.lblClockValor.Size = new System.Drawing.Size(100, 23);
            this.lblClockValor.TabIndex = 5;
            this.lblClockValor.Text = "0";
            // 
            // chartRegistradores
            // 
            this.chartRegistradores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartRegistradores.Location = new System.Drawing.Point(403, 435);
            this.chartRegistradores.Name = "chartRegistradores";
            this.chartRegistradores.Size = new System.Drawing.Size(394, 162);
            this.chartRegistradores.TabIndex = 5;
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.Controls.Add(this.btnPanel, 0, 0);
            this.mainLayout.Controls.Add(this.txtCodigoAssembly, 0, 1);
            this.mainLayout.Controls.Add(this.gridRegistradores, 0, 2);
            this.mainLayout.Controls.Add(this.gridMemoria, 1, 2);
            this.mainLayout.Controls.Add(this.infoPanel, 0, 3);
            this.mainLayout.Controls.Add(this.chartRegistradores, 1, 3);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 4;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.mainLayout.Size = new System.Drawing.Size(800, 600);
            this.mainLayout.TabIndex = 0;
            // 
            // btnPanel
            // 
            this.mainLayout.SetColumnSpan(this.btnPanel, 2);
            this.btnPanel.Controls.Add(this.btnAbrir);
            this.btnPanel.Controls.Add(this.btnExecutar);
            this.btnPanel.Controls.Add(this.btnProximo);
            this.btnPanel.Controls.Add(this.btnResetar);
            this.btnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPanel.Location = new System.Drawing.Point(3, 3);
            this.btnPanel.Name = "btnPanel";
            this.btnPanel.Size = new System.Drawing.Size(794, 34);
            this.btnPanel.TabIndex = 0;
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.txtInstrucaoAtual);
            this.infoPanel.Controls.Add(this.lblPCValor);
            this.infoPanel.Controls.Add(this.lblClockValor);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoPanel.Location = new System.Drawing.Point(3, 435);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(394, 162);
            this.infoPanel.TabIndex = 4;
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.mainLayout);
            this.Name = "Main";
            this.Text = "z";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridRegistradores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMemoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRegistradores)).EndInit();
            this.mainLayout.ResumeLayout(false);
            this.btnPanel.ResumeLayout(false);
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private FlowLayoutPanel btnPanel;
        private FlowLayoutPanel infoPanel;
    }
}
