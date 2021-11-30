using AugustosFashion.Controllers.Logins;
using AugustosFashionModels.Entidades.UsuariosSistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AugustosFashion.Views.Logins
{
    public partial class FrmRegistrar : Form
    {
        private readonly RegistraUsuarioController _registraUsuarioController;

        public FrmRegistrar(RegistraUsuarioController registraUsuarioController)
        {
            InitializeComponent();
            _registraUsuarioController = registraUsuarioController;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            if(!_registraUsuarioController.VerificarSeIdColaboradorEhValido(int.Parse(txtIdColaborador.Text)))
            {
                MessageBox.Show("Colaborador não encontrado. Verifique o código inserido e tente novamente.");
                return;
            }
            try
            {                
                _registraUsuarioController.RegistrarUsuario(InstanciarUsuarioSistema());

                MessageBox.Show("Conta criada com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível registrar o usuário no sistema. Erro: " + ex.Message);
            }
        }

        private bool ValidarCampos()
        {
            if(!int.TryParse(txtIdColaborador.Text, out int id)) {               
                MessageBox.Show("É necessário informar o código de colaborador do usuário.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNomeUsuario.Text))
            {
                MessageBox.Show("É necessário informar um nome de usuário.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("É necessário informar uma senha.");
                return false;
            }
            return true;
        }

        private UsuarioSistemaModel InstanciarUsuarioSistema()
        {
            return new UsuarioSistemaModel(
                idColaborador: int.Parse(txtIdColaborador.Text),
                nomeUsuario: txtNomeUsuario.Text,
                senha: txtSenha.Text
                );       
        }
    }
}
