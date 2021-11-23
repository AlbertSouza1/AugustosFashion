using AugustosFashion.Controllers.Produtos;
using AugustosFashionModels.Entidades.Produtos;
using AugustosFashionModels.Helpers;
using System;
using System.Windows.Forms;

namespace AugustosFashion.Views.Produtos
{
    public partial class FrmCadastroProduto : Form
    {
        private readonly CadastroProdutoController _cadastroProdutoController;
        public FrmCadastroProduto(CadastroProdutoController cadastroProdutoController)
        {
            InitializeComponent();
            _cadastroProdutoController = cadastroProdutoController;
        }
        private void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            if (ValidarCamposDeProduto())
            {
                var produto = InstanciarProdutoParaCadastro();
                try
                {
                    _cadastroProdutoController.CadastrarProduto(produto);

                    MessageBox.Show("Produto cadastrado com sucesso");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao cadastrar produto. Erro: " + ex.Message);
                }
            }
        }

        private ProdutoModel InstanciarProdutoParaCadastro()
        {
            return new ProdutoModel
            {
                Nome = txtNome.Text,
                CodigoBarras = RemoveNaoNumericos.RetornarApenasNumeros(mtxtCodigoBarras.Text),
                Fabricante = txtFabricante.Text,
                PrecoCusto = double.Parse(numPrecoCusto.Text),
                PrecoVenda = double.Parse(numPrecoVenda.Text),
                Estoque = int.Parse(numEstoque.Text)
            };
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

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
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

        private void AtualizarPorcentagemLucro()
        {
            if (!AtribuirZeroACamposNumericosVazios())
                return;

            var precocusto = numPrecoCusto.Value;
            var precoVenda = numPrecoVenda.Value;

            numPorcentagemLucro.Value = ((precoVenda - precocusto) / precocusto * 100);
        }

        private void numPrecoVenda_ValueChanged(object sender, EventArgs e)
        {
            if (!AtribuirZeroACamposNumericosVazios())
                return;

            AtualizarPorcentagemLucro();
        }

        public void CalcularPrecoVendaPorPorcentagemDeLucro()
        {
            if (!AtribuirZeroACamposNumericosVazios())
                return;

            var porcentagemLucro = numPorcentagemLucro.Value;

            var precoCusto = decimal.Parse(numPrecoCusto.Text);
            numPrecoVenda.Value = (precoCusto + (precoCusto * porcentagemLucro / 100));
        }

        private void numPorcentagemLucro_ValueChanged(object sender, EventArgs e)
        {
            if (AtribuirZeroACamposNumericosVazios())
                return;
            CalcularPrecoVendaPorPorcentagemDeLucro();
        }

        private void numPorcentagemLucro_KeyUp(object sender, KeyEventArgs e)
        {
            if (!AtribuirZeroACamposNumericosVazios())
                return;
            CalcularPrecoVendaPorPorcentagemDeLucro();
        }

        private bool AtribuirZeroACamposNumericosVazios()
        {
            if (numPrecoCusto.Text == string.Empty)
            {
                numPrecoCusto.Value = 0;
                numPrecoCusto.Text = "0";
                return false;
            }
                
            if(numPrecoVenda.Text == string.Empty)
            {
                numPrecoVenda.Value = 0;
                numPrecoVenda.Text = "0";
                return false;
            }
               
            if (numPorcentagemLucro.Text == string.Empty)
            {
                numPorcentagemLucro.Value = 0;
                numPorcentagemLucro.Text = "0";
                return false;
            }
            return true;
        }

        private void numPrecoCusto_KeyUp(object sender, KeyEventArgs e)
        {
            if (!AtribuirZeroACamposNumericosVazios())
                return;
        }

        private void numPrecoVenda_KeyUp(object sender, KeyEventArgs e)
        {
            if (!AtribuirZeroACamposNumericosVazios())
                return;
        }
    }
}
