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
                ClienteConsulta cliente = RecuperarInfoCliente(id);
                UsuarioConsulta usuario = RecuperarInfoUsuario(cliente.IdUsuario);
                EnderecoModel endereco = RecuperarInfoEndereco(cliente.IdUsuario);
                List<TelefoneModel> telefones = RecuperarInfoTelefones(cliente.IdUsuario);

                PreencherCamposParaAlteracao(frmAlteracaoCliente, cliente, usuario, endereco, telefones);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PreencherCamposParaAlteracao(FrmAlterarCliente frmAlterarCliente, ClienteConsulta cliente, UsuarioConsulta usuario, EnderecoModel endereco, List<TelefoneModel> telefones)
        {
            frmAlterarCliente.ObterDadosParaAlteracao(cliente, usuario, endereco, telefones);
        }

        public void AlterarCliente(ClienteModel cliente, EnderecoModel endereco, List<TelefoneModel> telefones)
        {
            try
            {
                new ClienteRepositorio().AlterarCliente(cliente, endereco, telefones);
                MessageBox.Show("Cliente alterado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao altear cliente. Erro: " + ex.Message);
            }
        }

        public ClienteConsulta RecuperarInfoCliente(int idCliente)
        {
            try
            {
                var clienteConsulta = new ClienteRepositorio().RecuperarInfoCliente(idCliente);

                return clienteConsulta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public UsuarioConsulta RecuperarInfoUsuario(int idUsuario)
        {
            try
            {
                var usuarioConsulta = UsuarioRepositorio.RecuperarInfoUsuario(idUsuario);

                return usuarioConsulta;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public EnderecoModel RecuperarInfoEndereco(int idUsuario)
        {
            try
            {
                var endereco = EnderecoRepositorio.RecuperarInfoEndereco(idUsuario);

                return endereco;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<TelefoneModel> RecuperarInfoTelefones(int idUsuario)
        {
            try
            {
                var telefones = TelefoneRepositorio.RecuperarInfoTelefones(idUsuario);

                return telefones;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
