using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Repositorios;
using AugustosFashion.Views;
using System;
using System.Windows.Forms;

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
                MessageBox.Show("Cliente cadastrado com sucesso!");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao cadastrar cliente. Erro: "+ex.Message);
                return false;
            }
        }

    }
}
