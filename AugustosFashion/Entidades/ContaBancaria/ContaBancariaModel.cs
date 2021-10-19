using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Entidades.ContaBancaria
{
    public class ContaBancariaModel
    {
        public int IdContaBancaria { get; set; }
        public string Banco { get; set; }
        public int Agencia { get; set; }
        public int Conta { get; set; }
        public TipoConta TipoConta { get; set; }
    }
}
