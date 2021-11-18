using AugustosFashion.Controllers.Pedidos;
using AugustosFashionModels.Entidades.Pedidos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos
{
    public partial class FrmListaPedidos : Form
    {
        private readonly ListaPedidoController _listaPedidoController;

        public FrmListaPedidos(ListaPedidoController listaPedidoController)
        {
            InitializeComponent();
            _listaPedidoController = listaPedidoController;
        }

        private void btnBuscarPedidos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscaPedidos.Text))
            {
                MessageBox.Show("Digite algo para buscar");
            }
            else if (txtBuscaPedidos.Text == "%")
            {
                ListarTodosPedidos();
            }
        }

        private void ListarTodosPedidos()
        {
            try
            {
                var pedidos = _listaPedidoController.ListarPedidos();

                ListarPedidos(pedidos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao listar pedidos. Erro: " + ex.Message);
            }
        }

        private void ListarPedidos(List<PedidoListagem> pedidos)
        {
            dgvPedidos.DataSource = pedidos;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
