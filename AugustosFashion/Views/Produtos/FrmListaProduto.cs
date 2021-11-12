using AugustosFashion.Controllers.Produtos;
using AugustosFashionModels.Entidades.Produtos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AugustosFashion.Views.Produtos
{
    public partial class FrmListaProduto : Form
    {
        private readonly ListaProdutoController _listaProdutoController;
        private readonly  ConsultaProdutoController _consultaProdutoController = new ConsultaProdutoController();
        private StatusProduto _statusProduto;

        public FrmListaProduto(ListaProdutoController listaProdutoController)
        {
            InitializeComponent();
            _listaProdutoController = listaProdutoController;
            cbStatus.SelectedItem = cbStatus.Items[0];
            _statusProduto = StatusProduto.Ativo;
        }

        private void btnBuscarProdutos_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscaProdutos.Text))
            {
                MessageBox.Show("Digite algo para buscar");
            }
            else if (txtBuscaProdutos.Text == "%")
            {
                ListarTodosProdutos();
            }
            else
                BuscarProdutosPorNome();
        }

        private void ListarTodosProdutos()
        {           
            try
            {
                List<ProdutoListagem> listaColaboradores = _listaProdutoController.ListarProdutos(_statusProduto);

                ListarProdutos(listaColaboradores);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao listar produtos. Erro: " + ex.Message);
            }
        }
        private void BuscarProdutosPorNome()
        {
            try
            {
                List<ProdutoListagem> listaColaboradores = _listaProdutoController.BuscarProdutosPorNome(txtBuscaProdutos.Text, _statusProduto);

                ListarProdutos(listaColaboradores);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao listar produtos. Erro: " + ex.Message);
            }
        }

        private void ListarProdutos(List<ProdutoListagem> produtos)
        {
            dgvProdutos.DataSource = produtos;
        }

        private void btnVisualizarProduto_Click(object sender, EventArgs e)
        {
            if (VerificarSeExisteProdutoSelecionado())
            {
                int id = RecuperarIdDoProdutoSelecionado();

                var produto = _consultaProdutoController.ConsultarProduto(id);

                _consultaProdutoController.AbrirFormConsulta(produto);
                Close();
            }
        }

        private bool VerificarSeExisteProdutoSelecionado() => dgvProdutos.SelectedRows.Count == 1;

        private int RecuperarIdDoProdutoSelecionado() => Convert.ToInt32(dgvProdutos.SelectedRows[0].Cells[0].Value);

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.SelectedItem == cbStatus.Items[0])
                _statusProduto = StatusProduto.Ativo;
            else
                _statusProduto = StatusProduto.Inativo;
        }
    }
}