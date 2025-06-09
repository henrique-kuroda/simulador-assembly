namespace WinFormsDemo
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.btnProximo = new System.Windows.Forms.Button();
            this.btnPausar = new System.Windows.Forms.Button();
            this.btnResetar = new System.Windows.Forms.Button();
            this.codeAndMemPanel = new System.Windows.Forms.TableLayoutPanel();
            this.codeGroup = new System.Windows.Forms.GroupBox();
            this.txtCodigoAssembly = new System.Windows.Forms.RichTextBox();
            this.memGroup = new System.Windows.Forms.GroupBox();
            this.gridMemoria = new System.Windows.Forms.DataGridView();
            this.memControlPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMemAddress = new System.Windows.Forms.Label();
            this.txtMemAddress = new System.Windows.Forms.TextBox();
            this.btnMemGo = new System.Windows.Forms.Button();
            this.regsAndInfoPanel = new System.Windows.Forms.TableLayoutPanel();
            this.regsGroup = new System.Windows.Forms.GroupBox();
            this.gridRegistradores = new System.Windows.Forms.DataGridView();
            this.infoGroup = new System.Windows.Forms.GroupBox();
            this.infoMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.metricsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelClock = new System.Windows.Forms.Panel();
            this.lblClock = new System.Windows.Forms.Label();
            this.lblClockValor = new System.Windows.Forms.Label();
            this.panelTempo = new System.Windows.Forms.Panel();
            this.lblTempo = new System.Windows.Forms.Label();
            this.lblTempoTotal = new System.Windows.Forms.Label();
            this.pcPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblPC = new System.Windows.Forms.Label();
            this.lblPCValor = new System.Windows.Forms.Label();
            this.instructionPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblInstrucao = new System.Windows.Forms.Label();
            this.txtInstrucaoAtual = new System.Windows.Forms.TextBox();
            this.mainLayout.SuspendLayout();
            this.btnPanel.SuspendLayout();
            this.codeAndMemPanel.SuspendLayout();
            this.codeGroup.SuspendLayout();
            this.memGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMemoria)).BeginInit();
            this.memControlPanel.SuspendLayout();
            this.regsAndInfoPanel.SuspendLayout();
            this.regsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegistradores)).BeginInit();
            this.infoGroup.SuspendLayout();
            this.infoMainLayout.SuspendLayout();
            this.metricsPanel.SuspendLayout();
            this.panelClock.SuspendLayout();
            this.panelTempo.SuspendLayout();
            this.pcPanel.SuspendLayout();
            this.instructionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.btnPanel, 0, 0);
            this.mainLayout.Controls.Add(this.codeAndMemPanel, 0, 1);
            this.mainLayout.Controls.Add(this.regsAndInfoPanel, 0, 2);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.mainLayout.Size = new System.Drawing.Size(1264, 741);
            this.mainLayout.TabIndex = 0;
            // 
            // btnPanel
            // 
            this.btnPanel.Controls.Add(this.btnAbrir);
            this.btnPanel.Controls.Add(this.btnExecutar);
            this.btnPanel.Controls.Add(this.btnProximo);
            this.btnPanel.Controls.Add(this.btnPausar);
            this.btnPanel.Controls.Add(this.btnResetar);
            this.btnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPanel.Location = new System.Drawing.Point(3, 3);
            this.btnPanel.Name = "btnPanel";
            this.btnPanel.Padding = new System.Windows.Forms.Padding(5);
            this.btnPanel.Size = new System.Drawing.Size(1258, 34);
            this.btnPanel.TabIndex = 0;
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(8, 8);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(90, 23);
            this.btnAbrir.TabIndex = 0;
            this.btnAbrir.Text = "Abrir Arquivo";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnExecutar
            // 
            this.btnExecutar.Location = new System.Drawing.Point(104, 8);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(90, 23);
            this.btnExecutar.TabIndex = 1;
            this.btnExecutar.Text = "Executar";
            this.btnExecutar.UseVisualStyleBackColor = true;
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // btnProximo
            // 
            this.btnProximo.Location = new System.Drawing.Point(200, 8);
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(90, 23);
            this.btnProximo.TabIndex = 2;
            this.btnProximo.Text = "Próximo Clock";
            this.btnProximo.UseVisualStyleBackColor = true;
            this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
            // 
            // btnPausar
            // 
            this.btnPausar.Enabled = false;
            this.btnPausar.Location = new System.Drawing.Point(296, 8);
            this.btnPausar.Name = "btnPausar";
            this.btnPausar.Size = new System.Drawing.Size(90, 23);
            this.btnPausar.TabIndex = 3;
            this.btnPausar.Text = "Pausar";
            this.btnPausar.UseVisualStyleBackColor = true;
            this.btnPausar.Click += new System.EventHandler(this.btnPausar_Click);
            // 
            // btnResetar
            // 
            this.btnResetar.Location = new System.Drawing.Point(392, 8);
            this.btnResetar.Name = "btnResetar";
            this.btnResetar.Size = new System.Drawing.Size(90, 23);
            this.btnResetar.TabIndex = 4;
            this.btnResetar.Text = "Resetar";
            this.btnResetar.UseVisualStyleBackColor = true;
            this.btnResetar.Click += new System.EventHandler(this.btnResetar_Click);
            // 
            // codeAndMemPanel
            // 
            this.codeAndMemPanel.ColumnCount = 2;
            this.codeAndMemPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.codeAndMemPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.codeAndMemPanel.Controls.Add(this.codeGroup, 0, 0);
            this.codeAndMemPanel.Controls.Add(this.memGroup, 1, 0);
            this.codeAndMemPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeAndMemPanel.Location = new System.Drawing.Point(3, 43);
            this.codeAndMemPanel.Name = "codeAndMemPanel";
            this.codeAndMemPanel.RowCount = 1;
            this.codeAndMemPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.codeAndMemPanel.Size = new System.Drawing.Size(1258, 274);
            this.codeAndMemPanel.TabIndex = 1;
            // 
            // codeGroup
            // 
            this.codeGroup.Controls.Add(this.txtCodigoAssembly);
            this.codeGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeGroup.Location = new System.Drawing.Point(3, 3);
            this.codeGroup.Name = "codeGroup";
            this.codeGroup.Size = new System.Drawing.Size(623, 268);
            this.codeGroup.TabIndex = 0;
            this.codeGroup.TabStop = false;
            this.codeGroup.Text = "Código Assembly";
            // 
            // txtCodigoAssembly
            // 
            this.txtCodigoAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCodigoAssembly.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoAssembly.Location = new System.Drawing.Point(3, 16);
            this.txtCodigoAssembly.Name = "txtCodigoAssembly";
            this.txtCodigoAssembly.Size = new System.Drawing.Size(617, 249);
            this.txtCodigoAssembly.TabIndex = 0;
            this.txtCodigoAssembly.Text = "";
            this.txtCodigoAssembly.WordWrap = false;
            // 
            // memGroup
            // 
            this.memGroup.Controls.Add(this.gridMemoria);
            this.memGroup.Controls.Add(this.memControlPanel);
            this.memGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memGroup.Location = new System.Drawing.Point(632, 3);
            this.memGroup.Name = "memGroup";
            this.memGroup.Size = new System.Drawing.Size(623, 268);
            this.memGroup.TabIndex = 1;
            this.memGroup.TabStop = false;
            this.memGroup.Text = "Memória";
            // 
            // gridMemoria
            // 
            this.gridMemoria.AllowUserToAddRows = false;
            this.gridMemoria.AllowUserToDeleteRows = false;
            this.gridMemoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridMemoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMemoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMemoria.Location = new System.Drawing.Point(3, 50);
            this.gridMemoria.Name = "gridMemoria";
            this.gridMemoria.ReadOnly = true;
            this.gridMemoria.Size = new System.Drawing.Size(617, 215);
            this.gridMemoria.TabIndex = 1;
            // 
            // memControlPanel
            // 
            this.memControlPanel.Controls.Add(this.lblMemAddress);
            this.memControlPanel.Controls.Add(this.txtMemAddress);
            this.memControlPanel.Controls.Add(this.btnMemGo);
            this.memControlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.memControlPanel.Location = new System.Drawing.Point(3, 16);
            this.memControlPanel.Name = "memControlPanel";
            this.memControlPanel.Size = new System.Drawing.Size(617, 34);
            this.memControlPanel.TabIndex = 0;
            // 
            // lblMemAddress
            // 
            this.lblMemAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMemAddress.AutoSize = true;
            this.lblMemAddress.Location = new System.Drawing.Point(3, 8);
            this.lblMemAddress.Name = "lblMemAddress";
            this.lblMemAddress.Size = new System.Drawing.Size(89, 13);
            this.lblMemAddress.TabIndex = 0;
            this.lblMemAddress.Text = "Ir para Endereço:";
            // 
            // txtMemAddress
            // 
            this.txtMemAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMemAddress.Location = new System.Drawing.Point(98, 4);
            this.txtMemAddress.Name = "txtMemAddress";
            this.txtMemAddress.Size = new System.Drawing.Size(100, 20);
            this.txtMemAddress.TabIndex = 1;
            // 
            // btnMemGo
            // 
            this.btnMemGo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnMemGo.Location = new System.Drawing.Point(204, 3);
            this.btnMemGo.Name = "btnMemGo";
            this.btnMemGo.Size = new System.Drawing.Size(33, 23);
            this.btnMemGo.TabIndex = 2;
            this.btnMemGo.Text = "Ir";
            this.btnMemGo.UseVisualStyleBackColor = true;
            this.btnMemGo.Click += new System.EventHandler(this.btnMemGo_Click);
            // 
            // regsAndInfoPanel
            // 
            this.regsAndInfoPanel.ColumnCount = 2;
            this.regsAndInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.regsAndInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.regsAndInfoPanel.Controls.Add(this.regsGroup, 0, 0);
            this.regsAndInfoPanel.Controls.Add(this.infoGroup, 1, 0);
            this.regsAndInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regsAndInfoPanel.Location = new System.Drawing.Point(3, 323);
            this.regsAndInfoPanel.Name = "regsAndInfoPanel";
            this.regsAndInfoPanel.RowCount = 1;
            this.regsAndInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.regsAndInfoPanel.Size = new System.Drawing.Size(1258, 415);
            this.regsAndInfoPanel.TabIndex = 2;
            // 
            // regsGroup
            // 
            this.regsGroup.Controls.Add(this.gridRegistradores);
            this.regsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regsGroup.Location = new System.Drawing.Point(3, 3);
            this.regsGroup.Name = "regsGroup";
            this.regsGroup.Size = new System.Drawing.Size(623, 409);
            this.regsGroup.TabIndex = 0;
            this.regsGroup.TabStop = false;
            this.regsGroup.Text = "Registradores";
            // 
            // gridRegistradores
            // 
            this.gridRegistradores.AllowUserToAddRows = false;
            this.gridRegistradores.AllowUserToDeleteRows = false;
            this.gridRegistradores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridRegistradores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRegistradores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRegistradores.Location = new System.Drawing.Point(3, 16);
            this.gridRegistradores.Name = "gridRegistradores";
            this.gridRegistradores.ReadOnly = true;
            this.gridRegistradores.Size = new System.Drawing.Size(617, 390);
            this.gridRegistradores.TabIndex = 0;
            // 
            // infoGroup
            // 
            this.infoGroup.Controls.Add(this.infoMainLayout);
            this.infoGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoGroup.Location = new System.Drawing.Point(632, 3);
            this.infoGroup.Name = "infoGroup";
            this.infoGroup.Padding = new System.Windows.Forms.Padding(10);
            this.infoGroup.Size = new System.Drawing.Size(623, 409);
            this.infoGroup.TabIndex = 1;
            this.infoGroup.TabStop = false;
            this.infoGroup.Text = "Informações da Execução";
            // 
            // infoMainLayout
            // 
            this.infoMainLayout.ColumnCount = 1;
            this.infoMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.infoMainLayout.Controls.Add(this.metricsPanel, 0, 0);
            this.infoMainLayout.Controls.Add(this.pcPanel, 0, 1);
            this.infoMainLayout.Controls.Add(this.instructionPanel, 0, 2);
            this.infoMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoMainLayout.Location = new System.Drawing.Point(10, 23);
            this.infoMainLayout.Name = "infoMainLayout";
            this.infoMainLayout.RowCount = 4;
            this.infoMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.infoMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.infoMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.infoMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.infoMainLayout.Size = new System.Drawing.Size(603, 376);
            this.infoMainLayout.TabIndex = 0;
            // 
            // metricsPanel
            // 
            this.metricsPanel.ColumnCount = 2;
            this.metricsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.metricsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.metricsPanel.Controls.Add(this.panelClock, 0, 0);
            this.metricsPanel.Controls.Add(this.panelTempo, 1, 0);
            this.metricsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metricsPanel.Location = new System.Drawing.Point(3, 3);
            this.metricsPanel.Name = "metricsPanel";
            this.metricsPanel.RowCount = 1;
            this.metricsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.metricsPanel.Size = new System.Drawing.Size(597, 84);
            this.metricsPanel.TabIndex = 0;
            // 
            // panelClock
            // 
            this.panelClock.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelClock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClock.Controls.Add(this.lblClock);
            this.panelClock.Controls.Add(this.lblClockValor);
            this.panelClock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClock.Location = new System.Drawing.Point(3, 3);
            this.panelClock.Name = "panelClock";
            this.panelClock.Size = new System.Drawing.Size(292, 78);
            this.panelClock.TabIndex = 0;
            // 
            // lblClock
            // 
            this.lblClock.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblClock.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.Color.DimGray;
            this.lblClock.Location = new System.Drawing.Point(0, 0);
            this.lblClock.Name = "lblClock";
            this.lblClock.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblClock.Size = new System.Drawing.Size(290, 25);
            this.lblClock.TabIndex = 0;
            this.lblClock.Text = "CLOCK";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblClockValor
            // 
            this.lblClockValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClockValor.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClockValor.Location = new System.Drawing.Point(0, 25);
            this.lblClockValor.Name = "lblClockValor";
            this.lblClockValor.Size = new System.Drawing.Size(290, 51);
            this.lblClockValor.TabIndex = 1;
            this.lblClockValor.Text = "0";
            this.lblClockValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTempo
            // 
            this.panelTempo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelTempo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTempo.Controls.Add(this.lblTempo);
            this.panelTempo.Controls.Add(this.lblTempoTotal);
            this.panelTempo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTempo.Location = new System.Drawing.Point(301, 3);
            this.panelTempo.Name = "panelTempo";
            this.panelTempo.Size = new System.Drawing.Size(293, 78);
            this.panelTempo.TabIndex = 1;
            // 
            // lblTempo
            // 
            this.lblTempo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTempo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempo.ForeColor = System.Drawing.Color.DimGray;
            this.lblTempo.Location = new System.Drawing.Point(0, 0);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblTempo.Size = new System.Drawing.Size(291, 25);
            this.lblTempo.TabIndex = 0;
            this.lblTempo.Text = "TEMPO TOTAL";
            this.lblTempo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTempoTotal
            // 
            this.lblTempoTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTempoTotal.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempoTotal.Location = new System.Drawing.Point(0, 25);
            this.lblTempoTotal.Name = "lblTempoTotal";
            this.lblTempoTotal.Size = new System.Drawing.Size(291, 51);
            this.lblTempoTotal.TabIndex = 1;
            this.lblTempoTotal.Text = "0.000 ns";
            this.lblTempoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pcPanel
            // 
            this.pcPanel.ColumnCount = 2;
            this.pcPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.pcPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pcPanel.Controls.Add(this.lblPC, 0, 0);
            this.pcPanel.Controls.Add(this.lblPCValor, 1, 0);
            this.pcPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcPanel.Location = new System.Drawing.Point(3, 93);
            this.pcPanel.Name = "pcPanel";
            this.pcPanel.RowCount = 1;
            this.pcPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pcPanel.Size = new System.Drawing.Size(597, 24);
            this.pcPanel.TabIndex = 1;
            // 
            // lblPC
            // 
            this.lblPC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPC.AutoSize = true;
            this.lblPC.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPC.Location = new System.Drawing.Point(3, 3);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(27, 17);
            this.lblPC.TabIndex = 0;
            this.lblPC.Text = "PC:";
            // 
            // lblPCValor
            // 
            this.lblPCValor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPCValor.AutoSize = true;
            this.lblPCValor.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPCValor.Location = new System.Drawing.Point(83, 3);
            this.lblPCValor.Name = "lblPCValor";
            this.lblPCValor.Size = new System.Drawing.Size(32, 18);
            this.lblPCValor.TabIndex = 1;
            this.lblPCValor.Text = "N/A";
            // 
            // instructionPanel
            // 
            this.instructionPanel.ColumnCount = 2;
            this.instructionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.instructionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.instructionPanel.Controls.Add(this.lblInstrucao, 0, 0);
            this.instructionPanel.Controls.Add(this.txtInstrucaoAtual, 1, 0);
            this.instructionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instructionPanel.Location = new System.Drawing.Point(3, 123);
            this.instructionPanel.Name = "instructionPanel";
            this.instructionPanel.RowCount = 1;
            this.instructionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.instructionPanel.Size = new System.Drawing.Size(597, 24);
            this.instructionPanel.TabIndex = 2;
            // 
            // lblInstrucao
            // 
            this.lblInstrucao.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInstrucao.AutoSize = true;
            this.lblInstrucao.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstrucao.Location = new System.Drawing.Point(3, 3);
            this.lblInstrucao.Name = "lblInstrucao";
            this.lblInstrucao.Size = new System.Drawing.Size(68, 17);
            this.lblInstrucao.TabIndex = 0;
            this.lblInstrucao.Text = "Instrução:";
            // 
            // txtInstrucaoAtual
            // 
            this.txtInstrucaoAtual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInstrucaoAtual.BackColor = System.Drawing.SystemColors.Control;
            this.txtInstrucaoAtual.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInstrucaoAtual.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstrucaoAtual.Location = new System.Drawing.Point(83, 3);
            this.txtInstrucaoAtual.Name = "txtInstrucaoAtual";
            this.txtInstrucaoAtual.ReadOnly = true;
            this.txtInstrucaoAtual.Size = new System.Drawing.Size(511, 18);
            this.txtInstrucaoAtual.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 741);
            this.Controls.Add(this.mainLayout);
            this.Name = "Main";
            this.Text = "Simulador MIPS Avançado";
            this.mainLayout.ResumeLayout(false);
            this.btnPanel.ResumeLayout(false);
            this.codeAndMemPanel.ResumeLayout(false);
            this.codeGroup.ResumeLayout(false);
            this.memGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMemoria)).EndInit();
            this.memControlPanel.ResumeLayout(false);
            this.memControlPanel.PerformLayout();
            this.regsAndInfoPanel.ResumeLayout(false);
            this.regsGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRegistradores)).EndInit();
            this.infoGroup.ResumeLayout(false);
            this.infoMainLayout.ResumeLayout(false);
            this.metricsPanel.ResumeLayout(false);
            this.panelClock.ResumeLayout(false);
            this.panelClock.PerformLayout();
            this.panelTempo.ResumeLayout(false);
            this.panelTempo.PerformLayout();
            this.pcPanel.ResumeLayout(false);
            this.pcPanel.PerformLayout();
            this.instructionPanel.ResumeLayout(false);
            this.instructionPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.FlowLayoutPanel btnPanel;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnExecutar;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Button btnPausar;
        private System.Windows.Forms.Button btnResetar;
        private System.Windows.Forms.TableLayoutPanel codeAndMemPanel;
        private System.Windows.Forms.GroupBox codeGroup;
        private System.Windows.Forms.RichTextBox txtCodigoAssembly;
        private System.Windows.Forms.GroupBox memGroup;
        private System.Windows.Forms.DataGridView gridMemoria;
        private System.Windows.Forms.FlowLayoutPanel memControlPanel;
        private System.Windows.Forms.Label lblMemAddress;
        private System.Windows.Forms.TextBox txtMemAddress;
        private System.Windows.Forms.Button btnMemGo;
        private System.Windows.Forms.TableLayoutPanel regsAndInfoPanel;
        private System.Windows.Forms.GroupBox regsGroup;
        private System.Windows.Forms.DataGridView gridRegistradores;
        private System.Windows.Forms.GroupBox infoGroup;
        private System.Windows.Forms.TableLayoutPanel infoMainLayout;
        private System.Windows.Forms.TableLayoutPanel metricsPanel;
        private System.Windows.Forms.Panel panelClock;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Label lblClockValor;
        private System.Windows.Forms.Panel panelTempo;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Label lblTempoTotal;
        private System.Windows.Forms.TableLayoutPanel pcPanel;
        private System.Windows.Forms.Label lblPC;
        private System.Windows.Forms.Label lblPCValor;
        private System.Windows.Forms.TableLayoutPanel instructionPanel;
        private System.Windows.Forms.Label lblInstrucao;
        private System.Windows.Forms.TextBox txtInstrucaoAtual;
    }
}