using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Repositorios;
using AugustosFashion.Views.Pedidos;
using AugustosFashionModels.Entidades.Pedidos;
using AugustosFashionModels.Entidades.Produtos;

namespace AugustosFashion.Controllers.Pedidos
{
    public class CadastroPedidoController
    {
        FrmCadastraPedido _frmCadastroPedido;

        internal void AbrirFormCadastroPedidos()
        {
            _frmCadastroPedido = new FrmCadastraPedido(this);
            _frmCadastroPedido.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            _frmCadastroPedido.Show();
        }

        internal void CadastrarPedido(PedidoModel pedido)
        {
            PedidoRepositorio.CadastrarPedido(pedido);
        }

        internal void AbrirFormBuscaProdutos(string busca)
        {
            var frmBuscaProdutos = new FrmBuscaProdutos(this, busca);
            frmBuscaProdutos.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmBuscaProdutos.Show();
            frmBuscaProdutos.BringToFront();
        }

        internal void RecuperarProdutoSelecionado(ProdutoListagem produto)
        {
            _frmCadastroPedido.CarregarDadosDeProdutoSelecionado(produto);
        }

        internal void AbrirFormBuscaCliente(string busca)
        {
            var frmBuscaClientes = new FrmBuscaClientes(this, busca);
            frmBuscaClientes.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmBuscaClientes.Show();
            frmBuscaClientes.BringToFront();
        }
        internal void RecuperarClienteSelecionado(ClienteListagem cliente)
        {
            _frmCadastroPedido.CarregarDadosDeClienteSelecionado(cliente);
        }
    }
}
