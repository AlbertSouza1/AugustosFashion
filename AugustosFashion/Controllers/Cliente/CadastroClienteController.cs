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

        public string CadastrarCliente(ClienteModel cliente)
        {
            try
            {
                var retornoValidacao = cliente.ValidarCliente();
                if (retornoValidacao == string.Empty)
                {
                    ClienteRepositorio.CadastrarCliente(cliente);
                    return string.Empty;
                }
                else
                    return retornoValidacao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
