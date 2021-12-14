using AugustosFashion.Entidades;
using AugustosFashion.Repositorios;
using AugustosFashion.Views.Pedidos.Relatorios;
using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using AugustosFashionModels.Entidades.Pedidos.Relatorios.Filtros;
using System.Collections.Generic;

namespace AugustosFashion.Controllers.Pedidos.RelatoriosControllers
{
    public class RelatorioPedidoClienteController
    {
        public void AbrirFormRelatorioVendaCliente()
        {
            var frmRelatorioVendaCliente = new FrmRelatorioVendaCliente(this);
            frmRelatorioVendaCliente.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmRelatorioVendaCliente.Show();
        }

        public List<RelatorioPedidoCliente> ConsultarRelatorio(FiltroRelatorioPedidoCliente filtroRelatorio) =>      
             RelatorioPedidoClienteRepositorio.ConsultarRelatorio(filtroRelatorio);       
    }
}
