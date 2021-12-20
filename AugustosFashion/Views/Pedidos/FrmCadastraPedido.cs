using AugustosFashion.Controllers.Cliente;
using AugustosFashion.Controllers.Colaborador;
using AugustosFashion.Controllers.Pedidos;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Entidades.Colaborador;
using AugustosFashionModels.Entidades.Pedidos;
using AugustosFashionModels.Helpers;
using EnumsNET;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos
{
    public partial class FrmCadastraPedido : Form
    {
        private readonly CadastroPedidoController _cadastroPedidoController;
        private readonly BuscaClienteController _buscaClienteController;
        private readonly AlteraPedidoController _alteraPedidoController;

        private PedidoModel _pedido;
        private PedidoProduto _produto;
        private ColaboradorModel _colaborador;

        private int _quantidadePreviamenteVendida = 0;
        public FrmCadastraPedido(CadastroPedidoController cadastroPedidoController, PedidoModel pedido)
        {
            InitializeComponent();
            _cadastroPedidoController = cadastroPedidoController;
            _buscaClienteController = new BuscaClienteController();
            _pedido = pedido;
            _produto = new PedidoProduto();
            _colaborador = new ColaboradorModel();
            _alteraPedidoController = new AlteraPedidoController();
        }

        private void FrmCadastraPedido_Load(object sender, EventArgs e)
        {
            CarregarComboFormaPagamento();

            if (_pedido.IdPedido != 0)
            {
                RecuperarInformacoesDePedidoExistente();
                EsconderSelecaoDeClienteEColaborador();
                _pedido.SetarTotalLiquidoPreAlteracao(_pedido.TotalLiquido.RetornaValor);
                AtualizarTituloParaAlteracao();
                BtnFinalizarPedido.Text = "Salvar Alterações";
            }

            CalcularTotalProduto();
        }

        private void CarregarComboFormaPagamento()
        {
            var formasPagamento = Enum.GetValues(typeof(EFormaPagamento))
            .Cast<EFormaPagamento>()
            .Select(v => v)
            .ToList();

            foreach (var item in formasPagamento)
            {
                cbFormaPagamento.Items.Add(item.AsString(EnumFormat.Description));
            }
        }

        private void RecuperarInformacoesDePedidoExistente()
        {
            AtualizarCarrinho();
            AtualizarTotaisDoPedido();
            ExibirInformacoesDoCliente();
            RecuperarColaboradorDoPedido();
            cbFormaPagamento.SelectedIndex = (int)_pedido.FormaPagamento;
        }

        private void RecuperarColaboradorDoPedido()
        {
            _colaborador = _cadastroPedidoController.RetornarColaboradorDoPedido(_pedido.IdColaborador);
            txtColaborador.Text = _colaborador.NomeCompleto.Nome + ' ' + _colaborador.NomeCompleto.SobreNome;
        }

        private void ExibirInformacoesDoCliente()
        {
            txtCliente.Text = _pedido.Cliente.NomeCompleto.Nome + ' ' + _pedido.Cliente.NomeCompleto.SobreNome;
            VerificarSeEhAniversarioCliente();
        }

        private void VerificarSeEhAniversarioCliente()
        {
            var mensagem = _pedido.Cliente.VerificarSeEhAniversarioDoCliente();

            if (!string.IsNullOrEmpty(mensagem))
            {
                MessageBox.Show(mensagem);
            }
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
            _buscaClienteController.AbrirFormBuscaCliente();
            _buscaClienteController.RetornarFrmBuscaCliente().SelectedClient += FrmCadastroPedido_RecuperarCliente;
        }

        private void FrmCadastroPedido_RecuperarCliente(ClienteModel cliente)
        {
            _pedido.Cliente = cliente;

            ExibirInformacoesDoCliente();
        }

        private void BtnBuscarColaborador_Click(object sender, EventArgs e)
        {
            var buscaColaboradorController = new BuscaColaboradorController();
            buscaColaboradorController.AbrirFormBuscaColaborador();
            buscaColaboradorController.RetornarFrmBuscaColaborador().SelectedColaborador += FrmCadastraPedido_SelectedColaborador;
        }

        private void FrmCadastraPedido_SelectedColaborador(ColaboradorListagem colaborador)
        {
            _colaborador.NomeCompleto.Nome = colaborador.NomeCompleto.Nome;
            _colaborador.IdColaborador = colaborador.IdColaborador;

            txtColaborador.Text = _colaborador.NomeCompleto.Nome;
            _pedido.IdColaborador = _colaborador.IdColaborador;
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
            if (_produto.IdProduto == 0 || txtNome.Text == string.Empty)
            {
                return false;
            }

            if (numQuantidade.Value < 1)
            {
                MessageBox.Show("Quantidade deve ser maior que 0");
                return false;
            }
            if (numQuantidade.Value > 999_999)
            {
                MessageBox.Show("O limite de items foi ultrapassado.");
                return false;
            }
            if (decimal.Parse(txtDesconto.Text) < 0)
            {
                MessageBox.Show("Desconto não pode ser negativo.");
                return false;
            }

            return true;
        }
        private void SetarDadosDoProdudoCarrinho()
        {
            _produto.Quantidade = int.TryParse(numQuantidade.Text, out int value) ? value : 0;
            _produto.Desconto = decimal.TryParse(txtDesconto.Text, out decimal desconto) ? desconto : 0;
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

            if (id == 0)
                return;

            _pedido.RemoverProduto(id);

            AtualizarTotaisDoPedido();
            AtualizarCarrinho();
        }

        private bool EfeutarPedido()
        {
            try
            {
                var mensagem = _cadastroPedidoController.CadastrarPedido(_pedido);

                if (string.IsNullOrEmpty(mensagem))
                {
                    MessageBox.Show("Pedido efetuado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool AlterarPedido()
        {
            try
            {
                var mensagemRetorno = new AlteraPedidoController().AlterarPedido(_pedido);
                if (string.IsNullOrEmpty(mensagemRetorno))
                {
                    MessageBox.Show("Pedido atualizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show(mensagemRetorno, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void LimparPedido()
        {
            _pedido = new PedidoModel();
            _colaborador = new ColaboradorModel();
            _produto = new PedidoProduto();

            AtualizarCarrinho();

            LimparCamposDeProduto();

            txtCliente.Text = string.Empty;
            txtColaborador.Text = string.Empty;
            cbFormaPagamento.SelectedItem = null;

            AtualizarTotaisDoPedido();
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
            _pedido.SetarInformacoes(cbFormaPagamento.SelectedIndex);

            FinalizarPedido();
        }

        private void FinalizarPedido()
        {
            if (!VerificarSeNaoHaCamposInvalidos())
                return;

            if (_pedido.IdPedido != 0)
            {
                try
                {
                    if (AlterarPedido())
                    {
                        EnviarEmailAlteracaoPedido();                       
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao atualizar pedido. Erro: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    if (EfeutarPedido())
                    {
                        EnviarEmailNovoPedido();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao efetuar pedido. Erro: " + ex.Message);
                }
            }
        }

        private void EnviarEmailNovoPedido()
        {
            if (checkEnviarEmail.Checked)
            {
                try
                {
                    panel1.Visible = true;
                    bgWorkerEmail.RunWorkerAsync(_cadastroPedidoController);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível enviar o e-mail. Erro: " + ex.Message);
                }
            }
            else
            {
                LimparPedido();
            }
        }
        private void EnviarEmailAlteracaoPedido()
        {
            if (checkEnviarEmail.Checked)
            {
                try
                {
                    panel1.Visible = true;
                    bgWorkerEmail.RunWorkerAsync(_alteraPedidoController);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                LimparPedido();
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
            if (e.RowIndex == -1)
                return;

            int id = RecuperarIdProdutoDaGrid();

            if (id == 0)
                return;

            _produto = _pedido.SelecionarProdutoDoPedido(_pedido.RetornarIndiceDoProduto(id));

            CarregarDadosDeProdutoSelecionado(_produto);
        }

        private int RecuperarIdProdutoDaGrid()
        {
            try
            {
                return Convert.ToInt32(dgvCarrinho.SelectedRows[0].Cells[0].Value);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Não há produto selecionado");
                return 0;
            }
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

        private void bgWorkerEmail_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (e.Argument is CadastroPedidoController)
            {
                _cadastroPedidoController.EnviarEmailNovoPedido(_pedido);
            }
            else
            {
                _alteraPedidoController.EnviarEmailAlteracaoPedido(_pedido);
            }
        }

        private void bgWorkerEmail_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if(e.Error == null)
            {
                panel1.Visible = false;
                LimparPedido();
            }            
        }
    }
}
