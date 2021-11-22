namespace AugustosFashion.Views.Pedidos
{
    partial class FrmCadastraPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastraPedido));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dgvCarrinho = new System.Windows.Forms.DataGridView();
            this.txtBuscarProdutos = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.numQuantidade = new System.Windows.Forms.NumericUpDown();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtColaborador = new System.Windows.Forms.TextBox();
            this.txtTotalBruto = new System.Windows.Forms.TextBox();
            this.txtTotalDesconto = new System.Windows.Forms.TextBox();
            this.txtTotalLiquido = new System.Windows.Forms.TextBox();
            this.BtnBuscarProdutos = new System.Windows.Forms.Button();
            this.BtnAdicionarAoCarrinho = new System.Windows.Forms.Button();
            this.BtnFinalizarVenda = new System.Windows.Forms.Button();
            this.txtBuscarColaborador = new System.Windows.Forms.TextBox();
            this.txtBuscaCliente = new System.Windows.Forms.TextBox();
            this.BtnBuscarColaborador = new System.Windows.Forms.Button();
            this.BtnBuscarCliente = new System.Windows.Forms.Button();
            this.BtnRemoverProdutoCarrinho = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.cbFormaPagamento = new System.Windows.Forms.ComboBox();
            this.numDesconto = new System.Windows.Forms.NumericUpDown();
            this.btnFechar = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.lblTotalProduto = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPrecoLiquido = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTotalDescontoProduto = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrinho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDesconto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(441, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Efetuar pedido";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(61, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Produto";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(618, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Selecionar Colaborador";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(618, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Selecionar Cliente";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(300, 640);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Bruto";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(427, 640);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Total Desconto";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(552, 640);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Total Líquido";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(618, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 19);
            this.label8.TabIndex = 10;
            this.label8.Text = "Cliente Selecionado";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(618, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 19);
            this.label9.TabIndex = 11;
            this.label9.Text = "Colaborador selecionado:";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(99, 374);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 21);
            this.label10.TabIndex = 12;
            this.label10.Text = "Carrinho";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(61, 164);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 19);
            this.label11.TabIndex = 13;
            this.label11.Text = "Nome";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(61, 204);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 19);
            this.label12.TabIndex = 14;
            this.label12.Text = "Preço";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(355, 165);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 19);
            this.label13.TabIndex = 15;
            this.label13.Text = "Quantidade";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(355, 204);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 19);
            this.label14.TabIndex = 16;
            this.label14.Text = "Desc. Unit. (R$)";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(61, 428);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 15);
            this.label15.TabIndex = 17;
            // 
            // dgvCarrinho
            // 
            this.dgvCarrinho.AllowUserToResizeColumns = false;
            this.dgvCarrinho.AllowUserToResizeRows = false;
            this.dgvCarrinho.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvCarrinho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarrinho.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCarrinho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrinho.Location = new System.Drawing.Point(61, 399);
            this.dgvCarrinho.MultiSelect = false;
            this.dgvCarrinho.Name = "dgvCarrinho";
            this.dgvCarrinho.ReadOnly = true;
            this.dgvCarrinho.RowTemplate.Height = 25;
            this.dgvCarrinho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarrinho.Size = new System.Drawing.Size(861, 196);
            this.dgvCarrinho.TabIndex = 18;
            // 
            // txtBuscarProdutos
            // 
            this.txtBuscarProdutos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBuscarProdutos.Location = new System.Drawing.Point(155, 125);
            this.txtBuscarProdutos.Name = "txtBuscarProdutos";
            this.txtBuscarProdutos.Size = new System.Drawing.Size(356, 23);
            this.txtBuscarProdutos.TabIndex = 20;
            // 
            // txtNome
            // 
            this.txtNome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNome.Location = new System.Drawing.Point(155, 164);
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(183, 23);
            this.txtNome.TabIndex = 21;
            // 
            // txtPreco
            // 
            this.txtPreco.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPreco.Location = new System.Drawing.Point(155, 203);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.ReadOnly = true;
            this.txtPreco.Size = new System.Drawing.Size(183, 23);
            this.txtPreco.TabIndex = 22;
            // 
            // numQuantidade
            // 
            this.numQuantidade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numQuantidade.Location = new System.Drawing.Point(458, 164);
            this.numQuantidade.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numQuantidade.Name = "numQuantidade";
            this.numQuantidade.Size = new System.Drawing.Size(104, 23);
            this.numQuantidade.TabIndex = 24;
            this.numQuantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantidade.ValueChanged += new System.EventHandler(this.numQuantidade_ValueChanged);
            this.numQuantidade.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numQuantidade_KeyUp);
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCliente.Location = new System.Drawing.Point(618, 174);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(304, 23);
            this.txtCliente.TabIndex = 26;
            // 
            // txtColaborador
            // 
            this.txtColaborador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtColaborador.Location = new System.Drawing.Point(618, 271);
            this.txtColaborador.Name = "txtColaborador";
            this.txtColaborador.ReadOnly = true;
            this.txtColaborador.Size = new System.Drawing.Size(304, 23);
            this.txtColaborador.TabIndex = 27;
            // 
            // txtTotalBruto
            // 
            this.txtTotalBruto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTotalBruto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTotalBruto.Location = new System.Drawing.Point(300, 662);
            this.txtTotalBruto.Name = "txtTotalBruto";
            this.txtTotalBruto.ReadOnly = true;
            this.txtTotalBruto.Size = new System.Drawing.Size(100, 23);
            this.txtTotalBruto.TabIndex = 28;
            // 
            // txtTotalDesconto
            // 
            this.txtTotalDesconto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTotalDesconto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTotalDesconto.Location = new System.Drawing.Point(427, 662);
            this.txtTotalDesconto.Name = "txtTotalDesconto";
            this.txtTotalDesconto.ReadOnly = true;
            this.txtTotalDesconto.Size = new System.Drawing.Size(101, 23);
            this.txtTotalDesconto.TabIndex = 29;
            // 
            // txtTotalLiquido
            // 
            this.txtTotalLiquido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTotalLiquido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTotalLiquido.Location = new System.Drawing.Point(552, 662);
            this.txtTotalLiquido.Name = "txtTotalLiquido";
            this.txtTotalLiquido.ReadOnly = true;
            this.txtTotalLiquido.Size = new System.Drawing.Size(100, 23);
            this.txtTotalLiquido.TabIndex = 30;
            // 
            // BtnBuscarProdutos
            // 
            this.BtnBuscarProdutos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnBuscarProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBuscarProdutos.Font = new System.Drawing.Font("Segoe UI", 9.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnBuscarProdutos.Location = new System.Drawing.Point(507, 125);
            this.BtnBuscarProdutos.Name = "BtnBuscarProdutos";
            this.BtnBuscarProdutos.Size = new System.Drawing.Size(55, 23);
            this.BtnBuscarProdutos.TabIndex = 31;
            this.BtnBuscarProdutos.Text = "🔍";
            this.BtnBuscarProdutos.UseVisualStyleBackColor = true;
            this.BtnBuscarProdutos.Click += new System.EventHandler(this.BtnBuscarProdutos_Click_1);
            // 
            // BtnAdicionarAoCarrinho
            // 
            this.BtnAdicionarAoCarrinho.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnAdicionarAoCarrinho.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnAdicionarAoCarrinho.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAdicionarAoCarrinho.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnAdicionarAoCarrinho.ForeColor = System.Drawing.Color.White;
            this.BtnAdicionarAoCarrinho.Location = new System.Drawing.Point(359, 291);
            this.BtnAdicionarAoCarrinho.Name = "BtnAdicionarAoCarrinho";
            this.BtnAdicionarAoCarrinho.Size = new System.Drawing.Size(203, 29);
            this.BtnAdicionarAoCarrinho.TabIndex = 32;
            this.BtnAdicionarAoCarrinho.Text = "Adicionar ao carrinho 🛒";
            this.BtnAdicionarAoCarrinho.UseVisualStyleBackColor = false;
            this.BtnAdicionarAoCarrinho.Click += new System.EventHandler(this.BtnAdicionarAoCarrinho_Click);
            // 
            // BtnFinalizarVenda
            // 
            this.BtnFinalizarVenda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnFinalizarVenda.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnFinalizarVenda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnFinalizarVenda.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnFinalizarVenda.ForeColor = System.Drawing.Color.White;
            this.BtnFinalizarVenda.Location = new System.Drawing.Point(739, 655);
            this.BtnFinalizarVenda.Name = "BtnFinalizarVenda";
            this.BtnFinalizarVenda.Size = new System.Drawing.Size(183, 31);
            this.BtnFinalizarVenda.TabIndex = 33;
            this.BtnFinalizarVenda.Text = "Finalizar Venda";
            this.BtnFinalizarVenda.UseVisualStyleBackColor = false;
            this.BtnFinalizarVenda.Click += new System.EventHandler(this.BtnFinalizarVenda_Click);
            // 
            // txtBuscarColaborador
            // 
            this.txtBuscarColaborador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBuscarColaborador.Location = new System.Drawing.Point(766, 218);
            this.txtBuscarColaborador.Name = "txtBuscarColaborador";
            this.txtBuscarColaborador.Size = new System.Drawing.Size(117, 23);
            this.txtBuscarColaborador.TabIndex = 34;
            // 
            // txtBuscaCliente
            // 
            this.txtBuscaCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBuscaCliente.Location = new System.Drawing.Point(770, 126);
            this.txtBuscaCliente.Name = "txtBuscaCliente";
            this.txtBuscaCliente.Size = new System.Drawing.Size(113, 23);
            this.txtBuscaCliente.TabIndex = 35;
            // 
            // BtnBuscarColaborador
            // 
            this.BtnBuscarColaborador.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBuscarColaborador.Font = new System.Drawing.Font("Segoe UI", 9.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnBuscarColaborador.Location = new System.Drawing.Point(882, 218);
            this.BtnBuscarColaborador.Name = "BtnBuscarColaborador";
            this.BtnBuscarColaborador.Size = new System.Drawing.Size(40, 23);
            this.BtnBuscarColaborador.TabIndex = 36;
            this.BtnBuscarColaborador.Text = "🔍";
            this.BtnBuscarColaborador.UseVisualStyleBackColor = true;
            this.BtnBuscarColaborador.Click += new System.EventHandler(this.BtnBuscarColaborador_Click);
            // 
            // BtnBuscarCliente
            // 
            this.BtnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBuscarCliente.Font = new System.Drawing.Font("Segoe UI", 9.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnBuscarCliente.Location = new System.Drawing.Point(882, 126);
            this.BtnBuscarCliente.Name = "BtnBuscarCliente";
            this.BtnBuscarCliente.Size = new System.Drawing.Size(40, 23);
            this.BtnBuscarCliente.TabIndex = 37;
            this.BtnBuscarCliente.Text = "🔍";
            this.BtnBuscarCliente.UseVisualStyleBackColor = true;
            this.BtnBuscarCliente.Click += new System.EventHandler(this.BtnBuscarCliente_Click);
            // 
            // BtnRemoverProdutoCarrinho
            // 
            this.BtnRemoverProdutoCarrinho.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnRemoverProdutoCarrinho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(82)))), ((int)(((byte)(69)))));
            this.BtnRemoverProdutoCarrinho.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnRemoverProdutoCarrinho.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnRemoverProdutoCarrinho.ForeColor = System.Drawing.Color.White;
            this.BtnRemoverProdutoCarrinho.Location = new System.Drawing.Point(61, 601);
            this.BtnRemoverProdutoCarrinho.Name = "BtnRemoverProdutoCarrinho";
            this.BtnRemoverProdutoCarrinho.Size = new System.Drawing.Size(88, 23);
            this.BtnRemoverProdutoCarrinho.TabIndex = 39;
            this.BtnRemoverProdutoCarrinho.Text = "Remover";
            this.BtnRemoverProdutoCarrinho.UseVisualStyleBackColor = false;
            this.BtnRemoverProdutoCarrinho.Click += new System.EventHandler(this.BtnRemoverProdutoCarrinho_Click);
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(614, 329);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(141, 19);
            this.label16.TabIndex = 40;
            this.label16.Text = "Forma de Pagamento";
            // 
            // cbFormaPagamento
            // 
            this.cbFormaPagamento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormaPagamento.FormattingEnabled = true;
            this.cbFormaPagamento.Items.AddRange(new object[] {
            "À vista no dinheiro",
            "Á prazo",
            "Crédito",
            "Débito",
            "Pix"});
            this.cbFormaPagamento.Location = new System.Drawing.Point(781, 325);
            this.cbFormaPagamento.Name = "cbFormaPagamento";
            this.cbFormaPagamento.Size = new System.Drawing.Size(141, 23);
            this.cbFormaPagamento.TabIndex = 41;
            // 
            // numDesconto
            // 
            this.numDesconto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numDesconto.DecimalPlaces = 2;
            this.numDesconto.Location = new System.Drawing.Point(458, 204);
            this.numDesconto.Name = "numDesconto";
            this.numDesconto.Size = new System.Drawing.Size(104, 23);
            this.numDesconto.TabIndex = 42;
            this.numDesconto.ValueChanged += new System.EventHandler(this.numDesconto_ValueChanged);
            this.numDesconto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numDesconto_KeyUp);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFechar.BackColor = System.Drawing.Color.Transparent;
            this.btnFechar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFechar.BackgroundImage")));
            this.btnFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(61, 59);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(43, 36);
            this.btnFechar.TabIndex = 43;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(61, 295);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(109, 20);
            this.label17.TabIndex = 44;
            this.label17.Text = "Total Produto:";
            // 
            // lblTotalProduto
            // 
            this.lblTotalProduto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalProduto.AutoSize = true;
            this.lblTotalProduto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalProduto.Location = new System.Drawing.Point(176, 295);
            this.lblTotalProduto.Name = "lblTotalProduto";
            this.lblTotalProduto.Size = new System.Drawing.Size(63, 20);
            this.lblTotalProduto.TabIndex = 45;
            this.lblTotalProduto.Text = "R$ 0,00";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(61, 243);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 19);
            this.label18.TabIndex = 46;
            this.label18.Text = "Preço Líquido";
            // 
            // txtPrecoLiquido
            // 
            this.txtPrecoLiquido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPrecoLiquido.Location = new System.Drawing.Point(155, 242);
            this.txtPrecoLiquido.Name = "txtPrecoLiquido";
            this.txtPrecoLiquido.ReadOnly = true;
            this.txtPrecoLiquido.Size = new System.Drawing.Size(183, 23);
            this.txtPrecoLiquido.TabIndex = 47;
            this.txtPrecoLiquido.Text = "0";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(355, 243);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 19);
            this.label19.TabIndex = 48;
            this.label19.Text = "Total Desconto";
            // 
            // txtTotalDescontoProduto
            // 
            this.txtTotalDescontoProduto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTotalDescontoProduto.Location = new System.Drawing.Point(458, 242);
            this.txtTotalDescontoProduto.Name = "txtTotalDescontoProduto";
            this.txtTotalDescontoProduto.ReadOnly = true;
            this.txtTotalDescontoProduto.Size = new System.Drawing.Size(104, 23);
            this.txtTotalDescontoProduto.TabIndex = 49;
            this.txtTotalDescontoProduto.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label20.Location = new System.Drawing.Point(61, 367);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(39, 28);
            this.label20.TabIndex = 50;
            this.label20.Text = "🛒";
            // 
            // FrmCadastraPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(983, 740);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtTotalDescontoProduto);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtPrecoLiquido);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblTotalProduto);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.numDesconto);
            this.Controls.Add(this.cbFormaPagamento);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.BtnRemoverProdutoCarrinho);
            this.Controls.Add(this.BtnBuscarCliente);
            this.Controls.Add(this.BtnBuscarColaborador);
            this.Controls.Add(this.txtBuscaCliente);
            this.Controls.Add(this.txtBuscarColaborador);
            this.Controls.Add(this.BtnFinalizarVenda);
            this.Controls.Add(this.BtnAdicionarAoCarrinho);
            this.Controls.Add(this.BtnBuscarProdutos);
            this.Controls.Add(this.txtTotalLiquido);
            this.Controls.Add(this.txtTotalDesconto);
            this.Controls.Add(this.txtTotalBruto);
            this.Controls.Add(this.txtColaborador);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.numQuantidade);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtBuscarProdutos);
            this.Controls.Add(this.dgvCarrinho);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCadastraPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCadastraPedido";
            this.Load += new System.EventHandler(this.FrmCadastraPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrinho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDesconto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dgvCarrinho;
        private System.Windows.Forms.TextBox txtBuscarProdutos;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.NumericUpDown numQuantidade;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtColaborador;
        private System.Windows.Forms.TextBox txtTotalBruto;
        private System.Windows.Forms.TextBox txtTotalDesconto;
        private System.Windows.Forms.TextBox txtTotalLiquido;
        private System.Windows.Forms.Button BtnBuscarProdutos;
        private System.Windows.Forms.Button BtnAdicionarAoCarrinho;
        private System.Windows.Forms.Button BtnFinalizarVenda;
        private System.Windows.Forms.TextBox txtBuscarColaborador;
        private System.Windows.Forms.TextBox txtBuscaCliente;
        private System.Windows.Forms.Button BtnBuscarColaborador;
        private System.Windows.Forms.Button BtnBuscarCliente;
        private System.Windows.Forms.Button BtnRemoverProdutoCarrinho;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbFormaPagamento;
        private System.Windows.Forms.NumericUpDown numDesconto;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblTotalProduto;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtPrecoLiquido;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtTotalDescontoProduto;
        private System.Windows.Forms.Label label20;
    }
}