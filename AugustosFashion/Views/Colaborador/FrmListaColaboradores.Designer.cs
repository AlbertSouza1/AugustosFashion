
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaColaboradores));
            this.label2 = new System.Windows.Forms.Label();
            this.btnVisualizarColaborador = new System.Windows.Forms.Button();
            this.dgvColaboradores = new System.Windows.Forms.DataGridView();
            this.btnBuscarColaborador = new System.Windows.Forms.Button();
            this.txtBuscaColaborador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaboradores)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(262, 558);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(517, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Selecione um cliente na tabela para interagir com as opções abaixo";
            // 
            // btnVisualizarColaborador
            // 
            this.btnVisualizarColaborador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVisualizarColaborador.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnVisualizarColaborador.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVisualizarColaborador.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnVisualizarColaborador.ForeColor = System.Drawing.Color.White;
            this.btnVisualizarColaborador.Location = new System.Drawing.Point(429, 596);
            this.btnVisualizarColaborador.Name = "btnVisualizarColaborador";
            this.btnVisualizarColaborador.Size = new System.Drawing.Size(161, 49);
            this.btnVisualizarColaborador.TabIndex = 12;
            this.btnVisualizarColaborador.Text = "Consultar Cadastro do Colaborador";
            this.btnVisualizarColaborador.UseVisualStyleBackColor = false;
            this.btnVisualizarColaborador.Click += new System.EventHandler(this.btnVisualizarColaborador_Click);
            // 
            // dgvColaboradores
            // 
            this.dgvColaboradores.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.dgvColaboradores.Location = new System.Drawing.Point(60, 216);
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
            this.btnBuscarColaborador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscarColaborador.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBuscarColaborador.Location = new System.Drawing.Point(491, 128);
            this.btnBuscarColaborador.Name = "btnBuscarColaborador";
            this.btnBuscarColaborador.Size = new System.Drawing.Size(352, 30);
            this.btnBuscarColaborador.TabIndex = 10;
            this.btnBuscarColaborador.Text = "Buscar por nome ou código (% para trazer todos)";
            this.btnBuscarColaborador.UseVisualStyleBackColor = true;
            this.btnBuscarColaborador.Click += new System.EventHandler(this.btnBuscarColaborador_Click);
            // 
            // txtBuscaColaborador
            // 
            this.txtBuscaColaborador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBuscaColaborador.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBuscaColaborador.Location = new System.Drawing.Point(290, 130);
            this.txtBuscaColaborador.Name = "txtBuscaColaborador";
            this.txtBuscaColaborador.Size = new System.Drawing.Size(204, 27);
            this.txtBuscaColaborador.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(358, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Colaboradores Cadastrados";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(60, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 36);
            this.button1.TabIndex = 94;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmListaColaboradores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 740);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
    }
}