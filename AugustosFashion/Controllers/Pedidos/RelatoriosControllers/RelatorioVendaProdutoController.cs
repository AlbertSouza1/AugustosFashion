using AugustosFashion.Entidades;
using AugustosFashion.Repositorios;
using AugustosFashion.Views.Pedidos.Relatorios;
using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System;
using System.Collections.Generic;

namespace AugustosFashion.Controllers.Pedidos.RelatoriosControllers
{
    public class RelatorioVendaProdutoController
    {
        public void AbrirFormRelatorioVendaProduto()
        {
            var frmRelatorioVendaProduto = new FrmRelatorioVendaProduto(this);
            frmRelatorioVendaProduto.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmRelatorioVendaProduto.Show();
        }

        internal List<RelatorioVendaProduto> ConsultarRelatorio(FiltroRelatorioVendaProduto filtroRelatorio)
        {
            return RelatorioVendaProdutoRepositorio.ConsultarRelatorio(filtroRelatorio);
        }
    }
}
