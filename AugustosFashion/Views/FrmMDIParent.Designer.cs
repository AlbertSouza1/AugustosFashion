
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
            this.menuStrip.SuspendLayout();
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
            this.menuStrip.Size = new System.Drawing.Size(909, 24);
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
            // 
            // visualizarColaboradoresToolStripMenuItem
            // 
            this.visualizarColaboradoresToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("visualizarColaboradoresToolStripMenuItem.Image")));
            this.visualizarColaboradoresToolStripMenuItem.Name = "visualizarColaboradoresToolStripMenuItem";
            this.visualizarColaboradoresToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.visualizarColaboradoresToolStripMenuItem.Text = "Visualizar Colaboradores";
            // 
            // FrmMDIParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 678);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmMDIParent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Augusto\'s Fashion";
            this.Load += new System.EventHandler(this.FrmMDIParent_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
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
    }
}



