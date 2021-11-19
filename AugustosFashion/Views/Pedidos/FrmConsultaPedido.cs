using AugustosFashion.Controllers.Pedidos;
using AugustosFashionModels.Entidades.Pedidos;
using System;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos
{
    public partial class FrmConsultaPedido : Form
    {
        private readonly ConsultaPedidoController _consultaPedidoController;
        private PedidoModel _pedido;

        public FrmConsultaPedido(ConsultaPedidoController consultaPedidoController, PedidoModel pedido)
        {
            InitializeComponent();
            _consultaPedidoController = consultaPedidoController;
            _pedido = pedido;

            AtualizarGridProdutosDoPedido();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void AtualizarGridProdutosDoPedido()
        {
            dgvPedidos.DataSource = _pedido.Produtos;

            lblData.Text = _pedido.DataEmissao.ToString("dd/MM/yyyy H:mm");
        }
    }
}
