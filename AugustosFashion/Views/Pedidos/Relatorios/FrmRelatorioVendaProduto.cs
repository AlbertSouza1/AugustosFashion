using AugustosFashion.Controllers.Controls;
using AugustosFashion.Controllers.Pedidos.RelatoriosControllers;
using AugustosFashion.Entidades.Cliente;
using AugustosFashionModels.Entidades.Exporatacoes;
using AugustosFashionModels.Entidades.Helpers;
using AugustosFashionModels.Entidades.Pedidos;
using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using AugustosFashionModels.Entidades.Pedidos.Relatorios.Filtros;
using System;
using System.Threading;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos.Relatorios
{
    public partial class FrmRelatorioVendaProduto : Form
    {
        private readonly RelatorioPedidoProdutoController _relatorioVendaProdutoController;
        private RelatorioPedidoProdutoViewModel _relatorio;
        private FiltroRelatorioPedidoProduto _filtroRelatorio = new FiltroRelatorioPedidoProduto();
        private UcDgvListaController _ucDgvListaControllerClientes = new UcDgvListaController();
        private UcDgvListaController _ucDgvListaControllerProdutos = new UcDgvListaController();
        private int _indexClienteSelecionado = -1;
        private int _indexProdutoSelecionado = -1;

        public FrmRelatorioVendaProduto(RelatorioPedidoProdutoController relatorioVendaProdutoController)
        {
            InitializeComponent();
            _relatorio = new RelatorioPedidoProdutoViewModel();
            _relatorioVendaProdutoController = relatorioVendaProdutoController;
            _ucDgvListaControllerClientes.RetornarUserControl().SelectedGrid += FrmRelatorioVendaCliente_SelectedGrid;
            _ucDgvListaControllerProdutos.RetornarUserControl().SelectedGrid += FrmRelatorioVendaProduto_SelectedGrid;
        }
        private void FrmRelatorioVendaProduto_SelectedGrid(int id)
        {
            _indexProdutoSelecionado = _filtroRelatorio.EncontrarIndexDoProduto(id);

            lblProduto.Text = _filtroRelatorio.Produtos[_indexProdutoSelecionado].Nome;
        }

        private void FrmRelatorioVendaCliente_SelectedGrid(int id)
        {
            _indexClienteSelecionado = _filtroRelatorio.EncontrarIndexDoCliente(id);

            lblCliente.Text = _filtroRelatorio.Clientes[_indexClienteSelecionado].Nome;
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            _filtroRelatorio.SetarFiltros(dtpInicial.Value, dtpFinal.Value, cbOrdenacao.SelectedIndex);

            ConsultarRelatorio();

            OcultarAbaDeFiltros();
        }

        private void ConsultarRelatorio()
        {
            try
            {
                _relatorio.Relatorio = _relatorioVendaProdutoController.ConsultarRelatorio(_filtroRelatorio);
                
                dgvRelatorioProdutos.DataSource = _relatorio.Relatorio;

                ExibirTotais();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao exibir relatório. Erro: " + ex.Message);
            }
        }

        private void ExibirTotais()
        {
            lblTotalBruto.Text = _relatorio.TotalBruto.ToString();
            lblTotalLiquido.Text = _relatorio.TotalLiquido.ToString();
            lblTotalDesconto.Text = _relatorio.TotalDesconto.ToString();
            lblLucroTotal.Text = _relatorio.TotalLucro.ToString();
            lblTotalProdutosVendidos.Text = _relatorio.TotalProdutosVendidos.ToString();
        }

        private void FrmRelatorioVendaProduto_Load(object sender, EventArgs e)
        {
            cbOrdenacao.SelectedIndex = 0;
            OcultarAbaDeFiltros();
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
            MostrarAbaDeFiltros();
        }

        private void BtnFecharFiltro_Click(object sender, EventArgs e)
        {
            OcultarAbaDeFiltros();
        }

        private void OcultarAbaDeFiltros() => gbFiltros.Left = 1000;
        private void MostrarAbaDeFiltros() => gbFiltros.Left = 741;

        private void BtnBuscarProduto_Click(object sender, EventArgs e)
        {
            _relatorioVendaProdutoController.AbrirFormBuscaProdutos(string.Empty);
        }

        public void CarregarDadosDeProdutoSelecionado(PedidoProduto produto)
        {
            _filtroRelatorio.AdicionarProduto(produto);

            lblProduto.Text = produto.Nome;
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            _relatorioVendaProdutoController.AbrirFormBuscaClientes(string.Empty);
            _relatorioVendaProdutoController.RetornarFrmBuscaClientes().SelectedClient += FrmRelatorio_SelectClient;
        }

        private void FrmRelatorio_SelectClient(ClienteModel cliente)
        {
            _filtroRelatorio.AdicionarCliente(cliente);

            lblCliente.Text = cliente.NomeCompleto.ToString();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnLimparProduto_Click(object sender, EventArgs e)
        {
            _filtroRelatorio.RemoverProduto(_indexProdutoSelecionado);

            _ucDgvListaControllerProdutos.AtualizarGrid(_filtroRelatorio.Produtos);

            LimparDadosDeFiltroProduto();
        }

        private void LimparDadosDeFiltroProduto()
        {
            lblProduto.Text = string.Empty;
            _indexProdutoSelecionado = -1;
        }

        private void BtnLimparCliente_Click(object sender, EventArgs e)
        {
            _filtroRelatorio.RemoverCliente(_indexClienteSelecionado);

            _ucDgvListaControllerClientes.AtualizarGrid(_filtroRelatorio.Clientes);

            LimparDadosDeFiltroCliente();            
        }

        private void LimparDadosDeFiltroCliente()
        {
            lblCliente.Text = string.Empty;
            _indexClienteSelecionado = -1;
        }

        private void BtnMostrarClientes_Click(object sender, EventArgs e)
        {
            if (panelListaClientes.Visible)
                panelListaClientes.Visible = false;
            else
            {
                 _ucDgvListaControllerClientes.AbrirControl(panelListaClientes);
                _ucDgvListaControllerClientes.AtualizarGrid(_filtroRelatorio.Clientes);
            }
        }

        private void BtnMostrarProdutos_Click(object sender, EventArgs e)
        {
            if (panelListaProdutos.Visible)
                panelListaProdutos.Visible = false;
            else
            {
                _ucDgvListaControllerProdutos.AbrirControl(panelListaProdutos);
                _ucDgvListaControllerProdutos.AtualizarGrid(_filtroRelatorio.Produtos);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                return;

            IniciarExportacao();
        }

        private void IniciarExportacao()
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Arquivo xlsx|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var parametros = new ParametroDeDados();
                    parametros.NomeArquivo = sfd.FileName;
                   
                    backgroundWorker1.RunWorkerAsync(parametros);
                    lblProgressoExport.Visible = true;
                }
            }
        }
      
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string fileName = ((ParametroDeDados)e.Argument).NomeArquivo;
            try
            {
                if (!ExportaPlanilha.Exportar(_relatorio.Relatorio, fileName, "RELATORIO DE PRODUTOS"))
                    MessageBox.Show("Não foi possível exportar o relatório.");
            }catch (Exception ex)
            {
                MessageBox.Show("Falha ao exportar relatório. Erro: " + ex.Message);
                e.Cancel = true;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null && !e.Cancelled)
            {
                Thread.Sleep(100);
                lblProgressoExport.Visible = false;
                MessageBox.Show("Exportação concluída.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
