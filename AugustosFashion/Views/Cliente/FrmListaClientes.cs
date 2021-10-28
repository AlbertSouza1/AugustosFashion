using AugustosFashion.Controllers;
using AugustosFashion.Controllers.Cliente;
using AugustosFashion.Entidades.Cliente;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AugustosFashion.Views
{
    public partial class FrmListaClientes : Form
    {
        private readonly ListaClienteController _listaClienteController;

        public FrmListaClientes(ListaClienteController listaClienteController)
        {
            InitializeComponent();

            _listaClienteController = listaClienteController;
        }

        private void FrmListaClientes_Load(object sender, EventArgs e)
        {
            RecuperarTodosOsClientesParaListar();
        }

        private void RecuperarTodosOsClientesParaListar()
        {
            List<ClienteListagem> listaClientes = _listaClienteController.ListarClientes();

            ListarClientes(listaClientes);
        }

        private void ListarClientes(List<ClienteListagem> listaClientes)
        {
            foreach (var item in listaClientes)
            {
                item.Sexo = item.Sexo == "m" ? "Masculino" : "Feminino";
            }

            dgvClientes.DataSource = listaClientes;

            dgvClientes.Columns[0].HeaderText = "Código";
        }

        private void btnExcluirCliente_Click(object sender, EventArgs e)
        {

            if (VerificarSeHaRegistroSelecionado())
            {
                DialogResult result = MessageBox.Show("Você está prestes a excluir este cliente. Deseja prosseguir com esta ação?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int id = RecuperarIdClienteSelecionado();

                    _listaClienteController.ExcluirCliente(id);

                    RecuperarTodosOsClientesParaListar();
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente na tabela para excluir", "Aviso");
            }
        }
        private int RecuperarIdClienteSelecionado()
        {
            int id = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells[0].Value);
            return id;
        }
        private bool VerificarSeHaRegistroSelecionado() =>
            dgvClientes.SelectedRows.Count == 0 ? false : true;

        private void btnAlterarCliente_Click(object sender, EventArgs e)
        {
            if (VerificarSeHaRegistroSelecionado())
            {
                int id = RecuperarIdClienteSelecionado();

                this.Close();
                new AlteraClienteController().AbrirFormularioAlteracao(id);
            }
            else
            {
                MessageBox.Show("Selecione um cliente na tabela para excluir", "Aviso");
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (txtNomeBuscado.Text != string.Empty)
            {
                try
                {
                    var listaClientes = _listaClienteController.BuscarClientesPorNome(txtNomeBuscado.Text);

                    if (listaClientes.Count == 0)
                        MessageBox.Show("Nenhum cliente encontrado.");

                    ListarClientes(listaClientes);

                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }   
            else
            {
                RecuperarTodosOsClientesParaListar();
            }
        }
    }
}
