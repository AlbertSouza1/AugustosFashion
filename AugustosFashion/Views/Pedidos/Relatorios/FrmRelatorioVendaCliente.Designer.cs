namespace AugustosFashion.Views.Pedidos.Relatorios
{
    partial class FrmRelatorioVendaCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelatorioVendaCliente));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnFechar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupFiltros = new System.Windows.Forms.GroupBox();
            this.panelListaClientes = new System.Windows.Forms.Panel();
            this.cbAcimaDe = new System.Windows.Forms.ComboBox();
            this.BtnMostrarClientes = new System.Windows.Forms.Button();
            this.BtnLimparCliente = new System.Windows.Forms.Button();
            this.txtValorAcima = new System.Windows.Forms.TextBox();
            this.cbOrdenacao = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnFecharFiltro = new System.Windows.Forms.Button();
            this.BtnFiltrar = new System.Windows.Forms.Button();
            this.BtnBuscarCliente = new System.Windows.Forms.Button();
            this.txtQuantidadeResultados = new System.Windows.Forms.TextBox();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.dgvRelatorioClientes = new System.Windows.Forms.DataGridView();
            this.BtnMostrarFiltros = new System.Windows.Forms.Button();
            this.lblTotalLiquido = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalDesconto = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalBruto = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalCompras = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorioClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFechar.BackColor = System.Drawing.Color.Transparent;
            this.btnFechar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFechar.BackgroundImage")));
            this.btnFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(31, 67);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(43, 36);
            this.btnFechar.TabIndex = 108;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(315, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(331, 30);
            this.label6.TabIndex = 107;
            this.label6.Text = "Relatório de Vendas por Clientes";
            // 
            // groupFiltros
            // 
            this.groupFiltros.BackColor = System.Drawing.Color.LightSlateGray;
            this.groupFiltros.Controls.Add(this.panelListaClientes);
            this.groupFiltros.Controls.Add(this.cbAcimaDe);
            this.groupFiltros.Controls.Add(this.BtnMostrarClientes);
            this.groupFiltros.Controls.Add(this.BtnLimparCliente);
            this.groupFiltros.Controls.Add(this.txtValorAcima);
            this.groupFiltros.Controls.Add(this.cbOrdenacao);
            this.groupFiltros.Controls.Add(this.label13);
            this.groupFiltros.Controls.Add(this.label12);
            this.groupFiltros.Controls.Add(this.label11);
            this.groupFiltros.Controls.Add(this.BtnFecharFiltro);
            this.groupFiltros.Controls.Add(this.BtnFiltrar);
            this.groupFiltros.Controls.Add(this.BtnBuscarCliente);
            this.groupFiltros.Controls.Add(this.txtQuantidadeResultados);
            this.groupFiltros.Controls.Add(this.dtpFinal);
            this.groupFiltros.Controls.Add(this.dtpInicial);
            this.groupFiltros.Controls.Add(this.label3);
            this.groupFiltros.Controls.Add(this.label5);
            this.groupFiltros.Controls.Add(this.label4);
            this.groupFiltros.Controls.Add(this.label2);
            this.groupFiltros.Controls.Add(this.label1);
            this.groupFiltros.Controls.Add(this.lblCliente);
            this.groupFiltros.ForeColor = System.Drawing.Color.Black;
            this.groupFiltros.Location = new System.Drawing.Point(742, -6);
            this.groupFiltros.Name = "groupFiltros";
            this.groupFiltros.Size = new System.Drawing.Size(242, 748);
            this.groupFiltros.TabIndex = 110;
            this.groupFiltros.TabStop = false;
            // 
            // panelListaClientes
            // 
            this.panelListaClientes.Location = new System.Drawing.Point(21, 316);
            this.panelListaClientes.Name = "panelListaClientes";
            this.panelListaClientes.Size = new System.Drawing.Size(200, 198);
            this.panelListaClientes.TabIndex = 115;
            this.panelListaClientes.Visible = false;
            // 
            // cbAcimaDe
            // 
            this.cbAcimaDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAcimaDe.FormattingEnabled = true;
            this.cbAcimaDe.Items.AddRange(new object[] {
            "Nenhum Filtro",
            "Total Compras",
            "Total Bruto",
            "Total Líquido",
            "Total Desconto"});
            this.cbAcimaDe.Location = new System.Drawing.Point(21, 359);
            this.cbAcimaDe.Name = "cbAcimaDe";
            this.cbAcimaDe.Size = new System.Drawing.Size(200, 23);
            this.cbAcimaDe.TabIndex = 118;
            // 
            // BtnMostrarClientes
            // 
            this.BtnMostrarClientes.BackColor = System.Drawing.Color.White;
            this.BtnMostrarClientes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnMostrarClientes.BackgroundImage")));
            this.BtnMostrarClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnMostrarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMostrarClientes.ForeColor = System.Drawing.Color.White;
            this.BtnMostrarClientes.Location = new System.Drawing.Point(165, 295);
            this.BtnMostrarClientes.Name = "BtnMostrarClientes";
            this.BtnMostrarClientes.Size = new System.Drawing.Size(18, 19);
            this.BtnMostrarClientes.TabIndex = 116;
            this.BtnMostrarClientes.UseVisualStyleBackColor = false;
            this.BtnMostrarClientes.Click += new System.EventHandler(this.BtnMostrarClientes_Click);
            // 
            // BtnLimparCliente
            // 
            this.BtnLimparCliente.BackColor = System.Drawing.Color.White;
            this.BtnLimparCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnLimparCliente.BackgroundImage")));
            this.BtnLimparCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnLimparCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimparCliente.ForeColor = System.Drawing.Color.White;
            this.BtnLimparCliente.Location = new System.Drawing.Point(201, 297);
            this.BtnLimparCliente.Name = "BtnLimparCliente";
            this.BtnLimparCliente.Size = new System.Drawing.Size(16, 16);
            this.BtnLimparCliente.TabIndex = 114;
            this.BtnLimparCliente.UseVisualStyleBackColor = false;
            this.BtnLimparCliente.Click += new System.EventHandler(this.BtnLimparCliente_Click);
            // 
            // txtValorAcima
            // 
            this.txtValorAcima.Location = new System.Drawing.Point(21, 410);
            this.txtValorAcima.Name = "txtValorAcima";
            this.txtValorAcima.Size = new System.Drawing.Size(199, 23);
            this.txtValorAcima.TabIndex = 113;
            this.txtValorAcima.Text = "0";
            this.txtValorAcima.Leave += new System.EventHandler(this.txtValorComprado_Leave);
            // 
            // cbOrdenacao
            // 
            this.cbOrdenacao.BackColor = System.Drawing.Color.White;
            this.cbOrdenacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrdenacao.FormattingEnabled = true;
            this.cbOrdenacao.Items.AddRange(new object[] {
            "Nenhum Filtro",
            "Mais vezes comprou",
            "Menos vezes comprou",
            "Maior desconto",
            "Menor desconto",
            "Maior valor líquido",
            "Menor valor líquido"});
            this.cbOrdenacao.Location = new System.Drawing.Point(20, 475);
            this.cbOrdenacao.Name = "cbOrdenacao";
            this.cbOrdenacao.Size = new System.Drawing.Size(200, 23);
            this.cbOrdenacao.TabIndex = 112;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label13.Location = new System.Drawing.Point(21, 390);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 17);
            this.label13.TabIndex = 111;
            this.label13.Text = "Acima de ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label12.Location = new System.Drawing.Point(21, 339);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(151, 17);
            this.label12.TabIndex = 111;
            this.label12.Text = "Apenas resultados com";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label11.Location = new System.Drawing.Point(20, 455);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 17);
            this.label11.TabIndex = 111;
            this.label11.Text = "Ordenar Por";
            // 
            // BtnFecharFiltro
            // 
            this.BtnFecharFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(82)))), ((int)(((byte)(69)))));
            this.BtnFecharFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFecharFiltro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnFecharFiltro.ForeColor = System.Drawing.Color.White;
            this.BtnFecharFiltro.Location = new System.Drawing.Point(188, 20);
            this.BtnFecharFiltro.Name = "BtnFecharFiltro";
            this.BtnFecharFiltro.Size = new System.Drawing.Size(31, 26);
            this.BtnFecharFiltro.TabIndex = 110;
            this.BtnFecharFiltro.Text = "X";
            this.BtnFecharFiltro.UseVisualStyleBackColor = false;
            this.BtnFecharFiltro.Click += new System.EventHandler(this.BtnFecharFiltro_Click);
            // 
            // BtnFiltrar
            // 
            this.BtnFiltrar.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnFiltrar.ForeColor = System.Drawing.Color.White;
            this.BtnFiltrar.Location = new System.Drawing.Point(76, 612);
            this.BtnFiltrar.Name = "BtnFiltrar";
            this.BtnFiltrar.Size = new System.Drawing.Size(94, 29);
            this.BtnFiltrar.TabIndex = 40;
            this.BtnFiltrar.Text = "Filtrar";
            this.BtnFiltrar.UseVisualStyleBackColor = false;
            this.BtnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);
            // 
            // BtnBuscarCliente
            // 
            this.BtnBuscarCliente.BackColor = System.Drawing.Color.White;
            this.BtnBuscarCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnBuscarCliente.BackgroundImage")));
            this.BtnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscarCliente.Font = new System.Drawing.Font("Segoe UI", 9.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnBuscarCliente.ForeColor = System.Drawing.Color.White;
            this.BtnBuscarCliente.Location = new System.Drawing.Point(183, 295);
            this.BtnBuscarCliente.Name = "BtnBuscarCliente";
            this.BtnBuscarCliente.Size = new System.Drawing.Size(18, 19);
            this.BtnBuscarCliente.TabIndex = 39;
            this.BtnBuscarCliente.UseVisualStyleBackColor = false;
            this.BtnBuscarCliente.Click += new System.EventHandler(this.BtnBuscarCliente_Click);
            // 
            // txtQuantidadeResultados
            // 
            this.txtQuantidadeResultados.Location = new System.Drawing.Point(20, 538);
            this.txtQuantidadeResultados.Name = "txtQuantidadeResultados";
            this.txtQuantidadeResultados.Size = new System.Drawing.Size(200, 23);
            this.txtQuantidadeResultados.TabIndex = 4;
            this.txtQuantidadeResultados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidadeResultados_KeyPress);
            // 
            // dtpFinal
            // 
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(20, 232);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(200, 23);
            this.dtpFinal.TabIndex = 3;
            // 
            // dtpInicial
            // 
            this.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicial.Location = new System.Drawing.Point(20, 172);
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.Size = new System.Drawing.Size(200, 23);
            this.dtpInicial.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(20, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cliente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(20, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Data Inicial";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(20, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Data Final";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(20, 518);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantidade de Resultados";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(95, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtros";
            // 
            // lblCliente
            // 
            this.lblCliente.BackColor = System.Drawing.Color.White;
            this.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCliente.Location = new System.Drawing.Point(20, 294);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(200, 22);
            this.lblCliente.TabIndex = 117;
            // 
            // dgvRelatorioClientes
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvRelatorioClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvRelatorioClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRelatorioClientes.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRelatorioClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvRelatorioClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatorioClientes.Location = new System.Drawing.Point(31, 171);
            this.dgvRelatorioClientes.Name = "dgvRelatorioClientes";
            this.dgvRelatorioClientes.ReadOnly = true;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvRelatorioClientes.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvRelatorioClientes.RowTemplate.Height = 25;
            this.dgvRelatorioClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRelatorioClientes.Size = new System.Drawing.Size(921, 368);
            this.dgvRelatorioClientes.TabIndex = 111;
            // 
            // BtnMostrarFiltros
            // 
            this.BtnMostrarFiltros.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnMostrarFiltros.BackgroundImage")));
            this.BtnMostrarFiltros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnMostrarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnMostrarFiltros.Location = new System.Drawing.Point(911, 141);
            this.BtnMostrarFiltros.Name = "BtnMostrarFiltros";
            this.BtnMostrarFiltros.Size = new System.Drawing.Size(39, 27);
            this.BtnMostrarFiltros.TabIndex = 112;
            this.BtnMostrarFiltros.UseVisualStyleBackColor = true;
            this.BtnMostrarFiltros.Click += new System.EventHandler(this.BtnMostrarFiltros_Click);
            // 
            // lblTotalLiquido
            // 
            this.lblTotalLiquido.AutoSize = true;
            this.lblTotalLiquido.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalLiquido.Location = new System.Drawing.Point(805, 615);
            this.lblTotalLiquido.Name = "lblTotalLiquido";
            this.lblTotalLiquido.Size = new System.Drawing.Size(27, 20);
            this.lblTotalLiquido.TabIndex = 117;
            this.lblTotalLiquido.Text = "RS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(705, 615);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 20);
            this.label7.TabIndex = 118;
            this.label7.Text = "Total Líquido:";
            // 
            // lblTotalDesconto
            // 
            this.lblTotalDesconto.AutoSize = true;
            this.lblTotalDesconto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalDesconto.Location = new System.Drawing.Point(583, 615);
            this.lblTotalDesconto.Name = "lblTotalDesconto";
            this.lblTotalDesconto.Size = new System.Drawing.Size(27, 20);
            this.lblTotalDesconto.TabIndex = 119;
            this.lblTotalDesconto.Text = "RS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(472, 615);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 20);
            this.label8.TabIndex = 120;
            this.label8.Text = "Total Desconto:";
            // 
            // lblTotalBruto
            // 
            this.lblTotalBruto.AutoSize = true;
            this.lblTotalBruto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalBruto.Location = new System.Drawing.Point(357, 615);
            this.lblTotalBruto.Name = "lblTotalBruto";
            this.lblTotalBruto.Size = new System.Drawing.Size(27, 20);
            this.lblTotalBruto.TabIndex = 121;
            this.lblTotalBruto.Text = "RS";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(269, 615);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 20);
            this.label10.TabIndex = 122;
            this.label10.Text = "Total Bruto:";
            // 
            // lblTotalCompras
            // 
            this.lblTotalCompras.AutoSize = true;
            this.lblTotalCompras.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalCompras.Location = new System.Drawing.Point(166, 615);
            this.lblTotalCompras.Name = "lblTotalCompras";
            this.lblTotalCompras.Size = new System.Drawing.Size(27, 20);
            this.lblTotalCompras.TabIndex = 124;
            this.lblTotalCompras.Text = "RS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(30, 615);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 20);
            this.label9.TabIndex = 123;
            this.label9.Text = "Total  de Compras:";
            // 
            // FrmRelatorioVendaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(983, 740);
            this.Controls.Add(this.groupFiltros);
            this.Controls.Add(this.lblTotalCompras);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblTotalLiquido);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTotalDesconto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTotalBruto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvRelatorioClientes);
            this.Controls.Add(this.BtnMostrarFiltros);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRelatorioVendaCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRelatorioVendaCliente";
            this.Load += new System.EventHandler(this.FrmRelatorioVendaCliente_Load);
            this.groupFiltros.ResumeLayout(false);
            this.groupFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorioClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupFiltros;
        private System.Windows.Forms.Button BtnFecharFiltro;
        private System.Windows.Forms.Button BtnFiltrar;
        private System.Windows.Forms.Button BtnBuscarCliente;
        private System.Windows.Forms.TextBox txtQuantidadeResultados;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.DateTimePicker dtpInicial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRelatorioClientes;
        private System.Windows.Forms.Button BtnMostrarFiltros;
        private System.Windows.Forms.Label lblTotalLiquido;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalDesconto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalBruto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTotalCompras;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbOrdenacao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtValorAcima;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button BtnLimparCliente;
        private System.Windows.Forms.Panel panelListaClientes;
        private System.Windows.Forms.Button BtnMostrarClientes;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cbAcimaDe;
        private System.Windows.Forms.Label label13;
    }
}