﻿using AugustosFashion.Controllers;
using AugustosFashion.Controllers.Cliente;
using AugustosFashion.Entidades.Cliente;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos
{
    public partial class FrmBuscaClientes : Form
    {

        public delegate void SelectedHandler(ClienteModel cliente);
        public event SelectedHandler SelectedClient;

        public FrmBuscaClientes()
        {
            InitializeComponent();
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
                    RetornarCliente();                   
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

            RetornarCliente();
        }

        private void RetornarCliente()
        {
            try
            {
                var cliente = InstanciarClienteSelecionado();

                SelectedClient?.Invoke(cliente);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao selecionar cliente. Erro: " + ex.Message);
            }
        }
    }
}
