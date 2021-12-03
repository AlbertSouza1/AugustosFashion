using AugustosFashion.Entidades;
using AugustosFashion.Repositorios;
using AugustosFashion.Views.Pedidos;
using AugustosFashion.Views.Pedidos.Relatorios;
using AugustosFashionModels.Entidades.Pedidos;
using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System;
using System.Collections.Generic;

namespace AugustosFashion.Controllers.Pedidos.RelatoriosControllers
{
    public class RelatorioVendaProdutoController
    {
        private FrmRelatorioVendaProduto _frmRelatorioVendaProduto;

        public void AbrirFormRelatorioVendaProduto()
        {
            _frmRelatorioVendaProduto = new FrmRelatorioVendaProduto(this);
            _frmRelatorioVendaProduto.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            _frmRelatorioVendaProduto.Show();
        }

        public List<RelatorioVendaProduto> ConsultarRelatorio(FiltroRelatorioVendaProduto filtroRelatorio)
        {
            return RelatorioVendaProdutoRepositorio.ConsultarRelatorio(filtroRelatorio);
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
    }
}
