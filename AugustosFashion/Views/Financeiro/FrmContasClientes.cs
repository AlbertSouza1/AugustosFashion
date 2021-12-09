using AugustosFashion.Controllers.Financeiro;
using AugustosFashion.Entidades.Cliente;
using AugustosFashionModels.Entidades.ContasClientes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AugustosFashion.Views.Financeiro
{
    public partial class FrmContasClientes : Form
    {
        private readonly ContasClientesController _contasClientesController;
        private ClienteModel _cliente;
        private List<ContaClienteModel> _contas;

        public FrmContasClientes(ContasClientesController contasClientesController)
        {
            InitializeComponent();
            _contasClientesController = contasClientesController;
            _cliente = new ClienteModel();            
        }

        private void SelecionarCliente(ClienteModel cliente)
        {
            _cliente = cliente;
            lblCliente.Text = $"{_cliente.NomeCompleto.Nome} {_cliente.NomeCompleto.SobreNome}";
            _contasClientesController.RetornarFrmBuscaClientes().Close();

            try
            {
                _contas = _contasClientesController.RecuperarContasDoCliente(_cliente.IdCliente);
                dgvContas.DataSource = _contas;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            _contasClientesController.AbrirFormBuscaClientes();
            _contasClientesController.RetornarFrmBuscaClientes().SelectedClient += SelecionarCliente;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPagarConta_Click(object sender, EventArgs e)
        {
            if(VerificarSeHaContaSelecionada())
            {
                int idConta = RecuperarIdDaConta();

                try
                {
                    _contasClientesController.PagarContaDoCliente(idConta);
                    MessageBox.Show("Conta paga com sucesso.");

                    AtualizarDataGrid();
                }catch(Exception ex)
                {
                    MessageBox.Show("Não foi possível pagar a conta do cliente. Erro: " + ex.Message);
                }
            }
        }

        private void AtualizarDataGrid()
        {
            dgvContas.DataSource = null;
            dgvContas.DataSource = _contas;
        }

        private int RecuperarIdDaConta() => Convert.ToInt32(dgvContas.SelectedRows[0].Cells[0].Value);

        private bool VerificarSeHaContaSelecionada()
        {
            if (dgvContas.SelectedRows.Count == 0)
                return false;
            return true;
        }
    }
}
