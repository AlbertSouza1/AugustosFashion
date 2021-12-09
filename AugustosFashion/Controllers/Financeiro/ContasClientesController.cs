using AugustosFashion.Entidades;
using AugustosFashion.Repositorios;
using AugustosFashion.Views.Financeiro;
using AugustosFashion.Views.Pedidos;
using AugustosFashionModels.Entidades.ContasClientes;
using System;
using System.Collections.Generic;

namespace AugustosFashion.Controllers.Financeiro
{
    public class ContasClientesController
    {
        private FrmBuscaClientes _frmBuscaCliente;

        internal void AbrirFormContasCliente()
        {
            var frmContasClientes = new FrmContasClientes(this);
            frmContasClientes.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmContasClientes.Show();
        }

        internal void AbrirFormBuscaClientes()
        {
            _frmBuscaCliente = new FrmBuscaClientes();

            _frmBuscaCliente.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            _frmBuscaCliente.Show();
            _frmBuscaCliente.BringToFront();
        }

        public FrmBuscaClientes RetornarFrmBuscaClientes() => _frmBuscaCliente;

        internal List<ContaClienteModel> RecuperarContasDoCliente(int idCliente) =>
            ContaClienteRepositorio.RecuperarContasDoCliente(idCliente);

        internal void PagarContaDoCliente(int idConta)
        {
            ContaClienteRepositorio.PagarContaDoCliente(idConta);
        }
    }
}
