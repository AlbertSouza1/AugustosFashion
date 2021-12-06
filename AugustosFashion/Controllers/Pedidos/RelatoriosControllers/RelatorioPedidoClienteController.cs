﻿using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Repositorios;
using AugustosFashion.Views.Pedidos;
using AugustosFashion.Views.Pedidos.Relatorios;
using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Controllers.Pedidos.RelatoriosControllers
{
    public class RelatorioPedidoClienteController
    {
        private FrmRelatorioVendaCliente _frmRelatorioVendaCliente;

        public void AbrirFormRelatorioVendaCliente()
        {
            _frmRelatorioVendaCliente = new FrmRelatorioVendaCliente(this);
            _frmRelatorioVendaCliente.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            _frmRelatorioVendaCliente.Show();
        }

        public List<RelatorioPedidoCliente> ConsultarRelatorio(FiltroRelatorioPedidoCliente filtroRelatorio)
        {
            return RelatorioPedidoClienteRepositorio.ConsultarRelatorio(filtroRelatorio);
        }

        public void AbrirFormBuscaClientes(string busca)
        {
            var frmBuscaProdutos = new FrmBuscaClientes(this, busca);
            frmBuscaProdutos.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmBuscaProdutos.Show();
            frmBuscaProdutos.BringToFront();
        }

        internal void RecuperarClienteSelecionado(ClienteModel cliente)
        {
            _frmRelatorioVendaCliente.CarregarDadosDeClienteSelecionado(cliente);
        }
    }
}