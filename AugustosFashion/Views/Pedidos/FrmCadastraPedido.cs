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
        private ColaboradorModel _colaborador = new ColaboradorModel();
        private ClienteModel _cliente = new ClienteModel();
        private AlteraPedidoController _alteraPedidoController = new AlteraPedidoController();

        private int _quantidadePreviamenteVendida = 0;

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
                EsconderSelecaoDeClienteEColaborador();

                AtualizarTituloParaAlteracao();
                BtnFinalizarPedido.Text = "Salvar Alterações";
            }

            CalcularTotalProduto();
        }
        private void RecuperarInformacoesDePedidoExistente()
        {
            AtualizarCarrinho();
            AtualizarTotaisDoPedido();
            RecuperarClienteDoPedido();
            RecuperarColaboradorDoPedido();
            cbFormaPagamento.SelectedItem = _pedido.FormaPagamento;
        }

        private void RecuperarColaboradorDoPedido()
        {
            _colaborador = _cadastroPedidoController.RetornarColaboradorDoPedido(_pedido.IdColaborador);
            txtColaborador.Text = _colaborador.NomeCompleto.Nome + ' ' + _colaborador.NomeCompleto.SobreNome;
        }

        private void RecuperarClienteDoPedido()
        {
            _cliente = _cadastroPedidoController.RetornarClienteDoPedido(_pedido.IdCliente);
            txtCliente.Text = _cliente.NomeCompleto.Nome + ' ' + _cliente.NomeCompleto.SobreNome;
        }

        private void EsconderSelecaoDeClienteEColaborador()
        {
            BtnBuscarCliente.Visible = false;
            BtnBuscarColaborador.Visible = false;
            txtBuscaCliente.Visible = false;
            txtBuscarColaborador.Visible = false;
            lblSelecionarCliente.Visible = false;
            lblSelecionarColaborador.Visible = false;
        }

        private void BtnBuscarProdutos_Click_1(object sender, EventArgs e)
        {
            _cadastroPedidoController.AbrirFormBuscaProdutos(txtBuscarProdutos.Text);
        }

        public void CarregarDadosDeProdutoSelecionado(PedidoProduto produto)
        {
            _produto = produto;

            RecuperarEstoqueDoProdutoEmAlteracao();
            RecuperarQuantidadePreviamenteVendida();

            txtNome.Text = _produto.Nome;
            txtPreco.Text = _produto.PrecoVenda.ToString();
            numQuantidade.Maximum = _produto.Estoque + _quantidadePreviamenteVendida;
            numQuantidade.Value = _produto.Quantidade;
            txtDesconto.Text = _produto.Desconto.RetornaValor.ToString();

            CalcularPrecoLiquido();
            CalcularTotalProduto();
            CalcularTotalDesconto();
            CalcularTotalProduto();
        }

        private void RecuperarQuantidadePreviamenteVendida()
        {
            _quantidadePreviamenteVendida = _alteraPedidoController.RecuperarQuantidadePreviamenteVendida(_produto.IdProduto, _pedido.IdPedido);
        }

        private void RecuperarEstoqueDoProdutoEmAlteracao()
        {
            if (_produto.Estoque == 0)
            {
                _produto.Estoque = _alteraPedidoController.RecuperarEstoqueDoProduto(_produto.IdProduto);
            }
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            _cadastroPedidoController.AbrirFormBuscaCliente(txtBuscaCliente.Text);
        }

        public void CarregarDadosDeClienteSelecionado(ClienteListagem cliente)
        {
            _cliente.NomeCompleto.Nome = cliente.NomeCompleto.Nome;
            _cliente.Email = cliente.Email;
            _cliente.IdCliente = cliente.IdCliente;

            txtCliente.Text = _cliente.NomeCompleto.Nome;
            _pedido.IdCliente = _cliente.IdCliente;
        }

        public void CarregarDadosDeColaboradorSelecionado(ColaboradorListagem colaborador)
        {
            _colaborador.NomeCompleto.Nome = colaborador.NomeCompleto.Nome;
            _colaborador.IdColaborador = colaborador.IdColaborador;

            txtColaborador.Text = _colaborador.NomeCompleto.Nome;
            _pedido.IdColaborador = _colaborador.IdColaborador;
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

            _pedido.AdicionarProdutoAoCarrinho(_produto);

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

            return true;
        }
        private void SetarDadosDoProdudoCarrinho()
        {
            _produto.Quantidade = int.Parse(numQuantidade.Text);
            _produto.Desconto = decimal.Parse(txtDesconto.Text);
        }

        private void LimparCamposDeProduto()
        {
            txtNome.Text = string.Empty;
            txtPreco.Text = "0";
            txtDesconto.Text = "0";
            numQuantidade.Value = 0;
            txtTotalDescontoProduto.Text = "0";
            txtPrecoLiquido.Text = "0";
            lblTotalProduto.Text = "0";
        }

        private void AtualizarCarrinho()
        {
            dgvCarrinho.DataSource = null;
            dgvCarrinho.DataSource = _pedido.Produtos;
            dgvCarrinho.Columns[3].Visible = false;
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
            int id = RecuperarIdProdutoDaGrid();

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

        private bool EfeutarPedido()
        {
            try
            {
                if (VerificarSeNaoHaCamposInvalidos())
                {
                    SetarInformacoesDoPedido();
                    _cadastroPedidoController.CadastrarPedido(_pedido);

                    MessageBox.Show("Pedido efetuado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Close();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao efetuar pedido. Erro: " + ex.Message);
                return false;
            }
        }

        private void EnviarComprovantePorEmail()
        {
            if (checkEnviarEmail.Checked)
            {
                try
                {
                    _cadastroPedidoController.EnviarEmailParaCliente(_cliente, _pedido);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AlterarPedido()
        {
            if (dgvCarrinho.RowCount == 0)
            {
                MessageBox.Show("Não é possível salvar um pedido sem produtos.");
                return;
            }
            try
            {
                SetarInformacoesDoPedido();
                new AlteraPedidoController().AlterarPedido(_pedido);

                MessageBox.Show("Pedido atualizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao atualizar pedido. Erro: " + ex.Message);
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
                MessageBox.Show("Não é possível efetuar um pedido sem produtos.");
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
            if (_produto.IdProduto == 0)
                return;

            CalcularTotalProduto();
            CalcularTotalDesconto();
            CalcularPrecoLiquido();
        }

        private decimal RetornarValorPreco()
        {
            var precoSemFormatacao = RemoveNaoNumericos.RetornarApenasNumeros(txtPreco.Text);

            decimal preco = string.IsNullOrEmpty(precoSemFormatacao) ? 0 : decimal.Parse(precoSemFormatacao);

            return preco;
        }

        private decimal RetornarValorDesconto()
        {
            decimal desconto = string.IsNullOrEmpty(txtDesconto.Text) ? 0 : decimal.Parse(txtDesconto.Text);

            return desconto;
        }

        private bool ValidarDesconto(decimal preco)
        {
            if (RetornarValorDesconto() > (preco / 100))
            {
                MessageBox.Show("Desconto não pode ser maior que o preço do produto");
                txtDesconto.Text = "0";
                txtTotalDesconto.Text = "0";
                return false;
            }
            return true;
        }

        private void numQuantidade_ValueChanged(object sender, EventArgs e)
        {
            if (_produto.IdProduto == 0)
                return;

                CalcularTotalProduto();
                CalcularTotalDesconto();
                CalcularPrecoLiquido();            
        }

        private void CalcularTotalProduto()
        {
            try
            {
                decimal preco = RetornarValorPreco() / 100;
                int quantidade = Convert.ToInt32(numQuantidade.Value);
                decimal desconto = RetornarValorDesconto();

                lblTotalProduto.Text =
                    ((preco - desconto) * quantidade).ToString("c");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insira valores válidos");
            }
        }

        private void CalcularTotalDesconto()
        {
            try
            {
                int quantidade = Convert.ToInt32(numQuantidade.Value);
                decimal desconto = RetornarValorDesconto();

                txtTotalDescontoProduto.Text =
                    (desconto * quantidade).ToString("c");
            }
            catch (Exception ex)
            {
                txtDesconto.Text = "0";
                numQuantidade.Value = 0;
            }
        }

        private void CalcularPrecoLiquido()
        {
            try
            {
                decimal preco = RetornarValorPreco() / 100;
                decimal desconto = RetornarValorDesconto();

                txtPrecoLiquido.Text =
                    (preco - desconto).ToString("c");
            }
            catch (Exception ex)
            {
                txtDesconto.Text = "0";
                numQuantidade.Value = 0;
                txtPrecoLiquido.Text = "0";
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnFinalizarPedido_Click(object sender, EventArgs e)
        {
            if (_pedido.IdPedido != 0)
                AlterarPedido();
            else
            {
                EfeutarPedido();
                EnviarComprovantePorEmail();
            }

        }

        private void AtualizarTituloParaAlteracao()
        {
            lblTitulo.Text = "Alterar Pedido";
            lblTitulo.Left = 441;
            lblTitulo.Top = 40;
        }

        private void dgvCarrinho_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = RecuperarIdProdutoDaGrid();

            _produto = SelecionarProdutoDoPedido(id);

            CarregarDadosDeProdutoSelecionado(_produto);
        }

        private int RecuperarIdProdutoDaGrid()
        {
            return Convert.ToInt32(dgvCarrinho.SelectedRows[0].Cells[0].Value);
        }

        private void numQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {          
            //if (!char.IsDigit(e.KeyChar))
            //    e.Handled = true;
        }

        private void txtDesconto_KeyUp(object sender, KeyEventArgs e)
        {
            if (_produto.IdProduto == 0)
            {
                txtDesconto.Text = "0";
                return;
            }             

            if (!decimal.TryParse(txtDesconto.Text, out decimal desconto))
            {
                txtDesconto.Text = "0";
            }    

            if (!ValidarDesconto(RetornarValorPreco()))
                return;

            CalcularTotalProduto();
            CalcularTotalDesconto();
            CalcularPrecoLiquido();
        }
    }
}
