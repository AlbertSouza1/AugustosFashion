using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using AugustosFashion.Entidades.Usuario;
using AugustosFashion.Repositorios;
using AugustosFashion.Views;
using System;
using System.Collections.Generic;
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
                //UsuarioConsulta usuario = RecuperarInfoUsuario(cliente.IdUsuario);              
                //EnderecoModel endereco = RecuperarInfoEndereco(cliente.IdUsuario);
                //List<TelefoneModel> telefones = RecuperarInfoTelefones(cliente.IdUsuario);
 
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

        public void AlterarCliente(ClienteModel cliente)
        {
            try
            {
                ClienteRepositorio.AlterarCliente(cliente);              
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

        //public UsuarioConsulta RecuperarInfoUsuario(int idUsuario)
        //{
        //    try
        //    {
        //        var usuarioConsulta = UsuarioRepositorio.ObterStringRecuperarInfoUsuario(idUsuario);

        //        return usuarioConsulta;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        //public EnderecoModel RecuperarInfoEndereco(int idUsuario)
        //{
        //    try
        //    {
        //        var endereco = EnderecoRepositorio.RecuperarInfoEndereco(idUsuario);

        //        return endereco;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        //public List<TelefoneModel> RecuperarInfoTelefones(int idUsuario)
        //{
        //    try
        //    {
        //        var telefones = TelefoneRepositorio.RecuperarInfoTelefones(idUsuario);

        //        return telefones;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
