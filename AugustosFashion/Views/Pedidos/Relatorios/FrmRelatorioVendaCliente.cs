using AugustosFashion.Controllers.Controls;
using AugustosFashion.Controllers.Pedidos.RelatoriosControllers;
using AugustosFashion.Entidades.Cliente;
using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos.Relatorios
{
    public partial class FrmRelatorioVendaCliente : Form
    {
        private readonly RelatorioPedidoClienteController _relatorioVendaClienteController;
        private RelatorioPedidoClienteViewModel _relatorioPedidoCliente;
        private FiltroRelatorioPedidoCliente _filtroRelatorio = new FiltroRelatorioPedidoCliente();
        private UcDgvListaController _ucDgvListaController = new UcDgvListaController();
        private int _indexClienteSelecionado = -1;

        public FrmRelatorioVendaCliente(RelatorioPedidoClienteController relatorioVendaClienteController)
        {
            InitializeComponent();
            _relatorioPedidoCliente = new RelatorioPedidoClienteViewModel();
            _relatorioVendaClienteController = relatorioVendaClienteController;
            _ucDgvListaController.RetornarUserControl().SelectedGrid += FrmRelatorioVendaCliente_SelectedGrid;
        }

        private void FrmRelatorioVendaCliente_SelectedGrid(int id)
        {
            _indexClienteSelecionado = _filtroRelatorio.EncontrarIndexDoCliente(id);

            lblCliente.Text = _filtroRelatorio.Clientes[_indexClienteSelecionado].Nome;
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

            _filtroRelatorio.AdicionarCliente(cliente);

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
                _relatorioPedidoCliente.Relatorio = _relatorioVendaClienteController.ConsultarRelatorio(_filtroRelatorio);
                dgvRelatorioClientes.DataSource = _relatorioPedidoCliente.Relatorio;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao buscar cliente. Erro: " + ex.Message);
            }

            CalcularTotais();
        }

        private void CalcularTotais()
        {
            if (_relatorioPedidoCliente == null)
                return;

            lblTotalCompras.Text = _relatorioPedidoCliente.TotalCompras.ToString();
            lblTotalBruto.Text = _relatorioPedidoCliente.TotalBruto.ToString();
            lblTotalDesconto.Text = _relatorioPedidoCliente.TotalDesconto.ToString();
            lblTotalLiquido.Text = _relatorioPedidoCliente.TotalLiquido.ToString();
        }

        private void SetarFiltros()
        {
            _filtroRelatorio.SetarFiltros(dtpInicial.Value, dtpFinal.Value, txtValorComprado.Text, txtQuantidadeResultados.Text, cbOrdenacao.SelectedIndex);           
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
            _filtroRelatorio.RemoverCliente(_indexClienteSelecionado);
            _ucDgvListaController.AtualizarGrid(_filtroRelatorio.Clientes);

            LimparDadosDeFiltroCliente();
        }

        private void LimparDadosDeFiltroCliente()
        {
            lblCliente.Text = string.Empty;
            _indexClienteSelecionado = -1;
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
