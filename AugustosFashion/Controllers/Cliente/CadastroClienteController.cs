using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Repositorios;
using AugustosFashion.Views;
using System;

namespace AugustosFashion.Controllers
{
    public class CadastroClienteController
    {
        public void AbrirFormularioCadastro()
        {
            var frmCadastroCliente = new FrmCadastroCliente(this);
            frmCadastroCliente.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();

            frmCadastroCliente.Show();
        }

        public bool CadastrarCliente(ClienteModel cliente)
        {
            try
            {
                ClienteRepositorio.CadastrarCliente(cliente);               
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
