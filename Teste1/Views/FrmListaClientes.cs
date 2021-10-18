using AugustosFashion.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AugustosFashion.Views
{
    public partial class FrmListaClientes : Form
    {
        private readonly ListaClienteController _listaClienteController;

        public FrmListaClientes(ListaClienteController listaClienteController )
        {
            _listaClienteController = listaClienteController;
        }
        public FrmListaClientes()
        {
            InitializeComponent();
        }
    }
}
