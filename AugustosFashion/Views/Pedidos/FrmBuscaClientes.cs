﻿using AugustosFashion.Controllers;
using AugustosFashion.Controllers.Cliente;
using AugustosFashion.Controllers.Pedidos;
using AugustosFashion.Entidades.Cliente;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos
{
    public partial class FrmBuscaClientes : Form
    {
        private readonly CadastroPedidoController _cadastroPedidoController;

        public FrmBuscaClientes(CadastroPedidoController cadastroPedidoController, string busca)
        {
            InitializeComponent();
            _cadastroPedidoController = cadastroPedidoController;
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
                var cliente = InstanciarClienteSelecionado();
                _cadastroPedidoController.RecuperarClienteSelecionado(cliente);
                Close();
            }
            else
                MessageBox.Show("Selecione um produto na lista antes de confirmar.");
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            var clientes = BuscarClientes(true);
            ListarClientesBuscados(clientes);
        }
    }
}
