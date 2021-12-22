using AugustosFashion.Controllers.Produtos;
using AugustosFashionModels.Entidades.Produtos;
using System;
using System.Windows.Forms;

namespace AugustosFashion.Views.Produtos
{
    public partial class FrmConsultaProduto : Form
    {
        private readonly ConsultaProdutoController _consultaProdutoController;
        private readonly ProdutoModel _produto;

        public FrmConsultaProduto(ConsultaProdutoController consultaProdutoController, ProdutoModel produto)
        {
            InitializeComponent();
            _consultaProdutoController = consultaProdutoController;
            _produto = produto;
            PreencherCampos();
        }

        private void PreencherCampos()
        {
            txtNome.Text = _produto.Nome;
            txtFabricante.Text = _produto.Fabricante;
            mtxtCodigoBarras.Text = _produto.CodigoBarras;
            numEstoque.Text = _produto.Estoque.ToString();
            numPrecoCusto.Text = _produto.PrecoCusto.RetornaValor.ToString();
            numPrecoVenda.Text = _produto.PrecoVenda.RetornaValor.ToString();
        }

        public void CalcularPrecoVendaPorPorcentagemDeLucro()
        {
            double precoCusto = double.Parse(numPrecoCusto.Text);
            int porcentagemLucro = Convert.ToInt32(numPorcentagemLucro.Value);
            numPrecoVenda.Text = (precoCusto + (precoCusto * porcentagemLucro / 100)).ToString();
        }

        private void BtnAlterar_Click(object sender, System.EventArgs e)
        {
            if (ValidarCamposDeProduto())
            {
                AtualizarDadosDeProdutoParaAlteracao();
                
                try
                {
                    var retorno = _consultaProdutoController.AlterarProduto(_produto);

                    if (string.IsNullOrEmpty(retorno))
                    {
                        MessageBox.Show("Produto alterado com sucesso");
                        return;
                    }
                    MessageBox.Show(retorno);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao alterar produto. Erro: " + ex.Message);
                }
            }
        }
        private void AtualizarDadosDeProdutoParaAlteracao()
        {
            _produto.Nome = txtNome.Text;
            _produto.CodigoBarras = mtxtCodigoBarras.Text;
            _produto.Fabricante = txtFabricante.Text;
            _produto.Estoque = int.Parse(numEstoque.Text);
            _produto.PrecoVenda = Convert.ToDecimal(numPrecoVenda.Value);
            _produto.PrecoCusto = Convert.ToDecimal(numPrecoCusto.Value);
        }
        private bool ValidarCamposDeProduto()
        {
            bool validacoes = true;

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                validacoes = false;
                MessageBox.Show("Nome não pode ser vazio.");
            }
            else if (string.IsNullOrEmpty(mtxtCodigoBarras.Text))
            {
                validacoes = false;
                MessageBox.Show("Código de barras não pode ser vazio.");
            }
            else if (string.IsNullOrEmpty(txtFabricante.Text))
            {
                validacoes = false;
                MessageBox.Show("Fabricante não pode ser vazio.");
            }
            else if (string.IsNullOrEmpty(numEstoque.Text))
            {
                validacoes = false;
                MessageBox.Show("Estoque inválido.");
            }
            else if (string.IsNullOrEmpty(numPrecoCusto.Text) || double.Parse(numPrecoCusto.Text) == 0)
            {
                validacoes = false;
                MessageBox.Show("Preço de custo não pode ser vazio.");
            }
            else if (string.IsNullOrEmpty(numPrecoVenda.Text) || double.Parse(numPrecoVenda.Text) == 0)
            {
                validacoes = false;
                MessageBox.Show("Preço de venda não pode ser vazio.");
            }

            return validacoes;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Você está prestes a inativar este produto. Deseja prosseguir com esta ação?", "Confirmação",
                MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _consultaProdutoController.InativarProduto(_produto.IdProduto);
                    MessageBox.Show("Produto inativado com sucesso.");                   
  
