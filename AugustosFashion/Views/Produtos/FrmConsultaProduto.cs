using AugustosFashion.Controllers.Produtos;
using AugustosFashionModels.Entidades.Produtos;
using System.Windows.Forms;

namespace AugustosFashion.Views.Produtos
{
    public partial class FrmConsultaProduto : Form
    {
        private readonly ConsultaProdutoController _consultaProdutoController;
        private readonly ProdutoModel _produto;

        public FrmConsultaProduto(ConsultaProdutoController consultaProdutoController, ProdutoModel produto)
        {
            InitializeComponent();
            _consultaProdutoController = consultaProdutoController;
            _produto = produto;
            PreencherCampos();
        }

        private void PreencherCampos()
        {
            txtNome.Text = _produto.Nome;
            txtFabricante.Text = _produto.Fabricante;
            mtxtCodigoBarras.Text = _produto.CodigoBarras;
            numEstoque.Text = _produto.Estoque.ToString();
            numPrecoCusto.Text = _produto.PrecoCusto.ToString();
            numPrecoVenda.Text = _produto.PrecoVenda.ToString();

        }
    }
}
