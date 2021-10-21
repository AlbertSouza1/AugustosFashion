using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Repositorios;
using AugustosFashion.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AugustosFashion.Controllers
{
    public class ListaClienteController
    {
        public void AbrirFormularioLista()
        {
            var frmListaCliente = new FrmListaClientes(this);
            frmListaCliente.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmListaCliente.Show();
        }

        public List<ClienteListagem> ListarClientes()
        {
            List<ClienteListagem> listaClientes = new ClienteRepositorio().ListarClientes();
            return listaClientes;
        }

        public void ExcluirCliente(int idCliente)
        {
            try
            {
                new ClienteRepositorio().ExcluirCliente(idCliente);
                MessageBox.Show("Cliente excluído com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao excluir cliente. Erro: " + ex.Message);
            }
        }
    }
}
