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
    public partial class FrmCadastroCliente : Form
    {
        private readonly CadastroClienteController _cadastroClienteController;
        public FrmCadastroCliente(CadastroClienteController cadastroClienteController)
        {
            _cadastroClienteController = cadastroClienteController;
        }
        public FrmCadastroCliente()
        {
            InitializeComponent();
        }
    }
}
