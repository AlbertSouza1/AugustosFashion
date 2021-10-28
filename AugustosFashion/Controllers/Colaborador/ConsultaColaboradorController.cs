using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Colaborador;
using AugustosFashion.Entidades.ContaBancaria;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
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
                ColaboradorModel colaborador = RecuperarInfoColaborador(idColaborador);

                PreencherCampos(frmConsultaColaborador, colaborador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PreencherCampos(FrmConsultaColaborador frmConsultaColaborador, ColaboradorModel colaborador)
        {
            frmConsultaColaborador.ObterDadosParaAlteracao(colaborador);
        }

        public ColaboradorModel RecuperarInfoColaborador(int idColaborador)
        {
            try
            {
                var colaborador = ColaboradorRepositorio.RecuperarInfoColaborador(idColaborador);

                return colaborador;
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

    }
}
