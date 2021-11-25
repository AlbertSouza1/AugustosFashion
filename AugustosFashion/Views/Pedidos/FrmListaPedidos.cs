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
        private readonly ConsultaPedidoController _consultaPedidoController = new ConsultaPedidoController();

        public FrmListaPedidos(ListaPedidoController listaPedidoController)
        {
            InitializeComponent();
            _listaPedidoController = listaPedidoController;
        }

        private void btnBuscarPedidos_Click(object sender, EventArgs e)
        {
            ListarPedidosPorData();
        }

        private void ListarPedidosPorData()
        {
            var eliminado = RetornarFiltroDeStatusPedido();
            var datas = RetornarDatasParaFiltro();

            try
            {
                var pedidos = _listaPedidoController.ListarPedidos(datas, eliminado);

                ListarPedidosNaGrid(pedidos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao listar pedidos. Erro: " + ex.Message);
            }
        }

        private List<DateTime> RetornarDatasParaFiltro()
        {
            List<DateTime> lista = new List<DateTime>();

            lista.Add(dtpDataInicial.Value.Date);
            lista.Add(dtpDataFinal.Value.Date);

            return lista;
        }

        private bool RetornarFiltroDeStatusPedido() => Convert.ToBoolean(cbStatus.SelectedIndex);
            
        private void ListarPedidosNaGrid(List<PedidoListagem> pedidos)
        {
            dgvPedidos.DataSource = pedidos;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConsultarPedido_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvPedidos.SelectedRows[0].Cells[0].Value);
            _consultaPedidoController.AbrirFormConsultaPedido(id);
        }

        private void FrmListaPedidos_Load(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex = 0;
        }
    }
}
