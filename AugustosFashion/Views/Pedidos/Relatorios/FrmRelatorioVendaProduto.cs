﻿using AugustosFashion.Controllers.Controls;
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

            gbFiltros.Left = 1000;
        }

        private void ConsultarRelatorio()
        {
            try
            {
                _relatorio.Relatorio = _relatorioVendaProdutoController.ConsultarRelatorio(_filtroRelatorio);
                
                dgvRelatorioProdutos.DataSource = _relatorio.Relatorio;

                CalcularTotais();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao exibir relatório. Erro: " + ex.Message);
            }
        }

        private void CalcularTotais()
        {
            lblTotalBruto.Text = _relatorio.TotalBruto.ToString();
            lblTotalLiquido.Text = _relatorio.TotalLiquido.ToString();
            lblTotalDesconto.Text = _relatorio.TotalDesconto.ToString();
            lblLucroTotal.Text = _relatorio.TotalLucro.ToString();
        }

        private void FrmRelatorioVendaProduto_Load(object sender, EventArgs e)
        {
            cbOrdenacao.SelectedIndex = 0;
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
            _filtroRelatorio.AdicionarProduto(produto);

            lblProduto.Text = produto.Nome;
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            _relatorioVendaProdutoController.AbrirFormBuscaClientes(string.Empty);
        }
        public void CarregarDadosDeClienteSelecionado(ClienteModel cliente)
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
    }
}
