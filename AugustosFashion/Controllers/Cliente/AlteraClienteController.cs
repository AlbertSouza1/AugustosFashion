using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Repositorios;
using AugustosFashion.Views;
using AugustosFashionModels.Entidades.Pedidos;
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
            var cliente = RecuperarInformacoesCliente(id);
            AbrirFormularioAlteracao(cliente);
        }

        public ClienteModel RecuperarInformacoesCliente(int id)
        {
            var cliente = ClienteRepositorio.RecuperarInfoCliente(id);
            cliente.Contas = ContaClienteRepositorio.RecuperarContasDoCliente(cliente.IdCliente);

            return cliente;
        }

        public string AlterarCliente(ClienteModel cliente)
        {
            var retornoValidacao = cliente.ValidarCliente();

            if (retornoValidacao == string.Empty)
            {
                ClienteRepositorio.AlterarCliente(cliente);
                return string.Empty;
            }           
            return retornoValidacao;
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
