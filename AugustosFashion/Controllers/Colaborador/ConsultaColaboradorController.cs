using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Colaborador;
using AugustosFashion.Entidades.ContaBancaria;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using AugustosFashion.Entidades.Usuario;
using AugustosFashion.Repositorios;
using AugustosFashion.Views.Colaborador;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AugustosFashion.Controllers.Colaborador
{
    public class ConsultaColaboradorController
    {
        public void AbrirFormConsultaColaborador(int idColaborador)
        {
            var frmConsultaColaborador = new FrmConsultaColaborador(this);
            frmConsultaColaborador.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();

            frmConsultaColaborador.Show();

            try
            {
                ColaboradorConsulta colaborador = RecuperarInfoColaborador(idColaborador);
                //UsuarioConsulta usuario = RecuperarInfoUsuario(colaborador.IdUsuario);
                //EnderecoModel endereco = RecuperarInfoEndereco(colaborador.IdUsuario);
                //List<TelefoneModel> telefones = RecuperarInfoTelefones(colaborador.IdUsuario);
                //ContaBancariaModel contaBancaria = RecuperarInfoContaBancaria(idColaborador);

                //PreencherCampos(frmConsultaColaborador, colaborador/*, usuario, endereco, telefones, contaBancaria*/);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PreencherCampos(FrmConsultaColaborador frmConsultaColaborador, ColaboradorConsulta colaborador, UsuarioConsulta usuario, EnderecoModel endereco, List<TelefoneModel> telefones, ContaBancariaModel contaBancaria)
        {
            frmConsultaColaborador.ObterDadosParaAlteracao(colaborador, usuario, endereco, telefones, contaBancaria);
        }

        public ColaboradorConsulta RecuperarInfoColaborador(int idColaborador)
        {
            try
            {
                var colaboradorConsulta = ColaboradorRepositorio.RecuperarInfoColaborador(idColaborador);

                return colaboradorConsulta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal void AlterarColaborador(ColaboradorModel colaborador, EnderecoModel endereco, List<TelefoneModel> telefones, ContaBancariaModel contaBancaria)
        {
            try
            {
                ColaboradorRepositorio.AlterarColaborador(colaborador, endereco, telefones, contaBancaria);               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ExcluirColaborador(int idColaborador)
        {
            try
            {
                ColaboradorRepositorio.ExcluirColaborador(idColaborador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    //    public UsuarioConsulta RecuperarInfoUsuario(int idUsuario)
    //    {
    //        try
    //        {
    //            var usuarioConsulta = UsuarioRepositorio.ObterStringRecuperarInfoUsuario(idUsuario);

    //            return usuarioConsulta;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message);
    //        }

    //    }
    //    public EnderecoModel RecuperarInfoEndereco(int idUsuario)
    //    {
    //        try
    //        {
    //            var endereco = EnderecoRepositorio.RecuperarInfoEndereco(idUsuario);

    //            return endereco;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message);
    //        }
    //    }
    //    public List<TelefoneModel> RecuperarInfoTelefones(int idUsuario)
    //    {
    //        try
    //        {
    //            var telefones = TelefoneRepositorio.RecuperarInfoTelefones(idUsuario);

    //            return telefones;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message);
    //        }
    //    }
    //    public ContaBancariaModel RecuperarInfoContaBancaria(int idColaborador)
    //    {
    //        try
    //        {
    //            var conta = ContaBancariaRepositorio.RecuperarInfoContaBancaria(idColaborador);

    //            return conta;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message);
    //        }
    //    }
    }
}
