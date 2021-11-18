namespace AugustosFashion.Views.Pedidos
{
    partial class FrmBuscaProdutos
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
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarProdutos = new System.Windows.Forms.TextBox();
            this.BtnBuscarProdutos = new System.Windows.Forms.Button();
            this.btnSelecionarProduto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Location = new System.Drawing.Point(12, 150);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.RowTemplate.Height = 25;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(506, 175);
            this.dgvProdutos.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(139, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selecionar Produto Para Venda";
            // 
            // txtBuscarProdutos
            // 
            this.txtBuscarProdutos.Location = new System.Drawing.Point(154, 121);
            this.txtBuscarProdutos.Name = "txtBuscarProdutos";
            this.txtBuscarProdutos.Size = new System.Drawing.Size(178, 23);
            this.txtBuscarProdutos.TabIndex = 2;
            // 
            // BtnBuscarProdutos
            // 
            this.BtnBuscarProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBuscarProdutos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnBuscarProdutos.Location = new System.Drawing.Point(329, 121);
            this.BtnBuscarProdutos.Name = "BtnBuscarProdutos";
            this.BtnBuscarProdutos.Size = new System.Drawing.Size(33, 23);
            this.BtnBuscarProdutos.TabIndex = 3;
            this.BtnBuscarProdutos.Text = "🔍";
            this.BtnBuscarProdutos.UseVisualStyleBackColor = true;
            this.BtnBuscarProdutos.Click += new System.EventHandler(this.BtnBuscarProdutos_Click);
            // 
            // btnSelecionarProduto
            // 
            this.btnSelecionarProduto.Location = new System.Drawing.Point(188, 344);
            this.btnSelecionarProduto.Name = "btnSelecionarProduto";
            this.btnSelecionarProduto.Size = new System.Drawing.Size(131, 23);
            this.btnSelecionarProduto.TabIndex = 4;
            this.btnSelecionarProduto.Text = "Selecionar";
            this.btnSelecionarProduto.UseVisualStyleBackColor = true;
            this.btnSelecionarProduto.Click += new System.EventHandler(this.btnSelecionarProduto_Click);
            // 
            // FrmBuscaProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 416);
            this.Controls.Add(this.btnSelecionarProduto);
            this.Controls.Add(this.BtnBuscarProdutos);
            this.Controls.Add(this.txtBuscarProdutos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProdutos);
            this.Name = "FrmBuscaProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBuscaProdutos";
            this.Load += new System.EventHandler(this.FrmBuscaProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscarProdutos;
        private System.Windows.Forms.Button BtnBuscarProdutos;
        private System.Windows.Forms.Button btnSelecionarProduto;
    }
}