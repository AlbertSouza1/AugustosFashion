using AugustosFashion.Controllers.Produtos;
using System.Windows.Forms;

namespace AugustosFashion.Views.Produtos
{
    public partial class FrmListaProduto : Form
    {
        private readonly ListaProdutoController _listaProdutoController;

        public FrmListaProduto(ListaProdutoController listaProdutoController)
        {
            InitializeComponent();
            _listaProdutoController = listaProdutoController;
        }
    }
}
