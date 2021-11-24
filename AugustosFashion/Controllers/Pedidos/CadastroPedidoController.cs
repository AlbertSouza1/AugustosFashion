using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Entidades.Colaborador;
using AugustosFashion.Repositorios;
using AugustosFashion.Views.Pedidos;
using AugustosFashionModels.Entidades.Pedidos;
using AugustosFashionModels.Servicos.ServicosDeEmails;
using System;
using CriptHashes;
using System.Windows.Forms;
using AugustosFashionModels.Entidades.ServicoEmails;
using AugustosFashionModels.Servicos.Criptografias;
using AugustosFashion.Controllers.ServicosEmail;

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

        public ClienteModel RetornarClienteDoPedido(int idCliente)
        {
            try
            {
                return ClienteRepositorio.BuscarNomeDoCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        public void CadastrarPedido(PedidoModel pedido)
        {
            try
            {
                PedidoRepositorio.CadastrarPedido(pedido);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        public void AbrirFormBuscaCliente(string busca)
        {
            var frmBuscaClientes = new FrmBuscaClientes(this, busca);
            frmBuscaClientes.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmBuscaClientes.Show();
            frmBuscaClientes.BringToFront();
        }
        public void RecuperarClienteSelecionado(ClienteListagem cliente)
        {
            _frmCadastroPedido.CarregarDadosDeClienteSelecionado(cliente);
        }

        public void AbrirFormBuscaColaborador(string busca)
        {
            var frmBuscaColaborador = new FrmBuscaColaborador(this, busca);
            frmBuscaColaborador.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmBuscaColaborador.Show();
            frmBuscaColaborador.BringToFront();
        }
        public void RecuperarColaboradorSelecionado(ColaboradorListagem colaborador)
        {
            _frmCadastroPedido.CarregarDadosDeColaboradorSelecionado(colaborador);
        }
    }
}
