using AugustosFashion.Controllers.Pedidos;
using AugustosFashion.Controllers.Produtos;
using AugustosFashionModels.Entidades.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos
{
    public partial class FrmBuscaProdutos : Form
    {
        private readonly CadastroPedidoController _cadastroPedidoController;
        private List<ProdutoListagem> _produtos;

        public FrmBuscaProdutos(CadastroPedidoController cadastroPedidoController, string busca)
        {
            InitializeComponent();
            _cadastroPedidoController = cadastroPedidoController;
            txtBuscarProdutos.Text = busca;
        }

        private void FrmBuscaProdutos_Load(object sender, System.EventArgs e)
        {
            _produtos = BuscarProdutos();
            ListarProdutosBuscados(_produtos);
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
                int id = Convert.ToInt32(dgvProdutos.SelectedRows[0].Cells[0].Value);

                var produto = SelecionarProdutoDaLista(id);

                _cadastroPedidoController.RecuperarProdutoSelecionado(InstanciarProdutoSelecionado(produto));
                Close();
            }
            else
                MessageBox.Show("Selecione um produto na lista antes de confirmar.");           
        }

        private ProdutoCarrinho InstanciarProdutoSelecionado(ProdutoListagem produto)
        {
            return new ProdutoCarrinho() {
                IdProduto = produto.IdProduto,
                Nome = produto.Nome,
                Fabricante = produto.Fabricante,
                PrecoCusto = produto.PrecoCusto,
                PrecoVenda = produto.PrecoVenda,
                Estoque = produto.Estoque
            };
        }

        private bool VerificarSeHaProdutoSelecionado() =>
            dgvProdutos.SelectedRows.Count > 0;

        private void BtnBuscarProdutos_Click(object sender, EventArgs e)
        {
            _produtos = BuscarProdutos();
            ListarProdutosBuscados(_produtos);
        }
        private ProdutoListagem SelecionarProdutoDaLista(int id)
        {
            return (from x in _produtos
                           where x.IdProduto == id
                           select x).FirstOrDefault();
        }
    }
}
