using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Cliente;
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
    public class CadastroClienteController
    {
        public void AbrirFormularioCadastro()
        {
            var frmCadastroCliente = new FrmCadastroCliente(this);
            frmCadastroCliente.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();

            frmCadastroCliente.Show();
        }

        public void CadastrarCliente(ClienteModel cliente, EnderecoModel endereco, List<TelefoneModel> telefones)
        {
            try
            {
                new ClienteRepositorio().CadastrarCliente(cliente, endereco, telefones);
                MessageBox.Show("Cliente cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao cadastrar cliente. Erro: "+ex.Message);
            }
        }

    }
}
