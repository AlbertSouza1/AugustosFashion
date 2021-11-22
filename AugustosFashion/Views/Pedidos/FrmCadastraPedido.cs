using AugustosFashion.Controllers.Pedidos;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Entidades.Colaborador;
using AugustosFashionModels.Entidades.Pedidos;
using AugustosFashionModels.Helpers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos
{
    public partial class FrmCadastraPedido : Form
    {
        private readonly CadastroPedidoController _cadastroPedidoController;

        private PedidoModel _pedido;
        private PedidoProduto _produto = new PedidoProduto();

        public FrmCadastraPedido(CadastroPedidoController cadastroPedidoController, PedidoModel pedido)
        {
            InitializeComponent();
            _cadastroPedidoController = cadastroPedidoController;
            _pedido = pedido;
        }

        private void FrmCadastraPedido_Load(object sender, EventArgs e)
        {
            if (_pedido.IdPedido != 0)
            {
                RecuperarInformacoesDePedidoExistente();
            }                

            CalcularTotalProduto();
        }
        private void RecuperarInformacoesDePedidoExistente()
        {
            AtualizarCarrinho();
            AtualizarTotaisDoPedido();
            BloquearSelecaoDeClienteEColaborador();
            RecuperarClienteDoPedido();
            RecuperarColaboradorDoPedido();
            cbFormaPagamento.SelectedItem = _pedido.FormaPagamento;
        }

        private void RecuperarColaboradorDoPedido()
        {
            var colaborador = _cadastroPedidoController.RetornarColaboradorDoPedido(_pedido.IdColaborador);
            txtColaborador.Text = colaborador.NomeCompleto.Nome + ' ' + colaborador.NomeCompleto.SobreNome;
        }

        private void RecuperarClienteDoPedido()
        {
            var cliente = _cadastroPedidoController.RetornarClienteDoPedido(_pedido.IdCliente);
            txtCliente.Text = cliente.NomeCompleto.Nome + ' ' + cliente.NomeCompleto.SobreNome;
        }

        private void BloquearSelecaoDeClienteEColaborador()
        {
            BtnBuscarCliente.Enabled = false;
            BtnBuscarColaborador.Enabled = false;
            txtBuscaCliente.Enabled=false;
            txtBuscarColaborador.Enabled=false;
        }

        private void BtnBuscarProdutos_Click_1(object sender, EventArgs e)
        {
            _cadastroPedidoController.AbrirFormBuscaProdutos(txtBuscarProdutos.Text);
        }

        public void CarregarDadosDeProdutoSelecionado(PedidoProduto produto)
        {
            if (SelecionarProdutoDoPedido(produto.IdProduto) == null)

            _produto = produto;

            txtNome.Text = _produto.Nome;
            txtPreco.Text = _produto.PrecoVenda.ToString();
            numQuantidade.Maximum = _produto.Estoque;
            numQuantidade.Value = 1;

            CalcularPrecoLiquido();
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
            if (!ValidarInformacoesDeProdutoParaAdicionarAoCarrinho())
                return;

            SetarDadosDoProdudoCarrinho();

            var produtoJaInserido = _pedido.SelecionarProdutoDoPedido(_produto.IdProduto);

            if (produtoJaInserido != null)
            {               
                _pedido.AlterarProduto(produtoJaInserido, _produto);
            }
            else
            {
                _pedido.AdicionarProduto(_produto);
            }

            LimparCamposDeProduto();

            AtualizarCarrinho();

            AtualizarTotaisDoPedido();
        }

        private bool ValidarInformacoesDeProdutoParaAdicionarAoCarrinho()
        {
            if (numQuantidade.Value < 1)
            {
                MessageBox.Show("Quantidade deve ser maior que 0");
                return false;
            }
            if (_produto.Estoque < numQuantidade.Value)
            {
                MessageBox.Show($"O produto selecionado possui apenas {_produto.Estoque} itens disponíveis em estoque", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
        private void SetarDadosDoProdudoCarrinho()
        {
            _produto.Quantidade = int.Parse(numQuantidade.Text);
            _produto.Desconto = decimal.Parse(numDesconto.Text);
        }

        private void LimparCamposDeProduto()
        {
            txtNome.Text = string.Empty;
            txtPreco.Text = "0";
            numDesconto.Value = 0;
            numQuantidade.Value = 1;
            txtTotalDescontoProduto.Text = "0";
            txtPrecoLiquido.Text = "0";
            lblTotalProduto.Text = "0";
        }

        private void AtualizarCarrinho()
        {
            dgvCarrinho.DataSource = null;
            dgvCarrinho.DataSource = _pedido.Produtos;
        }

        private void AtualizarTotaisDoPedido()
        {
            txtTotalBruto.Text = _pedido.TotalBruto.ToString();
            txtTotalDesconto.Text = _pedido.TotalDesconto.ToString();
            txtTotalLiquido.Text = _pedido.TotalLiquido.ToString();
        }

        private void BtnRemoverProdutoCarrinho_Click(object sender, EventArgs e)
        {
            RemoverProdutoDoCarrinho();
        }

        private void RemoverProdutoDoCarrinho()
        {
            int id = Convert.ToInt32(dgvCarrinho.SelectedRows[0].Cells[0].Value);

            _pedido.Produtos.Remove(SelecionarProdutoDoPedido(id));

            AtualizarTotaisDoPedido();
            AtualizarCarrinho();
        }
        private PedidoProduto SelecionarProdutoDoPedido(int id)
        {
            return (from x in _pedido.Produtos
                    where x.IdProduto == id
                    select x).FirstOrDefault();
        }
        private void BtnFinalizarVenda_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerificarSeNaoHaCamposInvalidos())
                {
                    SetarInformacoesDoPedido();
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

        private void SetarInformacoesDoPedido()
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

        private void numQuantidade_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularTotalProduto();
            CalcularTotalDesconto();
            CalcularPrecoLiquido();
        }
        private void numDesconto_ValueChanged(object sender, EventArgs e)
        {
            if (numDesconto.Value == 0)
                return;
            if (numDesconto.Value > (decimal.Parse(RemoveNaoNumericos.RetornarApenasNumeros(txtPreco.Text)) / 100))
            {
                MessageBox.Show("Desconto não pode ser maior que o preço do produto");
                numDesconto.Value = 0;
                txtTotalDesconto.Text = "0";
            }               

            CalcularTotalProduto();
            CalcularTotalDesconto();
            CalcularPrecoLiquido();
        }
        private void numQuantidade_ValueChanged(object sender, EventArgs e)
        {
            CalcularTotalProduto();
            CalcularTotalDesconto();
            CalcularPrecoLiquido();
            AvisarSeLimiteNoEstoqueFoiAtingido();
        }
        private void numDesconto_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularTotalProduto();
            CalcularTotalDesconto();
            CalcularPrecoLiquido();
        }
        private void CalcularTotalProduto()
        {
            try
            {
                double preco = double.Parse(RemoveNaoNumericos.RetornarApenasNumeros(txtPreco.Text)) / 100;
                double quantidade = int.Parse(numQuantidade.Text);
                double desconto = double.Parse(numDesconto.Text);

                lblTotalProduto.Text =
                    ((preco - desconto) * quantidade).ToString("c");
            }
            catch (Exception ex)
            {
                numDesconto.Value = 0;
                numQuantidade.Value = 0;
            }
        }
        private void CalcularTotalDesconto()
        {
            try
            {
                double quantidade = int.Parse(numQuantidade.Text);
                double desconto = double.Parse(numDesconto.Text);

                txtTotalDescontoProduto.Text =
                    (desconto * quantidade).ToString("c");
            }
            catch (Exception ex)
            {
                numDesconto.Value = 0;
                numQuantidade.Value = 0;
            }
        }
        private void CalcularPrecoLiquido()
        {
            try
            {
                double preco = double.Parse(RemoveNaoNumericos.RetornarApenasNumeros(txtPreco.Text)) / 100;
                double desconto = double.Parse(numDesconto.Text);

                txtPrecoLiquido.Text =
                    (preco - desconto).ToString("c");
            }
            catch (Exception ex)
            {
                numDesconto.Value = 0;
                numQuantidade.Value = 0;
                txtPrecoLiquido.Text = "0";
            }
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AvisarSeLimiteNoEstoqueFoiAtingido()
        {
            if(numQuantidade.Value >= numQuantidade.Maximum)
            {
                MessageBox.Show($"O produto selecionado possui apenas {_produto.Estoque} itens disponíveis em estoque", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
        }

    }
}
