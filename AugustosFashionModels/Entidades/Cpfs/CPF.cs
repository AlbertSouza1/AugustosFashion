using FluentValidation.Results;
using System;
using System.Linq;

namespace AugustosFashionModels.Entidades.Cpfs
{
    public class CPF
    {
        private string _valor;

        public string ValorFormatado
        { 
                get  => Convert.ToUInt64(_valor).ToString(@"000\.000\.000\-00");
        }

        public string RetornaValor { get => _valor; }

        public CPF(string valor)
        {
            _valor = valor;      
        }

        public void RemoverMascara()
        {            
            _valor = new string((from c in _valor
                                 where char.IsDigit(c)
                                       select c
            ).ToArray());
        }

        public ValidationResult ValidarCPF()
        {
            return new CPFValidator().Validate(this);
        } 
        public override string ToString()
        {
            return _valor;
        }

        public static implicit operator CPF(string valor) => new CPF(valor);
    }
}
