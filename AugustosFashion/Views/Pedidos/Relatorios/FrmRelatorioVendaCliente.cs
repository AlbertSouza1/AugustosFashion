using AugustosFashion.Controllers.Pedidos.RelatoriosControllers;
using AugustosFashion.Entidades.Cliente;
using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos.Relatorios
{
    public partial class FrmRelatorioVendaCliente : Form
    {
        private readonly RelatorioVendaClienteController _relatorioVendaClienteController;
        private FiltroRelatorioVendaCliente _filtroRelatorio = new FiltroRelatorioVendaCliente();

        public FrmRelatorioVendaCliente(RelatorioVendaClienteController relatorioVendaClienteController)
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
            groupBox1.Left = 1000;
        }

        private void BtnMostrarFiltros_Click(object sender, EventArgs e)
        {
            groupBox1.Left = 741;
        }

        internal void CarregarDadosDeClienteSelecionado(ClienteModel cliente)
        {
            throw new NotImplementedException();
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            SetarFiltros();
        }

        private void SetarFiltros()
        {
            _filtroRelatorio.DataInicial = dtpInicial.Value;
            _filtroRelatorio.DataFinal = dtpFinal.Value;
            _filtroRelatorio.ValorComprado = decimal.Parse(txtValorComprado.Text);
            _filtroRelatorio.QuantidadeResultados = int.Parse(txtQuantidadeResultados.Text);
        }

        private void FrmRelatorioVendaCliente_Load(object sender, EventArgs e)
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

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            _relatorioVendaClienteController.AbrirFormBuscaClientes(txtBuscaCliente.Text);
        }
    }
}
