using AugustosFashion.Controllers.Pedidos;
using AugustosFashion.Controllers.Pedidos.RelatoriosControllers;
using AugustosFashion.Entidades.Cliente;
using AugustosFashionModels.Entidades.Pedidos;
using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos.Relatorios
{
    public partial class FrmRelatorioVendaProduto : Form
    {
        private readonly RelatorioPedidoProdutoController _relatorioVendaProdutoController;
        private List<RelatorioPedidoProduto> _relatorio;
        private FiltroRelatorioPedidoProduto _filtroRelatorio = new FiltroRelatorioPedidoProduto();

        public FrmRelatorioVendaProduto(RelatorioPedidoProdutoController relatorioVendaProdutoController)
        {
            InitializeComponent();
            _relatorioVendaProdutoController = relatorioVendaProdutoController;
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            AdicionarFiltros();

            ExibirRelatorio();

            gbFiltros.Left = 1000;
        }

        private void AdicionarFiltros()
        {
            _filtroRelatorio.DataInicial = dtpInicial.Value;
            _filtroRelatorio.DataFinal = dtpFinal.Value;
        }

        private void ExibirRelatorio()
        {
            _relatorio = _relatorioVendaProdutoController.ConsultarRelatorio(_filtroRelatorio);
            dgvRelatorioProdutos.DataSource = _relatorio;

            AtualizarTotalizadores(_relatorio);
        }

        private void AtualizarTotalizadores(List<RelatorioPedidoProduto> relatorio)
        {
            lblTotalBruto.Text = relatorio.Sum(x => x.TotalBruto.RetornaValor).ToString("c"); 
            lblTotalLiquido.Text = relatorio.Sum(x => x.TotalLiquido.RetornaValor).ToString("c"); 
            lblTotalDesconto.Text = relatorio.Sum(x => x.TotalDesconto.RetornaValor).ToString("c"); 
            lblLucroTotal.Text = relatorio.Sum(x => x.LucroReais.RetornaValor).ToString("c"); 
        }

        private void FrmRelatorioVendaProduto_Load(object sender, EventArgs e)
        {
            gbFiltros.Left = 1000;
            SetarDataInicialParaPrimeiroDiaDoMes();
        }

        private void SetarDataInicialParaPrimeiroDiaDoMes()
        {
            var data = DateTime.Now;

            var primeiroDiaDoMes = new DateTime(data.Year, data.Month, 1);

            dtpInicial.Value = primeiroDiaDoMes;
        }

        private void BtnMostrarFiltros_Click(object sender, EventArgs e)
        {
            gbFiltros.Left = 741;
        }

        private void BtnFecharFiltro_Click(object sender, EventArgs e)
        {
            gbFiltros.Left = 1000;
        }

        private void BtnBuscarProduto_Click(object sender, EventArgs e)
        {
            _relatorioVendaProdutoController.AbrirFormBuscaProdutos(txtBuscaProduto.Text);
        }

        public void CarregarDadosDeProdutoSelecionado(PedidoProduto produto)
        {
            _filtroRelatorio.IdProduto = produto.IdProduto;
            txtBuscaProduto.Text = produto.Nome;
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            _relatorioVendaProdutoController.AbrirFormBuscaClientes(txtBuscaCliente.Text);
        }
        public void CarregarDadosDeClienteSelecionado(ClienteModel cliente)
        {
            _filtroRelatorio.IdCliente = cliente.IdCliente;
            txtBuscaCliente.Text = cliente.NomeCompleto.ToString();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnLimparProduto_Click(object sender, EventArgs e)
        {
            _filtroRelatorio.IdProduto = 0;
            txtBuscaProduto.Text = string.Empty;
        }

        private void BtnLimparCliente_Click(object sender, EventArgs e)
        {
            _filtroRelatorio.IdCliente = 0;
            txtBuscaCliente.Text = string.Empty;
        }
    }
}
