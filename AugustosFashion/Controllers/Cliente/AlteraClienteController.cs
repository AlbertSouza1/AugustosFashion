using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Repositorios;
using AugustosFashion.Views;
using System;
using System.Windows.Forms;

namespace AugustosFashion.Controllers.Cliente
{
    public class AlteraClienteController
    {
        public void AbrirFormularioAlteracao(int id)
        {
            var frmAlteracaoCliente = new FrmAlterarCliente(this);
            frmAlteracaoCliente.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();

            frmAlteracaoCliente.Show();

            try
            {
                ClienteModel cliente = RecuperarInfoCliente(id);
                
                PreencherCamposParaAlteracao(frmAlteracaoCliente, cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível recuperar as informações do cliente. Erro: "+ex.Message);
            }
        }

        public void PreencherCamposParaAlteracao(FrmAlterarCliente frmAlterarCliente, ClienteModel cliente)
        {
            frmAlterarCliente.ObterDadosParaAlteracao(cliente);
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

        public ClienteModel RecuperarInfoCliente(int idCliente)
        {
            try
            {
                var cliente = ClienteRepositorio.RecuperarInfoCliente(idCliente);

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }       
    }
}
