using AugustosFashion.Controllers.Colaborador;
using AugustosFashion.Entidades.Colaborador;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AugustosFashion.Views.Colaborador
{
    public partial class FrmListaColaboradores : Form
    {
        private readonly ListaColaboradorController _listaColaboradorController;
        public FrmListaColaboradores(ListaColaboradorController listaColaboradorController)
        {
            InitializeComponent();
            _listaColaboradorController = listaColaboradorController;
        }

        private void FrmListaColaboradores_Load(object sender, EventArgs e)
        {
        }

        private void RecuperarTodosOsColaboradoresParaListar()
        {
            try
            {
                List<ColaboradorListagem> listaColaboradores = _listaColaboradorController.ListarColaboradores();

                ListarColaboradores(listaColaboradores);
            }catch(Exception ex)
            {
                MessageBox.Show("Falha ao listar colaboradores. Erro: " + ex.Message);
            }
        }
        private void ListarColaboradores(List<ColaboradorListagem> listaColaboradores)
        {
            dgvColaboradores.DataSource = listaColaboradores;

            dgvColaboradores.Columns[0].HeaderText = "Código";
        }

        private void btnVisualizarColaborador_Click(object sender, EventArgs e)
        {
            if (VerificarSeHaRegistroSelecionado())
            {
                int id = RecuperarIdColaboradorSelecionado();

                this.Close();
                _listaColaboradorController.VisualizarColaborador(id);
            }
            else
            {
                MessageBox.Show("Selecione um cliente na tabela para excluir", "Aviso");
            }
        }
        private int RecuperarIdColaboradorSelecionado()
        {
            int id = Convert.ToInt32(dgvColaboradores.SelectedRows[0].Cells[0].Value);
            return id;
        }
        private bool VerificarSeHaRegistroSelecionado() =>
           dgvColaboradores.SelectedRows.Count == 0 ? false : true;

        private void btnBuscarColaborador_Click(object sender, EventArgs e)
        {
            if (txtBuscaColaborador.Text == string.Empty)
            {
                return;
            }

            if (txtBuscaColaborador.Text == "%")
            {
                RecuperarTodosOsColaboradoresParaListar();
            }
            else if (int.TryParse(txtBuscaColaborador.Text, out int idBuscado))
            {
                BuscarColaboradoresPorId(idBuscado);
            }
            else
            {
                BuscarColaboradoresPorNome(txtBuscaColaborador.Text);
            }
        }

        private void BuscarColaboradoresPorNome(string nomeBuscado)
        {
            try
            {
                var listaColaboradores = _listaColaboradorController.BuscarColaboradoresPorNome(nomeBuscado);

                if (listaColaboradores.Count == 0)
                    MessageBox.Show("Nenhum colaborador encontrado.");

                ListarColaboradores(listaColaboradores);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas ao buscar colaboradores. Erro: " + ex.Message);
            }
        }
        private void BuscarColaboradoresPorId(int idBuscado)
        {
            try
            {
                var listaClientes = _listaColaboradorController.BuscarColaboradoresPorId(idBuscado);

                if (listaClientes.Count == 0)
                    MessageBox.Show("Nenhum cliente encontrado.");

                ListarColaboradores(listaClientes);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