                    Close();
                    new ListaProdutoController().AbrirFormListaProduto();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao inativar produto. Erro: " + ex.Message);
                }
            }
        }

        private void btnAdicionarEstoque_Click(object sender, EventArgs e)
        {
            _produto.Estoque += int.Parse(numAddEstoque.Text);
            PreencherCampos();
        }

        private void btnAtivarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                _consultaProdutoController.AtivarProduto(_produto.IdProduto);
                MessageBox.Show("Produto ativado com sucesso.");

                Close();
                new ListaProdutoController().AbrirFormListaProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao ativar produto. Erro: " + ex.Message);
            }
        }

        private void FrmConsultaProduto_Load(object sender, EventArgs e)
        {
            if(_produto.Status == EStatusProduto.Inativo)
            {   
                btnExcluir.Visible = false;
                btnAtivarProduto.Visible = true;
            }
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool AtribuirZeroACamposNumericosVazios()
        {
            if (numPrecoCusto.Text == string.Empty || numPrecoCusto.Value < 0)
            {
                numPrecoCusto.Value = 0;
                numPrecoCusto.Text = "0";
                return false;
            }

            if (numPrecoVenda.Text == string.Empty || numPrecoVenda.Value < 0)
            {
                numPrecoVenda.Value = 0;
                numPrecoVenda.Text = "0";
                return false;
            }

            if (numPorcentagemLucro.Text == string.Empty || numPorcentagemLucro.Value < 0)
            {
                numPorcentagemLucro.Value = 0;
                numPorcentagemLucro.Text = "0";
                return false;
            }
            return true;
        }

        private void numPrecoCusto_ValueChanged(object sender, EventArgs e)
        {
            if (!AtribuirZeroACamposNumericosVazios())
                return;

            if (numPrecoVenda.Value != 0)
            {
                CalcularPrecoVendaPorPorcentagemDeLucro();
            }
        }

        private void numPrecoCusto_KeyUp(object sender, KeyEventArgs e)
        {
            if (!AtribuirZeroACamposNumericosVazios())
                return;

            if (numPrecoVenda.Value != 0)
            {
                CalcularPrecoVendaPorPorcentagemDeLucro();
            }
        }

        private void numPrecoVenda_ValueChanged(object sender, EventArgs e)
        {
            if (!AtribuirZeroACamposNumericosVazios())
                return;

            ValidarPrecoVenda();
            AtualizarPorcentagemLucro();
        }

        private void numPrecoVenda_KeyUp(object sender, KeyEventArgs e)
        {
            if (!AtribuirZeroACamposNumericosVazios())
                return;
        }

        private void AtualizarPorcentagemLucro()
        {
            var precocusto = numPrecoCusto.Value > 0 ? numPrecoCusto.Value : 1;
            var precoVenda = numPrecoVenda.Value;
            var porcentagemLucro = ((precoVenda - precocusto) / precocusto * 100);

            if (porcentagemLucro > numPorcentagemLucro.Maximum)
                porcentagemLucro = numPorcentagemLucro.Maximum;

            numPorcentagemLucro.Value = porcentagemLucro > 0 ? porcentagemLucro : 0;
        }

        private void numPorcentagemLucro_ValueChanged(object sender, EventArgs e)
        {
            if (!AtribuirZeroACamposNumericosVazios())
                return;

            CalcularPrecoVendaPorPorcentagemDeLucro();
        }

        private void numPorcentagemLucro_KeyUp(object sender, KeyEventArgs e)
        {
            if(!AtribuirZeroACamposNumericosVazios())
                return;

            CalcularPrecoVendaPorPorcentagemDeLucro();
        }
        private void ValidarPrecoVenda()
        {
            if (numPrecoVenda.Value < numPrecoCusto.Value)
            {
                numPrecoVenda.Value = numPrecoCusto.Value;
            }
        }
    }
}
