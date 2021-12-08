using AugustosFashion.Entidades;
using AugustosFashion.Repositorios;
using AugustosFashion.Views.Financeiro;
using AugustosFashion.Views.Pedidos;
using AugustosFashionModels.Entidades.ContasClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Controllers.Financeiro
{
    public class ContasClientesController
    {
        private FrmBuscaClientes _frmBuscaCliente;

        public ContasClientesController()
        {
            _frmBuscaCliente = new FrmBuscaClientes();
        }
        internal void AbrirFormContasCliente()
        {
            var frmContasClientes = new FrmContasClientes(this);
            frmContasClientes.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmContasClientes.Show();
        }

        internal void AbrirFormBuscaClientes(string busca)
        {
            _frmBuscaCliente.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            _frmBuscaCliente.Show();
            _frmBuscaCliente.BringToFront();
        }

        public FrmBuscaClientes RetornarFrmBuscaClientes() => _frmBuscaCliente;

        internal List<ContaClienteModel> RecuperarContasDoCliente(int idCliente)
        {
            return ContasClientesRepositorio.RecuperarContasDoCliente(idCliente);
        }
    }
}
