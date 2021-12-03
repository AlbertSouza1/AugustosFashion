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
        private readonly RelatorioVendaProdutoController _relatorioVendaProdutoController;
        private FiltroRelatorioVendaProduto _filtroRelatorio = new FiltroRelatorioVendaProduto();

        public FrmRelatorioVendaProduto(RelatorioVendaProdutoController relatorioVendaProdutoController)
        {
            InitializeComponent();
            _relatorioVendaProdutoController = relatorioVendaProdutoController;
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            AdicionarFiltros();

            ExibirRelatorio();
            
        }

        private void AdicionarFiltros()
        {
            _filtroRelatorio.DataInicial = dtpInicial.Value;
            _filtroRelatorio.DataFinal = dtpFinal.Value;
        }

        private void ExibirRelatorio()
        {
            var relatorio = _relatorioVendaProdutoController.ConsultarRelatorio(_filtroRelatorio);
            dgvRelatorioProdutos.DataSource = relatorio;

            AtualizarTotalizadores(relatorio);
        }

        private void AtualizarTotalizadores(List<RelatorioVendaProduto> relatorio)
        {
            lblTotalBruto.Text = relatorio.Sum(x => x.TotalBruto.RetornaValor).ToString("c"); 
            lblTotalLiquido.Text = relatorio.Sum(x => x.TotalLiquido.RetornaValor).ToString("c"); 
            lblTotalDesconto.Text = relatorio.Sum(x => x.TotalDesconto.RetornaValor).ToString("c"); 
            lblLucroTotal.Text = relatorio.Sum(x => x.LucroReais.RetornaValor).ToString("c"); 
        }

        private void FrmRelatorioVendaProduto_Load(object sender, EventArgs e)
        {
            groupBox1.Left = 1000;
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
            groupBox1.Left = 741;
        }

        private void BtnFecharFiltro_Click(object sender, EventArgs e)
        {
            groupBox1.Left = 1000;
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
    }
}
