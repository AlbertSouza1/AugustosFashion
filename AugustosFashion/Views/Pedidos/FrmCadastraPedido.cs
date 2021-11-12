using AugustosFashion.Controllers.Pedidos;
using AugustosFashion.Controllers.Produtos;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Entidades.Colaborador;
using AugustosFashionModels.Entidades.Produtos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos
{
    public partial class FrmCadastraPedido : Form
    {
        private readonly CadastroPedidoController _cadastroPedidoController;

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
        }

        public void CarregarDadosDeColaboradorSelecionado(ColaboradorListagem colaborador)
        {
            txtColaborador.Text = colaborador.NomeCompleto.Nome;
        }

        private void BtnBuscarColaborador_Click(object sender, EventArgs e)
        {
            _cadastroPedidoController.AbrirFormBuscaColaborador(txtBuscarColaborador.Text);
        }

        private void BtnAdicionarAoCarrinho_Click(object sender, EventArgs e)
        {
            SetarDadosDoProdudoCarrinho();

            _produtosNoCarrinho.Add(_produto);
            LimparCamposDeProduto();

            AtualizarCarrinho();
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
    }
}
