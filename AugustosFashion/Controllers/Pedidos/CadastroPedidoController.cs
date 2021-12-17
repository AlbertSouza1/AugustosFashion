using AugustosFashion.Controllers.ServicosEmail;
using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Entidades.Colaborador;
using AugustosFashion.Repositorios;
using AugustosFashion.Views.Pedidos;
using AugustosFashionModels.Entidades.Pedidos;
using System;

namespace AugustosFashion.Controllers.Pedidos
{
    public class CadastroPedidoController
    {
        FrmCadastraPedido _frmCadastroPedido;

        public void AbrirFormCadastroPedido()
        {
            _frmCadastroPedido = new FrmCadastraPedido(this, new PedidoModel());
            _frmCadastroPedido.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            _frmCadastroPedido.Show();
        }
        public void AbrirFormCadastroPedidoParaEdicao(PedidoModel pedido)
        {
            _frmCadastroPedido = new FrmCadastraPedido(this, pedido);
            _frmCadastroPedido.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            _frmCadastroPedido.Show();
        }

        public ColaboradorModel RetornarColaboradorDoPedido(int idColaborador)
        {
            try
            {
                return ColaboradorRepositorio.BuscarNomeDoColaborador(idColaborador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CadastrarPedido(PedidoModel pedido)
        {
            if (pedido.FormaPagamento == EFormaPagamento.Aprazo)
            {
                if (!pedido.VerificarSeClientePossuiLimite())
                    return $"O limite de compra a prazo disponível do cliente é de {pedido.Cliente.RetornarLimiteParaNovaCompra():c}.\n\n" +
                  "Selecione uma nova forma de pagamento.";
            }

            PedidoRepositorio.CadastrarPedido(pedido);
            return string.Empty;
        }

        public void AbrirFormBuscaProdutos(string busca)
        {
            var frmBuscaProdutos = new FrmBuscaProdutos(this, busca);
            frmBuscaProdutos.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmBuscaProdutos.Show();
            frmBuscaProdutos.BringToFront();
        }

        public void RecuperarProdutoSelecionado(PedidoProduto produto)
        {
            _frmCadastroPedido.CarregarDadosDeProdutoSelecionado(produto);
        }

        public void EnviarEmailNovoPedido(PedidoModel pedido)
        {
            new ServicoEmailController().PrepararEmailNovoPedido(pedido.Cliente, pedido);
        }        
    }
}
