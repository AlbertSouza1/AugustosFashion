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
            RecuperarTodosOsColaboradoresParaListar();
        }

        private void RecuperarTodosOsColaboradoresParaListar()
        {
            List<ColaboradorListagem> listaColaboradores = _listaColaboradorController.ListarColaboradores();

            ListarColaboradores(listaColaboradores);
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

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarColaborador_Click(object sender, EventArgs e)
        {
            if (txtBuscaColaborador.Text != string.Empty)
            {
                try
                {
                    var listaColaboradores = _listaColaboradorController.BuscarColaboradoresPorNome(txtBuscaColaborador.Text);

                    if (listaColaboradores.Count == 0)
                        MessageBox.Show("Nenhum colaborador encontrado.");

                    ListarColaboradores(listaColaboradores);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problemas ao buscar colaboradores. Erro: " + ex.Message);
                }
            }
            else
            {
                RecuperarTodosOsColaboradoresParaListar();
            }
        }
    }
}
