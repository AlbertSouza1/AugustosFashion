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

        public List<ContaClienteModel> RecuperarContasDoCliente(int idCliente, bool pagas) =>
            ContaClienteRepositorio.RecuperarContasDoCliente(idCliente, pagas);

        public void PagarContaDoCliente(int idConta)
        {
            ContaClienteRepositorio.PagarConta(idConta);
        }

        public bool VerificarSeContaJaFoiPaga(int idPedido) => ContaClienteRepositorio.VerificarSeContaJaFoiPaga(idPedido);
    }
}
