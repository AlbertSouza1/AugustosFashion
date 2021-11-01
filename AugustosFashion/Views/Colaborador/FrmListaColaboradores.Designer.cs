
namespace AugustosFashion.Views.Colaborador
{
    partial class FrmListaColaboradores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVisualizarColaborador = new System.Windows.Forms.Button();
            this.dgvColaboradores = new System.Windows.Forms.DataGridView();
            this.btnBuscarColaborador = new System.Windows.Forms.Button();
            this.txtBuscaColaborador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaboradores)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(206, 475);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(518, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Selecione um cliente na tabela para interagir com as opções abaixo";
            // 
            // btnVisualizarColaborador
            // 
            this.btnVisualizarColaborador.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnVisualizarColaborador.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVisualizarColaborador.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnVisualizarColaborador.ForeColor = System.Drawing.Color.White;
            this.btnVisualizarColaborador.Location = new System.Drawing.Point(373, 513);
            this.btnVisualizarColaborador.Name = "btnVisualizarColaborador";
            this.btnVisualizarColaborador.Size = new System.Drawing.Size(161, 49);
            this.btnVisualizarColaborador.TabIndex = 12;
            this.btnVisualizarColaborador.Text = "Consultar Cadastro do Colaborador";
            this.btnVisualizarColaborador.UseVisualStyleBackColor = false;
            this.btnVisualizarColaborador.Click += new System.EventHandler(this.btnVisualizarColaborador_Click);
            // 
            // dgvColaboradores
            // 
            this.dgvColaboradores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColaboradores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvColaboradores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvColaboradores.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvColaboradores.Location = new System.Drawing.Point(4, 133);
            this.dgvColaboradores.MultiSelect = false;
            this.dgvColaboradores.Name = "dgvColaboradores";
            this.dgvColaboradores.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColaboradores.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgvColaboradores.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvColaboradores.RowTemplate.Height = 25;
            this.dgvColaboradores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColaboradores.Size = new System.Drawing.Size(862, 325);
            this.dgvColaboradores.TabIndex = 11;
            // 
            // btnBuscarColaborador
            // 
            this.btnBuscarColaborador.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBuscarColaborador.Location = new System.Drawing.Point(451, 82);
            this.btnBuscarColaborador.Name = "btnBuscarColaborador";
            this.btnBuscarColaborador.Size = new System.Drawing.Size(352, 30);
            this.btnBuscarColaborador.TabIndex = 10;
            this.btnBuscarColaborador.Text = "Buscar por nome ou código (% para trazer todos)";
            this.btnBuscarColaborador.UseVisualStyleBackColor = true;
            this.btnBuscarColaborador.Click += new System.EventHandler(this.btnBuscarColaborador_Click);
            // 
            // txtBuscaColaborador
            // 
            this.txtBuscaColaborador.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBuscaColaborador.Location = new System.Drawing.Point(250, 84);
            this.txtBuscaColaborador.Name = "txtBuscaColaborador";
            this.txtBuscaColaborador.Size = new System.Drawing.Size(204, 27);
            this.txtBuscaColaborador.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(318, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Colaboradores Cadastrados";
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFechar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFechar.Location = new System.Drawing.Point(836, 0);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(30, 23);
            this.btnFechar.TabIndex = 15;
            this.btnFechar.Text = "X";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // FrmListaColaboradores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 574);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnVisualizarColaborador);
            this.Controls.Add(this.dgvColaboradores);
            this.Controls.Add(this.btnBuscarColaborador);
            this.Controls.Add(this.txtBuscaColaborador);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmListaColaboradores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmListaColaboradores";
            this.Load += new System.EventHandler(this.FrmListaColaboradores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaboradores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVisualizarColaborador;
        private System.Windows.Forms.DataGridView dgvColaboradores;
        private System.Windows.Forms.Button btnBuscarColaborador;
        private System.Windows.Forms.TextBox txtBuscaColaborador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFechar;
    }
}