namespace AugustosFashion.Views.Pedidos
{
    partial class FrmBuscaColaborador
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
            this.btnSelecionarColaborador = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvColaboradores = new System.Windows.Forms.DataGridView();
            this.BtnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaboradores)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelecionarColaborador
            // 
            this.btnSelecionarColaborador.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSelecionarColaborador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionarColaborador.ForeColor = System.Drawing.Color.White;
            this.btnSelecionarColaborador.Location = new System.Drawing.Point(200, 343);
            this.btnSelecionarColaborador.Name = "btnSelecionarColaborador";
            this.btnSelecionarColaborador.Size = new System.Drawing.Size(131, 23);
            this.btnSelecionarColaborador.TabIndex = 13;
            this.btnSelecionarColaborador.Text = "Selecionar";
            this.btnSelecionarColaborador.UseVisualStyleBackColor = false;
            this.btnSelecionarColaborador.Click += new System.EventHandler(this.btnSelecionarColaborador_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(186, 122);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(178, 23);
            this.txtBuscar.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(200, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "Selecionar Colaborador";
            // 
            // dgvColaboradores
            // 
            this.dgvColaboradores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColaboradores.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvColaboradores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColaboradores.Location = new System.Drawing.Point(11, 151);
            this.dgvColaboradores.Name = "dgvColaboradores";
            this.dgvColaboradores.ReadOnly = true;
            this.dgvColaboradores.RowTemplate.Height = 25;
            this.dgvColaboradores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColaboradores.Size = new System.Drawing.Size(506, 175);
            this.dgvColaboradores.TabIndex = 10;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnBuscar.Location = new System.Drawing.Point(361, 122);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(33, 23);
            this.BtnBuscar.TabIndex = 14;
            this.BtnBuscar.Text = "🔍";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // FrmBuscaColaborador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(532, 416);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.btnSelecionarColaborador);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvColaboradores);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBuscaColaborador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBuscaColaborador";
            this.Load += new System.EventHandler(this.FrmBuscaColaborador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaboradores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelecionarColaborador;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvColaboradores;
        private System.Windows.Forms.Button BtnBuscar;
    }
}