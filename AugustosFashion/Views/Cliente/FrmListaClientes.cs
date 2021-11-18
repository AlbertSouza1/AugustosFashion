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

        private int RecuperarIdClienteSelecionado()
        {
            int id = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells[0].Value);
            return id;
        }

        private bool VerificarSeHaRegistroSelecionado() =>
            dgvClientes.SelectedRows.Count == 0 ? false : true;

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if(txtNomeBuscado.Text == string.Empty)
            {
                return;
            }

            if (txtNomeBuscado.Text == "%")
            {
                RecuperarTodosOsClientesParaListar();
            }   
            else if(int.TryParse(txtNomeBuscado.Text, out int idBuscado))
            {
                BuscarClientesPorId(idBuscado);
            }
            else
            {
                BuscarClientesPorNome(txtNomeBuscado.Text);
            }
        }

        private void BuscarClientesPorNome(string nomeBuscado)
        {
            try
            {
                var listaClientes = _listaClienteController.BuscarClientesPorNome(nomeBuscado);

                if (listaClientes.Count == 0)
                    MessageBox.Show("Nenhum cliente encontrado.");

                ListarClientes(listaClientes);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BuscarClientesPorId(int idBuscado)
        {
            try
            {
                var listaClientes = _listaClienteController.BuscarClientesPorId(idBuscado);

                if (listaClientes.Count == 0)
                    MessageBox.Show("Nenhum cliente encontrado.");

                ListarClientes(listaClientes);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConsultarCliente_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
