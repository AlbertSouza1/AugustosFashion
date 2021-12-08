using AugustosFashion.Controllers;
using AugustosFashion.Controllers.Cliente;
using AugustosFashion.Controllers.Pedidos;
using AugustosFashion.Controllers.Pedidos.RelatoriosControllers;
using AugustosFashion.Entidades.Cliente;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos
{
    public partial class FrmBuscaClientes : Form
    {
        private readonly CadastroPedidoController _cadastroPedidoController;
        private readonly RelatorioPedidoProdutoController _relatorioVendaProdutoController;
        private readonly RelatorioPedidoClienteController _relatorioVendaClienteController;

        public delegate void SelectedHandler(ClienteModel cliente);
        public event SelectedHandler SelectedClient;

        public FrmBuscaClientes()
        {
            InitializeComponent();
        }
        public FrmBuscaClientes(CadastroPedidoController cadastroPedidoController, string busca)
        {
            InitializeComponent();
            _cadastroPedidoController = cadastroPedidoController;
            txtBuscar.Text = busca;
        }

        public FrmBuscaClientes(RelatorioPedidoProdutoController relatorioVendaProdutoController, string busca)
        {
            InitializeComponent();
            _relatorioVendaProdutoController = relatorioVendaProdutoController;
            txtBuscar.Text = busca;
        }

        public FrmBuscaClientes(RelatorioPedidoClienteController relatorioVendaClienteController, string busca)
        {
            InitializeComponent();
            _relatorioVendaClienteController = relatorioVendaClienteController;
            txtBuscar.Text = busca;
        }

        private void FrmBuscaClientes_Load(object sender, EventArgs e)
        {
            var clientes = BuscarClientes(true);
            ListarClientesBuscados(clientes);
        }

        private List<ClienteListagem> BuscarClientes(bool ativo) => new ListaClienteController().BuscarClientesPorNome(txtBuscar.Text, ativo);

        private void ListarClientesBuscados(List<ClienteListagem> clientes)
        {
            dgvClientes.DataSource = clientes;
        }

        private ClienteModel InstanciarClienteSelecionado()
        {
            return new AlteraClienteController().RecuperarInformacoesCliente(Convert.ToInt32(dgvClientes.SelectedRows[0].Cells[0].Value));
        }

        private bool VerificarSeHaClienteSelecionado() =>
            dgvClientes.SelectedRows.Count > 0;

        private void btnSelecionarCliente_Click(object sender, EventArgs e)
        {
            if (VerificarSeHaClienteSelecionado())
            {
                try
                {
                    var cliente = InstanciarClienteSelecionado();

                    if (_cadastroPedidoController != null)
                        _cadastroPedidoController.RecuperarClienteSelecionado(cliente);
                    else if (_relatorioVendaProdutoController != null)
                        _relatorioVendaProdutoController.RecuperarClienteSelecionado(cliente);
                    else
                        _relatorioVendaClienteController.RecuperarClienteSelecionado(cliente);

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível recuperar o cliente selecionado. Erro: " + ex.Message);
                }
            }
            else
                MessageBox.Show("Selecione um produto na lista antes de confirmar.");
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            var clientes = BuscarClientes(true);
            ListarClientesBuscados(clientes);
        }

        private void dgvClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            try
            {
                var cliente = InstanciarClienteSelecionado();

                SelectedClient?.Invoke(cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao selecionar cliente. Erro: " + ex.Message);
            }
        }
    }
}
