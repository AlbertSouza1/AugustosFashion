using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashionModels.Entidades.Dinheiros
{
    public class Dinheiro
    {
        private string _valor;

        public Dinheiro(string valor)
        {
            _valor = valor;
        }

        public double RetornaValor 
        {
            get => double.Parse(_valor.Replace('.', ',')); 
        }
        public string ValorFormatado { get => RetornaValor.ToString("c"); }

        public override string ToString() =>       
             RetornaValor.ToString("c");

        public static implicit operator Dinheiro(double valor) => new Dinheiro(valor.ToString());    
        public static implicit operator Dinheiro(string valor) => new Dinheiro(valor);    
    }
}
