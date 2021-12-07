using AugustosFashion.Controllers.Controls;
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
        private UcDgvListaController _ucDgvListaControllerClientes = new UcDgvListaController();
        private UcDgvListaController _ucDgvListaControllerProdutos = new UcDgvListaController();
        private int _indexClienteSelecionado = -1;
        private int _indexProdutoSelecionado = -1;

        public FrmRelatorioVendaProduto(RelatorioPedidoProdutoController relatorioVendaProdutoController)
        {
            InitializeComponent();
            _relatorioVendaProdutoController = relatorioVendaProdutoController;
            _ucDgvListaControllerClientes.RetornarUserControl().SelectedGrid += FrmRelatorioVendaCliente_SelectedGrid;
            _ucDgvListaControllerProdutos.RetornarUserControl().SelectedGrid += FrmRelatorioVendaProduto_SelectedGrid;
        }

        private void FrmRelatorioVendaProduto_SelectedGrid(int id)
        {
            _indexProdutoSelecionado = _filtroRelatorio.Produtos.FindIndex(x => x.Id == id);

            lblProduto.Text = _filtroRelatorio.Produtos[_indexProdutoSelecionado].Nome;
        }

        private void FrmRelatorioVendaCliente_SelectedGrid(int id)
        {
            _indexClienteSelecionado = _filtroRelatorio.Clientes.FindIndex(x => x.Id == id);

            lblCliente.Text = _filtroRelatorio.Clientes[_indexClienteSelecionado].Nome;
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            SetarFiltros();

            ConsultarRelatorio();

            gbFiltros.Left = 1000;
        }

        private void SetarFiltros()
        {
            _filtroRelatorio.DataInicial = dtpInicial.Value;
            _filtroRelatorio.DataFinal = dtpFinal.Value;
        }

        private void ConsultarRelatorio()
        {
            try
            {
                _relatorio = _relatorioVendaProdutoController.ConsultarRelatorio(_filtroRelatorio);
                
                dgvRelatorioProdutos.DataSource = _relatorio;

                AtualizarTotalizadores(_relatorio);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao exibir relatório. Erro: " + ex.Message);
            }
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
            _relatorioVendaProdutoController.AbrirFormBuscaProdutos(string.Empty);
        }

        public void CarregarDadosDeProdutoSelecionado(PedidoProduto produto)
        {
            _filtroRelatorio.Produtos.Add(new ListaGenericaModel()
            {
                Nome = produto.Nome,
                Id = produto.IdProduto
            });

            lblProduto.Text = produto.Nome;
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            _relatorioVendaProdutoController.AbrirFormBuscaClientes(string.Empty);
        }
        public void CarregarDadosDeClienteSelecionado(ClienteModel cliente)
        {
            _filtroRelatorio.Clientes.Add(new ListaGenericaModel()
            {
                Nome = $"{cliente.NomeCompleto.Nome} {cliente.NomeCompleto.SobreNome}",
                Id = cliente.IdCliente
            });

            lblCliente.Text = cliente.NomeCompleto.ToString();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnLimparProduto_Click(object sender, EventArgs e)
        {
            if (_indexProdutoSelecionado == -1)
                return;

            RemoverProdutoDaListaDeFiltro();            
        }

        private void RemoverProdutoDaListaDeFiltro()
        {
            _filtroRelatorio.Produtos.RemoveAt(_indexProdutoSelecionado);
            _ucDgvListaControllerProdutos.AtualizarGrid(_filtroRelatorio.Produtos);

            lblProduto.Text = string.Empty;
            _indexProdutoSelecionado = -1;
        }

        private void BtnLimparCliente_Click(object sender, EventArgs e)
        {
            if (_indexClienteSelecionado == -1) 
                return;

            RemoverClienteDaListaDeFiltro();
        }

        private void RemoverClienteDaListaDeFiltro()
        {
            _filtroRelatorio.Clientes.RemoveAt(_indexClienteSelecionado);
            _ucDgvListaControllerClientes.AtualizarGrid(_filtroRelatorio.Clientes);

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
    }
}
