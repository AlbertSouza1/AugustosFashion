﻿using System;
using System.Linq;

namespace AugustosFashionModels.Entidades.Endereco.CEPs
{
    public class CEP
    {
        private string _valor;

        public string RetornaValor { get => _valor; }
        public string RetornaValorFormatado
        {
            get => Convert.ToUInt64(_valor).ToString(@"00000-000");
        }

        public CEP(string valor)
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

        public override string ToString()
        {
            return _valor;
        }

        public static implicit operator CEP(string valor) => new CEP(valor);
    }
}
