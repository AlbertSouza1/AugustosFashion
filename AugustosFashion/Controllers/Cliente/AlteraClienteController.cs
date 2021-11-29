using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Repositorios;
using AugustosFashion.Views;
using System;

namespace AugustosFashion.Controllers.Cliente
{
    public class AlteraClienteController
    {
        public void AbrirFormularioAlteracao(ClienteModel cliente)
        {
            var frmAlteracaoCliente = new FrmAlterarCliente(this, cliente);
            frmAlteracaoCliente.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();

            frmAlteracaoCliente.Show();

        }
        public void ConsultarCliente(int id)
        {
            var cliente = ClienteRepositorio.RecuperarInfoCliente(id);
            AbrirFormularioAlteracao(cliente);
        }

        public string AlterarCliente(ClienteModel cliente)
        {
            try
            {
                var retornoValidacao = cliente.ValidarCliente();
                if (retornoValidacao == string.Empty)
                {
                    ClienteRepositorio.AlterarCliente(cliente);
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

        public void ExcluirCliente(int idCliente)
        {
            try
            {
                ClienteRepositorio.ExcluirCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal void InativarCliente(int idCliente)
        {
            try
            {
                ClienteRepositorio.InativarCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
