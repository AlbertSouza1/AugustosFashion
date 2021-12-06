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

        public FrmRelatorioVendaCliente(RelatorioPedidoClienteController relatorioVendaClienteController)
        {
            InitializeComponent();
            _relatorioVendaClienteController = relatorioVendaClienteController;
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

            _filtroRelatorio.Clientes.Add(new ListaGenericaModel() {
                Nome = $"{cliente.NomeCompleto.Nome} {cliente.NomeCompleto.SobreNome}",
                Id = cliente.IdCliente 
            });

           // _filtroRelatorio.Clientes[0].IdCliente = cliente.IdCliente;
            txtBuscaCliente.Text = cliente.NomeCompleto.ToString();
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
            _relatorioVendaClienteController.AbrirFormBuscaClientes(txtBuscaCliente.Text);
        }

        private void BtnLimparCliente_Click(object sender, EventArgs e)
        {
           // _filtroRelatorio.Clientes[0].IdCliente = 0; //////////////////////////MEXER AQ
            txtBuscaCliente.Text = string.Empty;
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
            var controller = new UcDgvListaController();

            controller.AbrirControl(panelListaClientes);
            controller.AtualizarGrid(_filtroRelatorio.Clientes);
        }
    }
}
