using AugustosFashion.Controllers.Pedidos;
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
    }
}
