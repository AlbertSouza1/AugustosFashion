namespace AugustosFashion.Views.Pedidos
{
    partial class FrmListaPedidos
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
            this.btnVisualizarProduto = new System.Windows.Forms.Button();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.btnBuscarPedidos = new System.Windows.Forms.Button();
            this.txtBuscaPedidos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(215, 502);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(518, 18);
            this.label2.TabIndex = 96;
            this.label2.Text = "Selecione um pedido na tabela para interagir com as opções abaixo";
            // 
            // btnVisualizarProduto
            // 
            this.btnVisualizarProduto.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnVisualizarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVisualizarProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnVisualizarProduto.ForeColor = System.Drawing.Color.White;
            this.btnVisualizarProduto.Location = new System.Drawing.Point(375, 541);
            this.btnVisualizarProduto.Name = "btnVisualizarProduto";
            this.btnVisualizarProduto.Size = new System.Drawing.Size(161, 46);
            this.btnVisualizarProduto.TabIndex = 95;
            this.btnVisualizarProduto.Text = "Consultar Pedido";
            this.btnVisualizarProduto.UseVisualStyleBackColor = false;
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPedidos.Location = new System.Drawing.Point(24, 160);
            this.dgvPedidos.MultiSelect = false;
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPedidos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgvPedidos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPedidos.RowTemplate.Height = 25;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.Size = new System.Drawing.Size(862, 325);
            this.dgvPedidos.TabIndex = 94;
            // 
            // btnBuscarPedidos
            // 
            this.btnBuscarPedidos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBuscarPedidos.Location = new System.Drawing.Point(425, 114);
            this.btnBuscarPedidos.Name = "btnBuscarPedidos";
            this.btnBuscarPedidos.Size = new System.Drawing.Size(265, 27);
            this.btnBuscarPedidos.TabIndex = 93;
            this.btnBuscarPedidos.Text = "Buscar  (% para trazer todos)";
            this.btnBuscarPedidos.UseVisualStyleBackColor = true;
            this.btnBuscarPedidos.Click += new System.EventHandler(this.btnBuscarPedidos_Click);
            // 
            // txtBuscaPedidos
            // 
            this.txtBuscaPedidos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBuscaPedidos.Location = new System.Drawing.Point(224, 114);
            this.txtBuscaPedidos.Name = "txtBuscaPedidos";
            this.txtBuscaPedidos.Size = new System.Drawing.Size(204, 27);
            this.txtBuscaPedidos.TabIndex = 92;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(343, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 30);
            this.label1.TabIndex = 91;
            this.label1.Text = "Pedidos Efetuados";
            // 
            // FrmListaPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 642);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnVisualizarProduto);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.btnBuscarPedidos);
            this.Controls.Add(this.txtBuscaPedidos);
            this.Controls.Add(this.label1);
            this.Name = "FrmListaPedidos";
            this.Text = "FrmListaPedidos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVisualizarProduto;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.Button btnBuscarPedidos;
        private System.Windows.Forms.TextBox txtBuscaPedidos;
        private System.Windows.Forms.Label label1;
    }
}