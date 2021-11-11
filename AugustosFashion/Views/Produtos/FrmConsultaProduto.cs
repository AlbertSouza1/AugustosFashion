using AugustosFashion.Controllers.Produtos;
using AugustosFashionModels.Entidades.Produtos;
using AugustosFashionModels.Helpers;
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
            numPrecoCusto.Text = _produto.PrecoCusto.ToString();
            numPrecoVenda.Text = _produto.PrecoVenda.ToString();

        }
    
        private void btnCalcularPreco_Click(object sender, System.EventArgs e)
        {
            var porcentagemLucro = RemoveNaoNumericos.RetornarApenasNumeros(mtxtPorcentagemLucro.Text);

            if (string.IsNullOrWhiteSpace(porcentagemLucro))
            {
                MessageBox.Show("Digite uma porcentagem de lucro para calcular");
                return;
            }

            if (string.IsNullOrWhiteSpace(numPrecoCusto.Text) || int.Parse(numPrecoCusto.Text) == 0)
                MessageBox.Show("Digite um preco de custo para calcular");
            else
                CalcularPrecoVendaPorPorcentagemDeLucro(int.Parse(porcentagemLucro));
        }
        public void CalcularPrecoVendaPorPorcentagemDeLucro(int porcentagemLucro)
        {
            double precoCusto = double.Parse(numPrecoCusto.Text);
            numPrecoVenda.Text = (precoCusto + (precoCusto * porcentagemLucro / 100)).ToString();
        }

        private void BtnAlterar_Click(object sender, System.EventArgs e)
        {
            if (ValidarCamposDeProduto())
            {
                AtualizarDadosDeProdutoParaAlteracao();
                
                try
                {
                    _consultaProdutoController.AlterarProduto(_produto);

                    MessageBox.Show("Produto alterado com sucesso");
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
            _produto.PrecoVenda = int.Parse(numPrecoVenda.Text);
            _produto.PrecoCusto = int.Parse(numPrecoCusto.Text);
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
    }
}
