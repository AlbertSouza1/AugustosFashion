using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Repositorios;
using AugustosFashion.Views.Pedidos;
using AugustosFashion.Views.Pedidos.Relatorios;
using AugustosFashionModels.Entidades.Pedidos;
using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System.Collections.Generic;

namespace AugustosFashion.Controllers.Pedidos.RelatoriosControllers
{
    public class RelatorioPedidoProdutoController
    {
        private FrmRelatorioVendaProduto _frmRelatorioVendaProduto;
        private FrmBuscaClientes _frmBuscaClientes;

        public void AbrirFormRelatorioVendaProduto()
        {
            _frmRelatorioVendaProduto = new FrmRelatorioVendaProduto(this);
            _frmRelatorioVendaProduto.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            _frmRelatorioVendaProduto.Show();
        }

        public List<RelatorioPedidoProduto> ConsultarRelatorio(FiltroRelatorioPedidoProduto filtroRelatorio)
        {
            return RelatorioPedidoProdutoRepositorio.ConsultarRelatorio(filtroRelatorio);
        }

        public void AbrirFormBuscaProdutos(string busca)
        {
            var frmBuscaProdutos = new FrmBuscaProdutos(this, busca);
            frmBuscaProdutos.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmBuscaProdutos.Show();
            frmBuscaProdutos.BringToFront();
        }

        internal void RecuperarProdutoSelecionado(PedidoProduto produto)
        {
            _frmRelatorioVendaProduto.CarregarDadosDeProdutoSelecionado(produto);
        }

        public void AbrirFormBuscaClientes(string busca)
        {
            _frmBuscaClientes = new FrmBuscaClientes();
            _frmBuscaClientes.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            _frmBuscaClientes.Show();
            _frmBuscaClientes.BringToFront();
        }

        public FrmBuscaClientes RetornarFrmBuscaClientes() => _frmBuscaClientes;
     
    }
}
