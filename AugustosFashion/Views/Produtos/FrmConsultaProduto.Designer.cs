namespace AugustosFashion.Views.Produtos
{
    partial class FrmConsultaProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaProduto));
            this.numPrecoVenda = new System.Windows.Forms.NumericUpDown();
            this.numPrecoCusto = new System.Windows.Forms.NumericUpDown();
            this.numEstoque = new System.Windows.Forms.NumericUpDown();
            this.mtxtCodigoBarras = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnAlterar = new System.Windows.Forms.Button();
            this.txtFabricante = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.txtIdProduto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numAddEstoque = new System.Windows.Forms.NumericUpDown();
            this.btnAdicionarEstoque = new System.Windows.Forms.Button();
            this.btnAtivarProduto = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.numPorcentagemLucro = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoVenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoCusto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEstoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAddEstoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcentagemLucro)).BeginInit();
            this.SuspendLayout();
            // 
            // numPrecoVenda
            // 
            this.numPrecoVenda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numPrecoVenda.DecimalPlaces = 2;
            this.numPrecoVenda.Location = new System.Drawing.Point(244, 537);
            this.numPrecoVenda.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numPrecoVenda.Name = "numPrecoVenda";
            this.numPrecoVenda.Size = new System.Drawing.Size(462, 23);
            this.numPrecoVenda.TabIndex = 8;
            this.numPrecoVenda.ValueChanged += new System.EventHandler(this.numPrecoVenda_ValueChanged);
            this.numPrecoVenda.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numPrecoVenda_KeyUp);
            // 
            // numPrecoCusto
            // 
            this.numPrecoCusto.DecimalPlaces = 2;
            this.numPrecoCusto.Location = new System.Drawing.Point(244, 418);
            this.numPrecoCusto.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numPrecoCusto.Name = "numPrecoCusto";
            this.numPrecoCusto.Size = new System.Drawing.Size(462, 23);
            this.numPrecoCusto.TabIndex = 6;
            this.numPrecoCusto.ValueChanged += new System.EventHandler(this.numPrecoCusto_ValueChanged);
            this.numPrecoCusto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numPrecoCusto_KeyUp);
            // 
            // numEstoque
            // 
            this.numEstoque.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numEstoque.Enabled = false;
            this.numEstoque.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numEstoque.Location = new System.Drawing.Point(244, 356);
            this.numEstoque.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numEstoque.Name = "numEstoque";
            this.numEstoque.ReadOnly = true;
            this.numEstoque.Size = new System.Drawing.Size(176, 23);
            this.numEstoque.TabIndex = 4;
            // 
            // mtxtCodigoBarras
            // 
            this.mtxtCodigoBarras.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mtxtCodigoBarras.Location = new System.Drawing.Point(244, 230);
            this.mtxtCodigoBarras.Mask = "000000000000";
            this.mtxtCodigoBarras.Name = "mtxtCodigoBarras";
            this.mtxtCodigoBarras.Size = new System.Drawing.Size(462, 23);
            this.mtxtCodigoBarras.TabIndex = 2;
            this.mtxtCodigoBarras.ValidatingType = typeof(int);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(244, 454);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 21);
            this.label5.TabIndex = 144;
            this.label5.Text = "Lucro desejado em %";
            // 
            // BtnAlterar
            // 
            this.BtnAlterar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnAlterar.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAlterar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnAlterar.ForeColor = System.Drawing.Color.White;
            this.BtnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAlterar.Location = new System.Drawing.Point(261, 642);
            this.BtnAlterar.Name = "BtnAlterar";
            this.BtnAlterar.Size = new System.Drawing.Size(162, 37);
            this.BtnAlterar.TabIndex = 142;
            this.BtnAlterar.Text = "Salvar Alterações";
            this.BtnAlterar.UseVisualStyleBackColor = false;
            this.BtnAlterar.Click += new System.EventHandler(this.BtnAlterar_Click);
            // 
            // txtFabricante
            // 
            this.txtFabricante.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFabricante.Location = new System.Drawing.Point(244, 289);
            this.txtFabricante.MaxLength = 50;
            this.txtFabricante.Name = "txtFabricante";
            this.txtFabricante.Size = new System.Drawing.Size(462, 23);
            this.txtFabricante.TabIndex = 3;
            // 
            // txtNome
            // 
            this.txtNome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNome.Location = new System.Drawing.Point(244, 171);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(462, 23);
            this.txtNome.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(244, 332);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(176, 21);
            this.label14.TabIndex = 139;
            this.label14.Text = "Quantidade em Estoque";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(244, 265);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 21);
            this.label13.TabIndex = 138;
            this.label13.Text = "Fabricante";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(244, 393);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 21);
            this.label10.TabIndex = 137;
            this.label10.Text = "Preço de Custo";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(244, 512);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 21);
            this.label9.TabIndex = 136;
            this.label9.Text = "Preço de Venda";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(244, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 21);
            this.label3.TabIndex = 135;
            this.label3.Text = "Código de Barras";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(244, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 21);
            this.label2.TabIndex = 134;
            this.label2.Text = "Nome do Produto";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(386, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 30);
            this.label1.TabIndex = 133;
            this.label1.Text = "Consultar Produto";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcluir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExcluir.ForeColor = System.Drawing.Color.White;
            this.btnExcluir.Location = new System.Drawing.Point(536, 642);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(150, 37);
            this.btnExcluir.TabIndex = 151;
            this.btnExcluir.Text = "Inativar Produto";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // txtIdProduto
            // 
            this.txtIdProduto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIdProduto.Location = new System.Drawing.Point(764, 171);
            this.txtIdProduto.Name = "txtIdProduto";
            this.txtIdProduto.Size = new System.Drawing.Size(50, 23);
            this.txtIdProduto.TabIndex = 152;
            this.txtIdProduto.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(486, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 21);
            this.label6.TabIndex = 153;
            this.label6.Text = "Adicionar ao estoque";
            // 
            // numAddEstoque
            // 
            this.numAddEstoque.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numAddEstoque.Location = new System.Drawing.Point(486, 356);
            this.numAddEstoque.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numAddEstoque.Name = "numAddEstoque";
            this.numAddEstoque.Size = new System.Drawing.Size(156, 23);
            this.numAddEstoque.TabIndex = 5;
            // 
            // btnAdicionarEstoque
            // 
            this.btnAdicionarEstoque.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdicionarEstoque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdicionarEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdicionarEstoque.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdicionarEstoque.Location = new System.Drawing.Point(648, 356);
            this.btnAdicionarEstoque.Name = "btnAdicionarEstoque";
            this.btnAdicionarEstoque.Size = new System.Drawing.Size(58, 23);
            this.btnAdicionarEstoque.TabIndex = 155;
            this.btnAdicionarEstoque.Text = "Add";
            this.btnAdicionarEstoque.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdicionarEstoque.UseVisualStyleBackColor = false;
            this.btnAdicionarEstoque.Click += new System.EventHandler(this.btnAdicionarEstoque_Click);
            // 
            // btnAtivarProduto
            // 
            this.btnAtivarProduto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAtivarProduto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAtivarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAtivarProduto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAtivarProduto.Location = new System.Drawing.Point(536, 642);
            this.btnAtivarProduto.Name = "btnAtivarProduto";
            this.btnAtivarProduto.Size = new System.Drawing.Size(150, 37);
            this.btnAtivarProduto.TabIndex = 156;
            this.btnAtivarProduto.Text = "Ativar Produto";
            this.btnAtivarProduto.UseVisualStyleBackColor = false;
            this.btnAtivarProduto.Visible = false;
            this.btnAtivarProduto.Click += new System.EventHandler(this.btnAtivarProduto_Click);
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
            this.btnFechar.Location = new System.Drawing.Point(81, 61);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(43, 36);
            this.btnFechar.TabIndex = 157;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // numPorcentagemLucro
            // 
            this.numPorcentagemLucro.Location = new System.Drawing.Point(244, 478);
            this.numPorcentagemLucro.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPorcentagemLucro.Name = "numPorcentagemLucro";
            this.numPorcentagemLucro.Size = new System.Drawing.Size(462, 23);
            this.numPorcentagemLucro.TabIndex = 7;
            this.numPorcentagemLucro.ValueChanged += new System.EventHandler(this.numPorcentagemLucro_ValueChanged);
            this.numPorcentagemLucro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numPorcentagemLucro_KeyUp);
            // 
            // FrmConsultaProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(983, 740);
            this.Controls.Add(this.numPorcentagemLucro);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnAtivarProduto);
            this.Controls.Add(this.btnAdicionarEstoque);
            this.Controls.Add(this.numAddEstoque);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIdProduto);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.numPrecoVenda);
            this.Controls.Add(this.numPrecoCusto);
            this.Controls.Add(this.numEstoque);
            this.Controls.Add(this.mtxtCodigoBarras);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnAlterar);
            this.Controls.Add(this.txtFabricante);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConsultaProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConsultaProduto";
            this.Load += new System.EventHandler(this.FrmConsultaProduto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoVenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoCusto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEstoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAddEstoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcentagemLucro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numPrecoVenda;
        private System.Windows.Forms.NumericUpDown numPrecoCusto;
        private System.Windows.Forms.NumericUpDown numEstoque;
        private System.Windows.Forms.MaskedTextBox mtxtCodigoBarras;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.TextBox txtFabricante;
        internal System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.TextBox txtIdProduto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numAddEstoque;
        private System.Windows.Forms.Button btnAdicionarEstoque;
        private System.Windows.Forms.Button btnAtivarProduto;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.NumericUpDown numPorcentagemLucro;
    }
}