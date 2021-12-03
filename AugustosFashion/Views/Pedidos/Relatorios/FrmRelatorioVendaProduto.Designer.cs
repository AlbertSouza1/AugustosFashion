namespace AugustosFashion.Views.Pedidos.Relatorios
{
    partial class FrmRelatorioVendaProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelatorioVendaProduto));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnFecharFiltro = new System.Windows.Forms.Button();
            this.BtnFiltrar = new System.Windows.Forms.Button();
            this.BtnBuscarCliente = new System.Windows.Forms.Button();
            this.BtnBuscarProduto = new System.Windows.Forms.Button();
            this.txtBuscaCliente = new System.Windows.Forms.TextBox();
            this.txtBuscaProduto = new System.Windows.Forms.TextBox();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvRelatorioProdutos = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            this.BtnMostrarFiltros = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorioProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.BtnFecharFiltro);
            this.groupBox1.Controls.Add(this.BtnFiltrar);
            this.groupBox1.Controls.Add(this.BtnBuscarCliente);
            this.groupBox1.Controls.Add(this.BtnBuscarProduto);
            this.groupBox1.Controls.Add(this.txtBuscaCliente);
            this.groupBox1.Controls.Add(this.txtBuscaProduto);
            this.groupBox1.Controls.Add(this.dtpFinal);
            this.groupBox1.Controls.Add(this.dtpInicial);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(741, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 741);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // BtnFecharFiltro
            // 
            this.BtnFecharFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(82)))), ((int)(((byte)(69)))));
            this.BtnFecharFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFecharFiltro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnFecharFiltro.ForeColor = System.Drawing.Color.White;
            this.BtnFecharFiltro.Location = new System.Drawing.Point(188, 12);
            this.BtnFecharFiltro.Name = "BtnFecharFiltro";
            this.BtnFecharFiltro.Size = new System.Drawing.Size(31, 26);
            this.BtnFecharFiltro.TabIndex = 110;
            this.BtnFecharFiltro.Text = "X";
            this.BtnFecharFiltro.UseVisualStyleBackColor = false;
            this.BtnFecharFiltro.Click += new System.EventHandler(this.BtnFecharFiltro_Click);
            // 
            // BtnFiltrar
            // 
            this.BtnFiltrar.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnFiltrar.ForeColor = System.Drawing.Color.White;
            this.BtnFiltrar.Location = new System.Drawing.Point(72, 400);
            this.BtnFiltrar.Name = "BtnFiltrar";
            this.BtnFiltrar.Size = new System.Drawing.Size(94, 29);
            this.BtnFiltrar.TabIndex = 40;
            this.BtnFiltrar.Text = "Filtrar";
            this.BtnFiltrar.UseVisualStyleBackColor = false;
            this.BtnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);
            // 
            // BtnBuscarCliente
            // 
            this.BtnBuscarCliente.BackColor = System.Drawing.SystemColors.Control;
            this.BtnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBuscarCliente.Font = new System.Drawing.Font("Segoe UI", 9.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnBuscarCliente.Location = new System.Drawing.Point(180, 352);
            this.BtnBuscarCliente.Name = "BtnBuscarCliente";
            this.BtnBuscarCliente.Size = new System.Drawing.Size(40, 23);
            this.BtnBuscarCliente.TabIndex = 39;
            this.BtnBuscarCliente.Text = "🔍";
            this.BtnBuscarCliente.UseVisualStyleBackColor = false;
            // 
            // BtnBuscarProduto
            // 
            this.BtnBuscarProduto.BackColor = System.Drawing.SystemColors.Control;
            this.BtnBuscarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBuscarProduto.Font = new System.Drawing.Font("Segoe UI", 9.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnBuscarProduto.Location = new System.Drawing.Point(180, 292);
            this.BtnBuscarProduto.Name = "BtnBuscarProduto";
            this.BtnBuscarProduto.Size = new System.Drawing.Size(40, 23);
            this.BtnBuscarProduto.TabIndex = 38;
            this.BtnBuscarProduto.Text = "🔍";
            this.BtnBuscarProduto.UseVisualStyleBackColor = false;
            this.BtnBuscarProduto.Click += new System.EventHandler(this.BtnBuscarProduto_Click);
            // 
            // txtBuscaCliente
            // 
            this.txtBuscaCliente.Location = new System.Drawing.Point(20, 352);
            this.txtBuscaCliente.Name = "txtBuscaCliente";
            this.txtBuscaCliente.Size = new System.Drawing.Size(163, 23);
            this.txtBuscaCliente.TabIndex = 5;
            // 
            // txtBuscaProduto
            // 
            this.txtBuscaProduto.Location = new System.Drawing.Point(20, 292);
            this.txtBuscaProduto.Name = "txtBuscaProduto";
            this.txtBuscaProduto.Size = new System.Drawing.Size(163, 23);
            this.txtBuscaProduto.TabIndex = 4;
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
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(20, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cliente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(20, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Data Inicial";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(20, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Data Final";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(20, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Produto";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(293, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(344, 30);
            this.label6.TabIndex = 0;
            this.label6.Text = "Relatório de Vendas por Produtos";
            // 
            // dgvRelatorioProdutos
            // 
            this.dgvRelatorioProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRelatorioProdutos.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvRelatorioProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatorioProdutos.Location = new System.Drawing.Point(30, 172);
            this.dgvRelatorioProdutos.Name = "dgvRelatorioProdutos";
            this.dgvRelatorioProdutos.RowTemplate.Height = 25;
            this.dgvRelatorioProdutos.Size = new System.Drawing.Size(921, 323);
            this.dgvRelatorioProdutos.TabIndex = 1;
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
            this.btnFechar.Location = new System.Drawing.Point(30, 80);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(43, 36);
            this.btnFechar.TabIndex = 106;
            this.btnFechar.UseVisualStyleBackColor = false;
            // 
            // BtnMostrarFiltros
            // 
            this.BtnMostrarFiltros.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnMostrarFiltros.BackgroundImage")));
            this.BtnMostrarFiltros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnMostrarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnMostrarFiltros.Location = new System.Drawing.Point(910, 142);
            this.BtnMostrarFiltros.Name = "BtnMostrarFiltros";
            this.BtnMostrarFiltros.Size = new System.Drawing.Size(39, 27);
            this.BtnMostrarFiltros.TabIndex = 109;
            this.BtnMostrarFiltros.UseVisualStyleBackColor = true;
            this.BtnMostrarFiltros.Click += new System.EventHandler(this.BtnMostrarFiltros_Click);
            // 
            // FrmRelatorioVendaProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 740);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.dgvRelatorioProdutos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnMostrarFiltros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRelatorioVendaProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRelatorioVendaProduto";
            this.Load += new System.EventHandler(this.FrmRelatorioVendaProduto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorioProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBuscaCliente;
        private System.Windows.Forms.TextBox txtBuscaProduto;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.DateTimePicker dtpInicial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnBuscarCliente;
        private System.Windows.Forms.Button BtnBuscarProduto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnFiltrar;
        private System.Windows.Forms.DataGridView dgvRelatorioProdutos;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button BtnMostrarFiltros;
        private System.Windows.Forms.Button BtnFecharFiltro;
    }
}