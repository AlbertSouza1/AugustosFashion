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
            this.numPrecoVenda = new System.Windows.Forms.NumericUpDown();
            this.numPrecoCusto = new System.Windows.Forms.NumericUpDown();
            this.numEstoque = new System.Windows.Forms.NumericUpDown();
            this.mtxtPorcentagemLucro = new System.Windows.Forms.MaskedTextBox();
            this.mtxtCodigoBarras = new System.Windows.Forms.MaskedTextBox();
            this.btnCalcularPreco = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoVenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoCusto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEstoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAddEstoque)).BeginInit();
            this.SuspendLayout();
            // 
            // numPrecoVenda
            // 
            this.numPrecoVenda.Location = new System.Drawing.Point(211, 519);
            this.numPrecoVenda.Name = "numPrecoVenda";
            this.numPrecoVenda.Size = new System.Drawing.Size(462, 23);
            this.numPrecoVenda.TabIndex = 150;
            // 
            // numPrecoCusto
            // 
            this.numPrecoCusto.Location = new System.Drawing.Point(211, 400);
            this.numPrecoCusto.Name = "numPrecoCusto";
            this.numPrecoCusto.Size = new System.Drawing.Size(462, 23);
            this.numPrecoCusto.TabIndex = 149;
            // 
            // numEstoque
            // 
            this.numEstoque.Location = new System.Drawing.Point(211, 275);
            this.numEstoque.Name = "numEstoque";
            this.numEstoque.Size = new System.Drawing.Size(176, 23);
            this.numEstoque.TabIndex = 148;
            // 
            // mtxtPorcentagemLucro
            // 
            this.mtxtPorcentagemLucro.Location = new System.Drawing.Point(211, 460);
            this.mtxtPorcentagemLucro.Mask = "000%";
            this.mtxtPorcentagemLucro.Name = "mtxtPorcentagemLucro";
            this.mtxtPorcentagemLucro.Size = new System.Drawing.Size(316, 23);
            this.mtxtPorcentagemLucro.TabIndex = 147;
            // 
            // mtxtCodigoBarras
            // 
            this.mtxtCodigoBarras.Location = new System.Drawing.Point(211, 149);
            this.mtxtCodigoBarras.Mask = "000000000000";
            this.mtxtCodigoBarras.Name = "mtxtCodigoBarras";
            this.mtxtCodigoBarras.Size = new System.Drawing.Size(462, 23);
            this.mtxtCodigoBarras.TabIndex = 146;
            this.mtxtCodigoBarras.ValidatingType = typeof(int);
            // 
            // btnCalcularPreco
            // 
            this.btnCalcularPreco.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCalcularPreco.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCalcularPreco.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCalcularPreco.ForeColor = System.Drawing.Color.White;
            this.btnCalcularPreco.Location = new System.Drawing.Point(533, 460);
            this.btnCalcularPreco.Name = "btnCalcularPreco";
            this.btnCalcularPreco.Size = new System.Drawing.Size(140, 23);
            this.btnCalcularPreco.TabIndex = 145;
            this.btnCalcularPreco.Text = "Calcular\r\n";
            this.btnCalcularPreco.UseVisualStyleBackColor = false;
            this.btnCalcularPreco.Click += new System.EventHandler(this.btnCalcularPreco_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(211, 436);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 21);
            this.label5.TabIndex = 144;
            this.label5.Text = "Lucro desejado em % (opcional)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(95, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(721, 21);
            this.label4.TabIndex = 143;
            this.label4.Text = "É possível calcular o preço de venda especificando a porcentagem de lucro com bas" +
    "e no preço de custo\r\n";
            // 
            // BtnAlterar
            // 
            this.BtnAlterar.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAlterar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnAlterar.ForeColor = System.Drawing.Color.White;
            this.BtnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAlterar.Location = new System.Drawing.Point(225, 593);
            this.BtnAlterar.Name = "BtnAlterar";
            this.BtnAlterar.Size = new System.Drawing.Size(162, 37);
            this.BtnAlterar.TabIndex = 142;
            this.BtnAlterar.Text = "Salvar Alterações";
            this.BtnAlterar.UseVisualStyleBackColor = false;
            this.BtnAlterar.Click += new System.EventHandler(this.BtnAlterar_Click);
            // 
            // txtFabricante
            // 
            this.txtFabricante.Location = new System.Drawing.Point(211, 208);
            this.txtFabricante.Name = "txtFabricante";
            this.txtFabricante.Size = new System.Drawing.Size(462, 23);
            this.txtFabricante.TabIndex = 141;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(211, 90);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(462, 23);
            this.txtNome.TabIndex = 140;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(211, 251);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(176, 21);
            this.label14.TabIndex = 139;
            this.label14.Text = "Quantidade em Estoque";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(211, 184);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 21);
            this.label13.TabIndex = 138;
            this.label13.Text = "Fabricante";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(211, 375);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 21);
            this.label10.TabIndex = 137;
            this.label10.Text = "Preço de Custo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(211, 494);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 21);
            this.label9.TabIndex = 136;
            this.label9.Text = "Preço de Venda";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(211, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 21);
            this.label3.TabIndex = 135;
            this.label3.Text = "Código de Barras";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(211, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 21);
            this.label2.TabIndex = 134;
            this.label2.Text = "Nome do Produto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(350, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 30);
            this.label1.TabIndex = 133;
            this.label1.Text = "Consultar Produto";
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.Red;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcluir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExcluir.ForeColor = System.Drawing.Color.White;
            this.btnExcluir.Location = new System.Drawing.Point(500, 593);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(150, 37);
            this.btnExcluir.TabIndex = 151;
            this.btnExcluir.Text = "Inativar Produto";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // txtIdProduto
            // 
            this.txtIdProduto.Location = new System.Drawing.Point(741, 90);
            this.txtIdProduto.Name = "txtIdProduto";
            this.txtIdProduto.Size = new System.Drawing.Size(50, 23);
            this.txtIdProduto.TabIndex = 152;
            this.txtIdProduto.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(453, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 21);
            this.label6.TabIndex = 153;
            this.label6.Text = "Adicionar ao estoque";
            // 
            // numAddEstoque
            // 
            this.numAddEstoque.Location = new System.Drawing.Point(453, 275);
            this.numAddEstoque.Name = "numAddEstoque";
            this.numAddEstoque.Size = new System.Drawing.Size(156, 23);
            this.numAddEstoque.TabIndex = 154;
            // 
            // btnAdicionarEstoque
            // 
            this.btnAdicionarEstoque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdicionarEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdicionarEstoque.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdicionarEstoque.Location = new System.Drawing.Point(615, 275);
            this.btnAdicionarEstoque.Name = "btnAdicionarEstoque";
            this.btnAdicionarEstoque.Size = new System.Drawing.Size(45, 23);
            this.btnAdicionarEstoque.TabIndex = 155;
            this.btnAdicionarEstoque.Text = "Add";
            this.btnAdicionarEstoque.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdicionarEstoque.UseVisualStyleBackColor = false;
            this.btnAdicionarEstoque.Click += new System.EventHandler(this.btnAdicionarEstoque_Click);
            // 
            // FrmConsultaProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 642);
            this.Controls.Add(this.btnAdicionarEstoque);
            this.Controls.Add(this.numAddEstoque);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIdProduto);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.numPrecoVenda);
            this.Controls.Add(this.numPrecoCusto);
            this.Controls.Add(this.numEstoque);
            this.Controls.Add(this.mtxtPorcentagemLucro);
            this.Controls.Add(this.mtxtCodigoBarras);
            this.Controls.Add(this.btnCalcularPreco);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
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
            this.Name = "FrmConsultaProduto";
            this.Text = "FrmConsultaProduto";
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoVenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoCusto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEstoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAddEstoque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numPrecoVenda;
        private System.Windows.Forms.NumericUpDown numPrecoCusto;
        private System.Windows.Forms.NumericUpDown numEstoque;
        private System.Windows.Forms.MaskedTextBox mtxtPorcentagemLucro;
        private System.Windows.Forms.MaskedTextBox mtxtCodigoBarras;
        private System.Windows.Forms.Button btnCalcularPreco;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
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
    }
}