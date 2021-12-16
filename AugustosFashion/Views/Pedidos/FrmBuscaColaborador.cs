using AugustosFashion.Controllers.Colaborador;
using AugustosFashion.Entidades.Colaborador;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos
{
    public partial class FrmBuscaColaborador : Form
    {
        public delegate void SelectedHandler(ColaboradorListagem colaborador);
        public event SelectedHandler SelectedColaborador;

        public FrmBuscaColaborador()
        {
            InitializeComponent();
        }

        private void FrmBuscaColaborador_Load(object sender, EventArgs e)
        {
            try
            {
                var colaboradores = BuscarColaboradores(true);
                ListarColaboradoresBuscados(colaboradores);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<ColaboradorListagem> BuscarColaboradores(bool ativo)
        {
            try
            {
                return new ListaColaboradorController().BuscarColaboradoresPorNome(txtBuscar.Text, ativo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ListarColaboradoresBuscados(List<ColaboradorListagem> colaboradores)
        {
            dgvColaboradores.DataSource = colaboradores;
        }

        private ColaboradorListagem InstanciarColaboradorSelecionado()
        {
            var colaborador = new ColaboradorListagem();

            colaborador.IdColaborador = Convert.ToInt32(dgvColaboradores.SelectedRows[0].Cells[0].Value);
            colaborador.NomeCompleto.Nome = dgvColaboradores.SelectedRows[0].Cells[1].Value.ToString();

            return colaborador;
        }

        private void btnSelecionarColaborador_Click(object sender, EventArgs e)
        {
            if (!VerificarSeHaColaboradorSelecionado())
            {
                MessageBox.Show("Selecione um colaborador na lista antes de confirmar.");
                return;
            }

            var colaborador = InstanciarColaboradorSelecionado();

            SelectedColaborador?.Invoke(colaborador);
            Close();                            
        }
        private bool VerificarSeHaColaboradorSelecionado() =>
          dgvColaboradores.SelectedRows.Count > 0;

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            var colaboradores = BuscarColaboradores(true);
            ListarColaboradoresBuscados(colaboradores);
        }
    }
}
