using AugustosFashion.Controllers.Pedidos;
using AugustosFashion.Controllers.Produtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos
{
    public partial class FrmCadastraPedido : Form
    {
        private readonly CadastroPedidoController _cadastroPedidoController;
        private readonly ListaProdutoController _listaProdutoController = new ListaProdutoController();

        public FrmCadastraPedido(CadastroPedidoController cadastroPedidoController)
        {
            InitializeComponent();
            _cadastroPedidoController = cadastroPedidoController;
        }

        private void FrmCadastraPedido_Load(object sender, EventArgs e)
        {

        }

        //private void BtnBuscarProdutos_Click(object sender, EventArgs e)
        //{
        //    var produtos = _listaProdutoController.BuscarProdutosPorNome(txtBuscarProdutos.Text);

        //   dgvBuscaProdutos.DataSource = produtos;
        //}
    }
}
