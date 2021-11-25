using AugustosFashion.Controllers.Colaborador;
using AugustosFashion.Controllers.Pedidos;
using AugustosFashion.Entidades.Colaborador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos
{
    public partial class FrmBuscaColaborador : Form
    {
        private readonly CadastroPedidoController _cadastroPedidoController;

        public FrmBuscaColaborador(CadastroPedidoController cadastroPedidoController, string busca)
        {
            InitializeComponent();
            _cadastroPedidoController = cadastroPedidoController;
            txtBuscar.Text = busca; 
        }

        private void FrmBuscaColaborador_Load(object sender, EventArgs e)
        {
            try
            {
                var colaboradores = BuscarColaboradores(true);
                ListarProdutosBuscados(colaboradores);

            }catch(Exception ex)
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

        private void ListarProdutosBuscados(List<ColaboradorListagem> colaboradores)
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
            if (VerificarSeHaColaboradorSelecionado())
            {
                var colaborador = InstanciarColaboradorSelecionado();
                _cadastroPedidoController.RecuperarColaboradorSelecionado(colaborador);
                Close();
            }
            else
                MessageBox.Show("Selecione um produto na lista antes de confirmar.");
        }
        private bool VerificarSeHaColaboradorSelecionado() =>
          dgvColaboradores.SelectedRows.Count > 0;

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            var colaboradores = BuscarColaboradores(true);
            ListarProdutosBuscados(colaboradores);
        }
    }
}
