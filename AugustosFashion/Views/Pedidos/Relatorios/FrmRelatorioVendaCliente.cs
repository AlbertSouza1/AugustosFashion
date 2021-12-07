using AugustosFashion.Controllers.Controls;
using AugustosFashion.Controllers.Pedidos.RelatoriosControllers;
using AugustosFashion.Entidades.Cliente;
using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos.Relatorios
{
    public partial class FrmRelatorioVendaCliente : Form
    {
        private readonly RelatorioPedidoClienteController _relatorioVendaClienteController;
        private List<RelatorioPedidoCliente> _relatorioVendaCliente;
        private FiltroRelatorioPedidoCliente _filtroRelatorio = new FiltroRelatorioPedidoCliente();
        private UcDgvListaController _ucDgvListaController = new UcDgvListaController();
        private int _indexOfSelected = -1;

        public FrmRelatorioVendaCliente(RelatorioPedidoClienteController relatorioVendaClienteController)
        {
            InitializeComponent();
            _relatorioVendaClienteController = relatorioVendaClienteController;
            _ucDgvListaController.RetornarUserControl().SelectedGrid += FrmRelatorioVendaCliente_SelectedGrid;
        }

        private void FrmRelatorioVendaCliente_SelectedGrid(int id)
        {
            _indexOfSelected = _filtroRelatorio.Clientes.FindIndex(x => x.Id == id);

            lblCliente.Text = _filtroRelatorio.Clientes[_indexOfSelected].Nome;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnFecharFiltro_Click(object sender, EventArgs e)
        {
            OcultarAbaDeFiltros();
        }

        private void BtnMostrarFiltros_Click(object sender, EventArgs e)
        {
            MostrarAbaDeFiltros();
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

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            OcultarAbaDeFiltros();

            SetarFiltros();

            ConsultarRelatorio();
        }

        private void ConsultarRelatorio()
        {
            try
            {
                _relatorioVendaCliente = _relatorioVendaClienteController.ConsultarRelatorio(_filtroRelatorio);
                dgvRelatorioClientes.DataSource = _relatorioVendaCliente;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao buscar cliente. Erro: " + ex.Message);
            }

            CalcularTotais();
        }

        private void CalcularTotais()
        {
            if (_relatorioVendaCliente == null)
                return;

            lblTotalCompras.Text = _relatorioVendaCliente.Sum(x => x.QuantidadeCompras).ToString();
            lblTotalBruto.Text = _relatorioVendaCliente.Sum(x => x.TotalBruto.RetornaValor).ToString("c");
            lblTotalDesconto.Text = _relatorioVendaCliente.Sum(x => x.TotalDesconto.RetornaValor).ToString("c");
            lblTotalLiquido.Text = _relatorioVendaCliente.Sum(x => x.TotalLiquido.RetornaValor).ToString("c");
        }

        private void SetarFiltros()
        {
            _filtroRelatorio.DataInicial = dtpInicial.Value;
            _filtroRelatorio.DataFinal = dtpFinal.Value;
            _filtroRelatorio.ValorComprado = decimal.TryParse(txtValorComprado.Text, out decimal valorCompra) ? valorCompra : 0;
            _filtroRelatorio.QuantidadeResultados = int.TryParse(txtQuantidadeResultados.Text, out int qtd) ? qtd : 0;
            _filtroRelatorio.Ordenacao = (EOrdenacaoPedidoCliente)cbOrdenacao.SelectedIndex;
        }

        private void FrmRelatorioVendaCliente_Load(object sender, EventArgs e)
        {
            OcultarAbaDeFiltros();
            cbOrdenacao.SelectedIndex = 0;
            SetarDataInicialParaPrimeiroDiaDoMes();
        }
        private void SetarDataInicialParaPrimeiroDiaDoMes()
        {
            var data = DateTime.Now;

            var primeiroDiaDoMes = new DateTime(data.Year, data.Month, 1);

            dtpInicial.Value = primeiroDiaDoMes;
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            _relatorioVendaClienteController.AbrirFormBuscaClientes(string.Empty);
        }

        private void BtnLimparCliente_Click(object sender, EventArgs e)
        {
            if(_indexOfSelected == -1) return;

            RemoverClienteDaListaDeFiltro();           
        }

        private void RemoverClienteDaListaDeFiltro()
        {
            _filtroRelatorio.Clientes.RemoveAt(_indexOfSelected);
            _ucDgvListaController.AtualizarGrid(_filtroRelatorio.Clientes);
            lblCliente.Text = string.Empty;
        }

        private void OcultarAbaDeFiltros() => groupBox1.Left = 1000;
        private void MostrarAbaDeFiltros() => groupBox1.Left = 741;

        private void txtQuantidadeResultados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void txtValorComprado_Leave(object sender, EventArgs e)
        {
            txtValorComprado.Text = (decimal.TryParse(txtValorComprado.Text, out decimal valorCompra) ? valorCompra : 0).ToString();
        }

        private void BtnMostrarClientes_Click(object sender, EventArgs e)
        {
            if (panelListaClientes.Visible)
                panelListaClientes.Visible = false;
            else
            {
                _ucDgvListaController.AbrirControl(panelListaClientes);
                _ucDgvListaController.AtualizarGrid(_filtroRelatorio.Clientes);
            }
        }
    }
}
