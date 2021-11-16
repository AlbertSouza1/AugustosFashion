using AugustosFashion.Controllers.Pedidos;
using AugustosFashion.Controllers.Produtos;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Entidades.Colaborador;
using AugustosFashionModels.Entidades.Pedidos;
using AugustosFashionModels.Entidades.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos
{
    public partial class FrmCadastraPedido : Form
    {
        private readonly CadastroPedidoController _cadastroPedidoController;

        private PedidoModel _pedido = new PedidoModel();

        private ProdutoCarrinho _produto;
        private List<ProdutoCarrinho> _produtosNoCarrinho = new List<ProdutoCarrinho>();



        public FrmCadastraPedido(CadastroPedidoController cadastroPedidoController)
        {
            InitializeComponent();
            _cadastroPedidoController = cadastroPedidoController;
        }

        private void FrmCadastraPedido_Load(object sender, EventArgs e)
        {
        }
        private void BtnBuscarProdutos_Click_1(object sender, EventArgs e)
        {
            _cadastroPedidoController.AbrirFormBuscaProdutos(txtBuscarProdutos.Text);
        }

        public void CarregarDadosDeProdutoSelecionado(ProdutoCarrinho produto)
        {
            _produto = produto;


            txtNome.Text = _produto.Nome;
            txtPreco.Text = _produto.PrecoVenda.ToString();
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            _cadastroPedidoController.AbrirFormBuscaCliente(txtBuscaCliente.Text);
        }

        public void CarregarDadosDeClienteSelecionado(ClienteListagem cliente)
        {
            txtCliente.Text = cliente.NomeCompleto.Nome;
            _pedido.IdCliente = cliente.IdCliente; 
        }

        public void CarregarDadosDeColaboradorSelecionado(ColaboradorListagem colaborador)
        {
            txtColaborador.Text = colaborador.NomeCompleto.Nome;
            _pedido.IdColaborador = colaborador.IdColaborador;
        }

        private void BtnBuscarColaborador_Click(object sender, EventArgs e)
        {
            _cadastroPedidoController.AbrirFormBuscaColaborador(txtBuscarColaborador.Text);
        }

        private void BtnAdicionarAoCarrinho_Click(object sender, EventArgs e)
        {
            SetarDadosDoProdudoCarrinho();

            if (SelecionarProdutoDoCarrinho(_produto.IdProduto) != null)
                AlterarValoresDeProdutoNoCarrinho();
            else
                _produtosNoCarrinho.Add(_produto);

            LimparCamposDeProduto();

            AtualizarCarrinho();
            AtualizarTotaisDoPedido();
        }

        private void AlterarValoresDeProdutoNoCarrinho()
        {
            var produto = SelecionarProdutoDoCarrinho(_produto.IdProduto);

            var index = _produtosNoCarrinho.IndexOf(produto);

            _produtosNoCarrinho[index].Quantidade = _produto.Quantidade;
            _produtosNoCarrinho[index].Desconto = _produto.Desconto;
        }

        private void SetarDadosDoProdudoCarrinho()
        {
            _produto.Quantidade = int.Parse(numQuantidade.Text);
            _produto.Desconto = double.Parse(txtDesconto.Text);
        }

        private void LimparCamposDeProduto()
        {
            txtNome.Text = string.Empty;
            txtPreco.Text = string.Empty;
            txtDesconto.Text = string.Empty;
            numQuantidade.Text = string.Empty;
        }

        private void AtualizarCarrinho()
        {
            dgvCarrinho.DataSource = null;
            dgvCarrinho.DataSource = _produtosNoCarrinho;
        }

        private void AtualizarTotaisDoPedido()
        {
            AtualizarProdutosNoPedido();

            txtTotalBruto.Text = _pedido.TotalBruto.ToString("c");
            txtTotalDesconto.Text = _pedido.TotalDesconto.ToString("c");
            txtTotalLiquido.Text = _pedido.TotalLiquido.ToString("c");
        }

        private void AtualizarProdutosNoPedido()
        {
            _pedido.Produtos.Add(
                new PedidoProdutoModel()
                {
                    IdProduto = _produto.IdProduto,
                    PrecoVenda = _produto.PrecoVenda,
                    Quantidade = _produto.Quantidade,
                    Desconto = _produto.Desconto,
                });
        }

        private void BtnRemoverProdutoCarrinho_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvCarrinho.SelectedRows[0].Cells[0].Value);

            _produtosNoCarrinho.Remove(SelecionarProdutoDoCarrinho(id));

            AtualizarCarrinho();
        }

        private ProdutoCarrinho SelecionarProdutoDoCarrinho(int id)
        {
            return (from x in _produtosNoCarrinho
                    where x.IdProduto == id
                    select x).FirstOrDefault();
        }

        private void BtnFinalizarVenda_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerificarSeNaoHaCamposInvalidos())
                {
                    SetarValoresDoPedido();
                    _cadastroPedidoController.CadastrarPedido(_pedido);

                    MessageBox.Show("Venda realizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao realizar venda. Erro: " + ex.Message);
            }
        }

        private void SetarValoresDoPedido()
        {
            _pedido.FormaPagamento = cbFormaPagamento.SelectedItem.ToString();
            _pedido.DataEmissao = DateTime.Now; 
        }

        private bool VerificarSeNaoHaCamposInvalidos()
        {
            if (dgvCarrinho.RowCount == 0)
            {
                MessageBox.Show("Não é possível realizar uma venda sem produtos.");
                return false;
            }
            else if (string.IsNullOrEmpty(txtCliente.Text))
            {
                MessageBox.Show("Selecione o cliente que está realizando a compra.");
                return false;
            }
            else if (string.IsNullOrEmpty(txtColaborador.Text))
            {
                MessageBox.Show("Selecione o colaborador que está realizando a venda.");
                return false;
            }
            else if (cbFormaPagamento.SelectedItem == null)
            {
                MessageBox.Show("Selecione a forma de pagamento.");
                return false;
            }
            return true;
        }
    }
}
