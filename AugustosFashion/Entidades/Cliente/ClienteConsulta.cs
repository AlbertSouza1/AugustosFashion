using AugustosFashion.Entidades.Endereco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Entidades.Cliente
{
    public class ClienteConsulta
    {
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public string ValorLimiteCompraAPrazo { get; set; }
        public string Observacao { get; set; }
    }
}
