using AugustosFashion.Controllers.Pedidos;
using AugustosFashion.Controllers.Produtos;
using AugustosFashionModels.Entidades.Produtos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos
{
    public partial class FrmBuscaProdutos : Form
    {
        private readonly CadastroPedidoController _cadastroPedidoController;

        public FrmBuscaProdutos(CadastroPedidoController cadastroPedidoController, string busca)
        {
            InitializeComponent();
            _cadastroPedidoController = cadastroPedidoController;
            txtBuscarProdutos.Text = busca;
        }

        private void FrmBuscaProdutos_Load(object sender, System.EventArgs e)
        {
            var produtos = BuscarProdutos();
            ListarProdutosBuscados(produtos);
        }

        private List<ProdutoListagem> BuscarProdutos() => new ListaProdutoController().BuscarProdutosPorNome(txtBuscarProdutos.Text, StatusProduto.Ativo);

        private void ListarProdutosBuscados(List<ProdutoListagem> produtos)
        {
            dgvProdutos.DataSource = produtos;
        }

        internal void btnSelecionarProduto_Click(object sender, EventArgs e)
        {
            if (VerificarSeHaProdutoSelecionado())
            {
                var produto = InstanciarProdutoSelecionado();
                _cadastroPedidoController.RecuperarProdutoSelecionado(produto);
                Close();
            }
            else
                MessageBox.Show("Selecione um produto na lista antes de confirmar.");           
        }

        private ProdutoCarrinho InstanciarProdutoSelecionado()
        {
            return new ProdutoCarrinho() {
                IdProduto = Convert.ToInt32(dgvProdutos.SelectedRows[0].Cells[0].Value),
                Nome = dgvProdutos.SelectedRows[0].Cells[1].Value.ToString(),
                Fabricante = dgvProdutos.SelectedRows[0].Cells[2].Value.ToString(),
                PrecoVenda = Convert.ToDouble(dgvProdutos.SelectedRows[0].Cells[3].Value)
            };
        }

        private bool VerificarSeHaProdutoSelecionado() =>
            dgvProdutos.SelectedRows.Count > 0;

        private void BtnBuscarProdutos_Click(object sender, EventArgs e)
        {
            var produtos = BuscarProdutos();
            ListarProdutosBuscados(produtos);
        }
    }
}
