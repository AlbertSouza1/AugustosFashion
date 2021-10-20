using AugustosFashion.Controllers;
using AugustosFashion.Entidades.Cliente;
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

        public FrmListaClientes(ListaClienteController listaClienteController)
        {
            InitializeComponent();

            _listaClienteController = listaClienteController;
        }

        private void FrmListaClientes_Load(object sender, EventArgs e)
        {
            ListarClientes();
        }

        private void ListarClientes()
        {
            List<ClienteConsulta> listaClientes =_listaClienteController.ListarClientes();

            foreach (var item in listaClientes)
            {
                item.Sexo = item.Sexo == "m" ? "Masculino" : "Feminino";
            }

            dgvClientes.DataSource = listaClientes;
        }

        
    }
}
