using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Entidades.Telefone
{
    public class TelefoneModel
    {
        public TelefoneModel(string numero)
        {
            Numero = numero;
        }
        public TelefoneModel()
        {

        }
        public int IdTelefone { get; set; }
        public int IdUsuario { get; set; }
        public string Numero { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
    }
}
