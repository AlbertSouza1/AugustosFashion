
namespace AugustosFashion
{
    partial class FrmMDIParent
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMDIParent));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsNovoCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.tsListarClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.colaboradoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoColaboradorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarColaboradoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelCentral = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            this.panelCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.colaboradoresToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(987, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNovoCliente,
            this.tsListarClientes});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // tsNovoCliente
            // 
            this.tsNovoCliente.Image = ((System.Drawing.Image)(resources.GetObject("tsNovoCliente.Image")));
            this.tsNovoCliente.Name = "tsNovoCliente";
            this.tsNovoCliente.Size = new System.Drawing.Size(168, 22);
            this.tsNovoCliente.Text = "Novo Cliente";
            this.tsNovoCliente.Click += new System.EventHandler(this.tsNovoCliente_Click);
            // 
            // tsListarClientes
            // 
            this.tsListarClientes.Image = ((System.Drawing.Image)(resources.GetObject("tsListarClientes.Image")));
            this.tsListarClientes.Name = "tsListarClientes";
            this.tsListarClientes.Size = new System.Drawing.Size(168, 22);
            this.tsListarClientes.Text = "Visualizar Clientes";
            this.tsListarClientes.Click += new System.EventHandler(this.tsListarClientes_Click);
            // 
            // colaboradoresToolStripMenuItem
            // 
            this.colaboradoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoColaboradorToolStripMenuItem,
            this.visualizarColaboradoresToolStripMenuItem});
            this.colaboradoresToolStripMenuItem.Name = "colaboradoresToolStripMenuItem";
            this.colaboradoresToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.colaboradoresToolStripMenuItem.Text = "Colaboradores";
            // 
            // novoColaboradorToolStripMenuItem
            // 
            this.novoColaboradorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("novoColaboradorToolStripMenuItem.Image")));
            this.novoColaboradorToolStripMenuItem.Name = "novoColaboradorToolStripMenuItem";
            this.novoColaboradorToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.novoColaboradorToolStripMenuItem.Text = "Novo Colaborador";
            this.novoColaboradorToolStripMenuItem.Click += new System.EventHandler(this.novoColaboradorToolStripMenuItem_Click);
            // 
            // visualizarColaboradoresToolStripMenuItem
            // 
            this.visualizarColaboradoresToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("visualizarColaboradoresToolStripMenuItem.Image")));
            this.visualizarColaboradoresToolStripMenuItem.Name = "visualizarColaboradoresToolStripMenuItem";
            this.visualizarColaboradoresToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.visualizarColaboradoresToolStripMenuItem.Text = "Visualizar Colaboradores";
            this.visualizarColaboradoresToolStripMenuItem.Click += new System.EventHandler(this.visualizarColaboradoresToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(191)))), ((int)(((byte)(237)))));
            this.panel1.Location = new System.Drawing.Point(0, 566);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 85);
            this.panel1.TabIndex = 2;
            // 
            // panelCentral
            // 
            this.panelCentral.Controls.Add(this.label1);
            this.panelCentral.Controls.Add(this.pictureBox1);
            this.panelCentral.Controls.Add(this.panel1);
            this.panelCentral.Location = new System.Drawing.Point(0, 27);
            this.panelCentral.Name = "panelCentral";
            this.panelCentral.Size = new System.Drawing.Size(947, 653);
            this.panelCentral.TabIndex = 3;
            this.panelCentral.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(191)))), ((int)(((byte)(237)))));
            this.label1.Location = new System.Drawing.Point(255, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "AUGUSTU\'s FASHION";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(312, 164);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(269, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMDIParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 768);
            this.Controls.Add(this.panelCentral);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmMDIParent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Augustu\'s Fashion";
            this.Load += new System.EventHandler(this.FrmMDIParent_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelCentral.ResumeLayout(false);
            this.panelCentral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colaboradoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsNovoCliente;
        private System.Windows.Forms.ToolStripMenuItem tsListarClientes;
        private System.Windows.Forms.ToolStripMenuItem novoColaboradorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarColaboradoresToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}



