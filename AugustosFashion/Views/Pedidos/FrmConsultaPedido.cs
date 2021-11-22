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
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmConsultaPedido_Load(object sender, EventArgs e)
        {
            AtualizarGridProdutosDoPedido();
            ExibirInformacoesDoPedido();
        }

        private void AtualizarGridProdutosDoPedido()
        {
            dgvPedidos.DataSource = _pedido.Produtos;            
        }

        private void ExibirInformacoesDoPedido() 
        {
            lblData.Text = _pedido.DataEmissao.ToString("dd/MM/yyyy H:mm");
            lblTotalBruto.Text = _pedido.TotalBruto.ValorFormatado;
            lblTotalDesconto.Text = _pedido.TotalDesconto.ValorFormatado;
            lblTotalLiquido.Text = _pedido.TotalLiquido.ValorFormatado;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            _consultaPedidoController.AlterarPedido(_pedido);
            Close();
        }
    }
}
