using AugustosFashion.Controllers.Financeiro;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Views.Pedidos;
using AugustosFashionModels.Entidades.ContasClientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AugustosFashion.Views.Financeiro
{
    public partial class FrmContasClientes : Form
    {
        private readonly ContasClientesController _contasClientesController;
        private ClienteModel _cliente;

        public FrmContasClientes(ContasClientesController contasClientesController)
        {
            InitializeComponent();
            _contasClientesController = contasClientesController;
            _cliente = new ClienteModel();
            _contasClientesController.RetornarFrmBuscaClientes().SelectedClient += SelecionarCliente;
        }

        private void SelecionarCliente(ClienteModel cliente)
        {
            _cliente = cliente;
            lblCliente.Text = $"{_cliente.NomeCompleto.Nome} {_cliente.NomeCompleto.SobreNome}";
            _contasClientesController.RetornarFrmBuscaClientes().Close();

            try
            {
                var contas = _contasClientesController.RecuperarContasDoCliente(_cliente.IdCliente);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            _contasClientesController.AbrirFormBuscaClientes(string.Empty);
        }
    }
}
