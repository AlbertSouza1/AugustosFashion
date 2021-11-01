using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Repositorios;
using AugustosFashion.Views;
using System;
using System.Collections.Generic;

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
            List<ClienteListagem> listaClientes = ClienteRepositorio.ListarClientes();
            return listaClientes;
        }
        public List<ClienteListagem> BuscarClientesPorNome(string text)
        {
            try
            {
                List<ClienteListagem> clientes = ClienteRepositorio.BuscarClientesPorNome(text);                
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ClienteListagem> BuscarClientesPorId(int idBuscado)
        {
            try
            {
                List<ClienteListagem> clientes = ClienteRepositorio.BuscarClientesPorId(idBuscado);
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
