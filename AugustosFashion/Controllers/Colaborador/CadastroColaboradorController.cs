using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Colaborador;
using AugustosFashion.Entidades.ContaBancaria;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
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
    public class CadastroColaboradorController
    {
        public void AbrirFormCadastroColaborador()
        {
            var frmCadastroColaborador = new FrmCadastroColaboradores(this);
            frmCadastroColaborador.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();

            frmCadastroColaborador.Show();
        }
        public bool CadastrarColaborador(ColaboradorModel colaborador, EnderecoModel endereco, List<TelefoneModel> telefones, ContaBancariaModel contaBancaria)
        {
            try
            {
                ColaboradorRepositorio.CadastrarColaborador(colaborador, endereco, telefones, contaBancaria);              
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}
