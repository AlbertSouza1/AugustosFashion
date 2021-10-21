
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnExcluirColaborador = new System.Windows.Forms.Button();
            this.btnAlterarColaborador = new System.Windows.Forms.Button();
            this.dgvColaboradores = new System.Windows.Forms.DataGridView();
            this.btnBuscarColaborador = new System.Windows.Forms.Button();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaboradores)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(206, 479);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(518, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Selecione um cliente na tabela para interagir com as opções abaixo";
            // 
            // btnExcluirColaborador
            // 
            this.btnExcluirColaborador.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExcluirColaborador.Location = new System.Drawing.Point(499, 516);
            this.btnExcluirColaborador.Name = "btnExcluirColaborador";
            this.btnExcluirColaborador.Size = new System.Drawing.Size(119, 49);
            this.btnExcluirColaborador.TabIndex = 13;
            this.btnExcluirColaborador.Text = "Excluir cliente selecionado";
            this.btnExcluirColaborador.UseVisualStyleBackColor = true;
            // 
            // btnAlterarColaborador
            // 
            this.btnAlterarColaborador.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAlterarColaborador.Location = new System.Drawing.Point(269, 516);
            this.btnAlterarColaborador.Name = "btnAlterarColaborador";
            this.btnAlterarColaborador.Size = new System.Drawing.Size(119, 49);
            this.btnAlterarColaborador.TabIndex = 12;
            this.btnAlterarColaborador.Text = "Alterar cliente selecionado";
            this.btnAlterarColaborador.UseVisualStyleBackColor = true;
            // 
            // dgvColaboradores
            // 
            this.dgvColaboradores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColaboradores.Location = new System.Drawing.Point(4, 133);
            this.dgvColaboradores.MultiSelect = false;
            this.dgvColaboradores.Name = "dgvColaboradores";
            this.dgvColaboradores.RowTemplate.Height = 25;
            this.dgvColaboradores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColaboradores.Size = new System.Drawing.Size(862, 325);
            this.dgvColaboradores.TabIndex = 11;
            // 
            // btnBuscarColaborador
            // 
            this.btnBuscarColaborador.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBuscarColaborador.Location = new System.Drawing.Point(451, 84);
            this.btnBuscarColaborador.Name = "btnBuscarColaborador";
            this.btnBuscarColaborador.Size = new System.Drawing.Size(176, 30);
            this.btnBuscarColaborador.TabIndex = 10;
            this.btnBuscarColaborador.Text = "Buscar por nome";
            this.btnBuscarColaborador.UseVisualStyleBackColor = true;
            // 
            // txtBusca
            // 
            this.txtBusca.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBusca.Location = new System.Drawing.Point(250, 84);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(204, 27);
            this.txtBusca.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(335, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "Colaboradores Cadastrados";
            // 
            // FrmListaColaboradores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 574);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExcluirColaborador);
            this.Controls.Add(this.btnAlterarColaborador);
            this.Controls.Add(this.dgvColaboradores);
            this.Controls.Add(this.btnBuscarColaborador);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.label1);
            this.Name = "FrmListaColaboradores";
            this.Text = "FrmListaColaboradores";
            this.Load += new System.EventHandler(this.FrmListaColaboradores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaboradores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExcluirColaborador;
        private System.Windows.Forms.Button btnAlterarColaborador;
        private System.Windows.Forms.DataGridView dgvColaboradores;
        private System.Windows.Forms.Button btnBuscarColaborador;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label label1;
    }
}