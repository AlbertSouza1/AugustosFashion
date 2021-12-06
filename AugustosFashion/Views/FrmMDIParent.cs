using AugustosFashion.Controllers;
using AugustosFashion.Controllers.Colaborador;
using AugustosFashion.Controllers.Pedidos;
using AugustosFashion.Controllers.Produtos;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AugustosFashion.Views;
using AugustosFashion.Controllers.Pedidos.RelatoriosControllers;

namespace AugustosFashion
{
    public partial class FrmMDIParent : Form
    {
        private int childFormNumber = 0;

        public FrmMDIParent()
        {
            InitializeComponent();           
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Janela " + childFormNumber++;         
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void FrmMDIParent_Load(object sender, EventArgs e)
        {
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.RoyalBlue;
            var FrmFundoHome = new FrmFundoHome();
            FrmFundoHome.MdiParent = this;
            FrmFundoHome.Show();
        }

        private void tsNovoCliente_Click(object sender, EventArgs e)
        {
            new CadastroClienteController().AbrirFormularioCadastro();
        }

        private void tsListarClientes_Click(object sender, EventArgs e)
        {
            new ListaClienteController().AbrirFormularioLista();
        }

        private void btnCloseMDI_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void novoColaboradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CadastroColaboradorController().AbrirFormCadastroColaborador();
        }

        private void visualizarColaboradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ListaColaboradorController().AbrirFormularioLista();
        }

        private void novoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CadastroProdutoController().AbrirFormCadastroProduto();
        }

        private void visualizarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ListaProdutoController().AbrirFormListaProduto();
        }

        private void novaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CadastroPedidoController().AbrirFormCadastroPedido();
        }

        private void visualizarVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ListaPedidoController().AbrirFormListaPedidos();
        }

        private void vendasPorProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RelatorioPedidoProdutoController().AbrirFormRelatorioVendaProduto();
        }

        private void vendasPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RelatorioPedidoClienteController().AbrirFormRelatorioVendaCliente();
        }
    }
}
