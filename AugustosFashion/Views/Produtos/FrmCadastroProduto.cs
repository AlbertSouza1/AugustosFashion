using AugustosFashion.Controllers.Produtos;
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

        private void btnCalcularPreco_Click(object sender, EventArgs e)
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
    }
}
