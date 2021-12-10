using AugustosFashion.Controllers.Pedidos;
using AugustosFashionModels.Entidades.Pedidos;
using EnumsNET;
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
            BloquearEdicoesSePedidoEstaEliminado();

            AtualizarGridProdutosDoPedido();
            ExibirInformacoesDoPedido();

            ExibirDadosDoCliente();
            RecuperarColaboradorDoPedido();
        }

        private void BloquearEdicoesSePedidoEstaEliminado()
        {
            if (_pedido.Eliminado)
            {
                btnAlterar.Visible = false;
                btnEliminar.Visible = false;
            }
                
        }

        private void RecuperarColaboradorDoPedido()
        {
            var colaborador = new CadastroPedidoController().RetornarColaboradorDoPedido(_pedido.IdColaborador);
            lblColaborador.Text = colaborador.NomeCompleto.Nome + ' ' + colaborador.NomeCompleto.SobreNome;
        }

        private void ExibirDadosDoCliente()
        {
            lblCliente.Text = _pedido.Cliente.NomeCompleto.Nome + ' ' + _pedido.Cliente.NomeCompleto.SobreNome;
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
            lblFormaPagamento.Text = _pedido.FormaPagamento.AsString(EnumFormat.Description);
            lblLucro.Text = _pedido.Lucro.ValorFormatado;
            lblNumeroPedido.Text = _pedido.IdPedido.ToString();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            _consultaPedidoController.AlterarPedido(_pedido);
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem certeza que deseja eliminar esta venda?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                EliminarPedido();
                Close();
            }              
        }

        private void EliminarPedido()
        {
            try
            {
                _consultaPedidoController.EliminarPedido(_pedido);

                MessageBox.Show("Pedido eliminado com sucesso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível eliminar este pedido. Erro: " + ex.Message);
            }
        }
    }
}
