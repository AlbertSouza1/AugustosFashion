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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvBuscaCliente = new System.Windows.Forms.DataGridView();
            this.dgvBuscaColaborador = new System.Windows.Forms.DataGridView();
            this.dgvBuscaProdutos = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dgvCarrinho = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBuscarProdutos = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.numQuantidade = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtColaborador = new System.Windows.Forms.TextBox();
            this.txtTotalBruto = new System.Windows.Forms.TextBox();
            this.txtTotalDesconto = new System.Windows.Forms.TextBox();
            this.txtTotalLiquido = new System.Windows.Forms.TextBox();
            this.BtnBuscarProdutos = new System.Windows.Forms.Button();
            this.BtnAdicionarAoCarrinho = new System.Windows.Forms.Button();
            this.BtnFinalizarVenda = new System.Windows.Forms.Button();
            this.txtBuscarColaborador = new System.Windows.Forms.TextBox();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.BtnBuscarColaborador = new System.Windows.Forms.Button();
            this.BtnBuscarCliente = new System.Windows.Forms.Button();
            this.BtnCalcularTotais = new System.Windows.Forms.Button();
            this.BtnRemoverProdutoCarrinho = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscaCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscaColaborador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscaProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrinho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(402, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Efetuar pedido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(34, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Produtos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(519, 408);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Selecionar Colaborador";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(34, 408);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Selecionar Cliente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(134, 595);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Bruto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(232, 595);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Total de Desconto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(360, 595);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Total Líquido";
            // 
            // dgvBuscaCliente
            // 
            this.dgvBuscaCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuscaCliente.Location = new System.Drawing.Point(34, 432);
            this.dgvBuscaCliente.Name = "dgvBuscaCliente";
            this.dgvBuscaCliente.ReadOnly = true;
            this.dgvBuscaCliente.RowTemplate.Height = 25;
            this.dgvBuscaCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBuscaCliente.Size = new System.Drawing.Size(413, 55);
            this.dgvBuscaCliente.TabIndex = 7;
            // 
            // dgvBuscaColaborador
            // 
            this.dgvBuscaColaborador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuscaColaborador.Location = new System.Drawing.Point(519, 430);
            this.dgvBuscaColaborador.Name = "dgvBuscaColaborador";
            this.dgvBuscaColaborador.ReadOnly = true;
            this.dgvBuscaColaborador.RowTemplate.Height = 25;
            this.dgvBuscaColaborador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBuscaColaborador.Size = new System.Drawing.Size(419, 55);
            this.dgvBuscaColaborador.TabIndex = 8;
            // 
            // dgvBuscaProdutos
            // 
            this.dgvBuscaProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBuscaProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuscaProdutos.Location = new System.Drawing.Point(34, 103);
            this.dgvBuscaProdutos.Name = "dgvBuscaProdutos";
            this.dgvBuscaProdutos.ReadOnly = true;
            this.dgvBuscaProdutos.RowTemplate.Height = 25;
            this.dgvBuscaProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBuscaProdutos.Size = new System.Drawing.Size(413, 70);
            this.dgvBuscaProdutos.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(34, 506);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 19);
            this.label8.TabIndex = 10;
            this.label8.Text = "Cliente selecionado:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(519, 506);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 19);
            this.label9.TabIndex = 11;
            this.label9.Text = "Colaborador selecionado:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(519, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 19);
            this.label10.TabIndex = 12;
            this.label10.Text = "Carrinho";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(45, 230);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 19);
            this.label11.TabIndex = 13;
            this.label11.Text = "Nome";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(279, 230);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 19);
            this.label12.TabIndex = 14;
            this.label12.Text = "Preço";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(279, 288);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 19);
            this.label13.TabIndex = 15;
            this.label13.Text = "Quantidade";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(45, 288);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(153, 19);
            this.label14.TabIndex = 16;
            this.label14.Text = "Desconto (por unidade)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(45, 352);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 15);
            this.label15.TabIndex = 17;
            // 
            // dgvCarrinho
            // 
            this.dgvCarrinho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCarrinho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrinho.Location = new System.Drawing.Point(519, 103);
            this.dgvCarrinho.Name = "dgvCarrinho";
            this.dgvCarrinho.ReadOnly = true;
            this.dgvCarrinho.RowTemplate.Height = 25;
            this.dgvCarrinho.Size = new System.Drawing.Size(419, 225);
            this.dgvCarrinho.TabIndex = 18;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(221, 83);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 19);
            this.label16.TabIndex = 19;
            this.label16.Text = "Buscar:";
            // 
            // txtBuscarProdutos
            // 
            this.txtBuscarProdutos.Location = new System.Drawing.Point(279, 79);
            this.txtBuscarProdutos.Name = "txtBuscarProdutos";
            this.txtBuscarProdutos.Size = new System.Drawing.Size(127, 23);
            this.txtBuscarProdutos.TabIndex = 20;
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Location = new System.Drawing.Point(45, 252);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(182, 23);
            this.txtNome.TabIndex = 21;
            // 
            // txtPreco
            // 
            this.txtPreco.Enabled = false;
            this.txtPreco.Location = new System.Drawing.Point(279, 252);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(168, 23);
            this.txtPreco.TabIndex = 22;
            // 
            // txtDesconto
            // 
            this.txtDesconto.Location = new System.Drawing.Point(45, 310);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(182, 23);
            this.txtDesconto.TabIndex = 23;
            // 
            // numQuantidade
            // 
            this.numQuantidade.Location = new System.Drawing.Point(279, 310);
            this.numQuantidade.Name = "numQuantidade";
            this.numQuantidade.Size = new System.Drawing.Size(168, 23);
            this.numQuantidade.TabIndex = 24;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(151, 199);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(185, 20);
            this.label17.TabIndex = 25;
            this.label17.Text = "Editar valores para venda";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(34, 528);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(288, 23);
            this.txtCliente.TabIndex = 26;
            // 
            // txtColaborador
            // 
            this.txtColaborador.Enabled = false;
            this.txtColaborador.Location = new System.Drawing.Point(519, 528);
            this.txtColaborador.Name = "txtColaborador";
            this.txtColaborador.Size = new System.Drawing.Size(288, 23);
            this.txtColaborador.TabIndex = 27;
            // 
            // txtTotalBruto
            // 
            this.txtTotalBruto.Enabled = false;
            this.txtTotalBruto.Location = new System.Drawing.Point(134, 621);
            this.txtTotalBruto.Name = "txtTotalBruto";
            this.txtTotalBruto.Size = new System.Drawing.Size(100, 23);
            this.txtTotalBruto.TabIndex = 28;
            // 
            // txtTotalDesconto
            // 
            this.txtTotalDesconto.Enabled = false;
            this.txtTotalDesconto.Location = new System.Drawing.Point(244, 621);
            this.txtTotalDesconto.Name = "txtTotalDesconto";
            this.txtTotalDesconto.Size = new System.Drawing.Size(101, 23);
            this.txtTotalDesconto.TabIndex = 29;
            // 
            // txtTotalLiquido
            // 
            this.txtTotalLiquido.Enabled = false;
            this.txtTotalLiquido.Location = new System.Drawing.Point(360, 621);
            this.txtTotalLiquido.Name = "txtTotalLiquido";
            this.txtTotalLiquido.Size = new System.Drawing.Size(100, 23);
            this.txtTotalLiquido.TabIndex = 30;
            // 
            // BtnBuscarProdutos
            // 
            this.BtnBuscarProdutos.Font = new System.Drawing.Font("Segoe UI", 9.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnBuscarProdutos.Location = new System.Drawing.Point(402, 79);
            this.BtnBuscarProdutos.Name = "BtnBuscarProdutos";
            this.BtnBuscarProdutos.Size = new System.Drawing.Size(45, 24);
            this.BtnBuscarProdutos.TabIndex = 31;
            this.BtnBuscarProdutos.Text = "🔍";
            this.BtnBuscarProdutos.UseVisualStyleBackColor = true;
            //this.BtnBuscarProdutos.Click += new System.EventHandler(this.BtnBuscarProdutos_Click);
            // 
            // BtnAdicionarAoCarrinho
            // 
            this.BtnAdicionarAoCarrinho.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnAdicionarAoCarrinho.Location = new System.Drawing.Point(142, 344);
            this.BtnAdicionarAoCarrinho.Name = "BtnAdicionarAoCarrinho";
            this.BtnAdicionarAoCarrinho.Size = new System.Drawing.Size(203, 29);
            this.BtnAdicionarAoCarrinho.TabIndex = 32;
            this.BtnAdicionarAoCarrinho.Text = "Adicionar ao carrinho 🛒";
            this.BtnAdicionarAoCarrinho.UseVisualStyleBackColor = true;
            // 
            // BtnFinalizarVenda
            // 
            this.BtnFinalizarVenda.Location = new System.Drawing.Point(631, 615);
            this.BtnFinalizarVenda.Name = "BtnFinalizarVenda";
            this.BtnFinalizarVenda.Size = new System.Drawing.Size(223, 29);
            this.BtnFinalizarVenda.TabIndex = 33;
            this.BtnFinalizarVenda.Text = "Finalizar Venda";
            this.BtnFinalizarVenda.UseVisualStyleBackColor = true;
            // 
            // txtBuscarColaborador
            // 
            this.txtBuscarColaborador.Location = new System.Drawing.Point(774, 408);
            this.txtBuscarColaborador.Name = "txtBuscarColaborador";
            this.txtBuscarColaborador.Size = new System.Drawing.Size(117, 23);
            this.txtBuscarColaborador.TabIndex = 34;
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.Location = new System.Drawing.Point(297, 408);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(113, 23);
            this.txtBuscarCliente.TabIndex = 35;
            // 
            // BtnBuscarColaborador
            // 
            this.BtnBuscarColaborador.Font = new System.Drawing.Font("Segoe UI", 9.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnBuscarColaborador.Location = new System.Drawing.Point(893, 406);
            this.BtnBuscarColaborador.Name = "BtnBuscarColaborador";
            this.BtnBuscarColaborador.Size = new System.Drawing.Size(45, 23);
            this.BtnBuscarColaborador.TabIndex = 36;
            this.BtnBuscarColaborador.Text = "🔍";
            this.BtnBuscarColaborador.UseVisualStyleBackColor = true;
            // 
            // BtnBuscarCliente
            // 
            this.BtnBuscarCliente.Font = new System.Drawing.Font("Segoe UI", 9.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnBuscarCliente.Location = new System.Drawing.Point(407, 408);
            this.BtnBuscarCliente.Name = "BtnBuscarCliente";
            this.BtnBuscarCliente.Size = new System.Drawing.Size(40, 23);
            this.BtnBuscarCliente.TabIndex = 37;
            this.BtnBuscarCliente.Text = "🔍";
            this.BtnBuscarCliente.UseVisualStyleBackColor = true;
            // 
            // BtnCalcularTotais
            // 
            this.BtnCalcularTotais.Location = new System.Drawing.Point(34, 596);
            this.BtnCalcularTotais.Name = "BtnCalcularTotais";
            this.BtnCalcularTotais.Size = new System.Drawing.Size(75, 48);
            this.BtnCalcularTotais.TabIndex = 38;
            this.BtnCalcularTotais.Text = "Calcular Totais";
            this.BtnCalcularTotais.UseVisualStyleBackColor = true;
            // 
            // BtnRemoverProdutoCarrinho
            // 
            this.BtnRemoverProdutoCarrinho.Location = new System.Drawing.Point(519, 334);
            this.BtnRemoverProdutoCarrinho.Name = "BtnRemoverProdutoCarrinho";
            this.BtnRemoverProdutoCarrinho.Size = new System.Drawing.Size(181, 23);
            this.BtnRemoverProdutoCarrinho.TabIndex = 39;
            this.BtnRemoverProdutoCarrinho.Text = "Remover Produto Selecionado";
            this.BtnRemoverProdutoCarrinho.UseVisualStyleBackColor = true;
            // 
            // FrmCadastraPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 682);
            this.Controls.Add(this.BtnRemoverProdutoCarrinho);
            this.Controls.Add(this.BtnCalcularTotais);
            this.Controls.Add(this.BtnBuscarCliente);
            this.Controls.Add(this.BtnBuscarColaborador);
            this.Controls.Add(this.txtBuscarCliente);
            this.Controls.Add(this.txtBuscarColaborador);
            this.Controls.Add(this.BtnFinalizarVenda);
            this.Controls.Add(this.BtnAdicionarAoCarrinho);
            this.Controls.Add(this.BtnBuscarProdutos);
            this.Controls.Add(this.txtTotalLiquido);
            this.Controls.Add(this.txtTotalDesconto);
            this.Controls.Add(this.txtTotalBruto);
            this.Controls.Add(this.txtColaborador);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.numQuantidade);
            this.Controls.Add(this.txtDesconto);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtBuscarProdutos);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dgvCarrinho);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvBuscaProdutos);
            this.Controls.Add(this.dgvBuscaColaborador);
            this.Controls.Add(this.dgvBuscaCliente);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmCadastraPedido";
            this.Text = "FrmCadastraPedido";
            this.Load += new System.EventHandler(this.FrmCadastraPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscaCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscaColaborador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscaProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrinho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvBuscaCliente;
        private System.Windows.Forms.DataGridView dgvBuscaColaborador;
        private System.Windows.Forms.DataGridView dgvBuscaProdutos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dgvCarrinho;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBuscarProdutos;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.NumericUpDown numQuantidade;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtColaborador;
        private System.Windows.Forms.TextBox txtTotalBruto;
        private System.Windows.Forms.TextBox txtTotalDesconto;
        private System.Windows.Forms.TextBox txtTotalLiquido;
        private System.Windows.Forms.Button BtnBuscarProdutos;
        private System.Windows.Forms.Button BtnAdicionarAoCarrinho;
        private System.Windows.Forms.Button BtnFinalizarVenda;
        private System.Windows.Forms.TextBox txtBuscarColaborador;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.Button BtnBuscarColaborador;
        private System.Windows.Forms.Button BtnBuscarCliente;
        private System.Windows.Forms.Button BtnCalcularTotais;
        private System.Windows.Forms.Button BtnRemoverProdutoCarrinho;
    }
}