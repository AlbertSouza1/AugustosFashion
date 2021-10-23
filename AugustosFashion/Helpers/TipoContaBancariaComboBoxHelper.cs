using System;
using System.Collections.Generic;
using System.Text;
using AugustosFashion.Entidades.ContaBancaria;

namespace AugustosFashion.Helpers
{
    public static class TipoContaBancariaComboBoxHelper
    {
        public static int RetornarIndexComboBoxUfCadastrado(TipoConta tipoConta)
        {
            if (tipoConta == TipoConta.ContaCorrente)
                return 1;
            else if (tipoConta == TipoConta.ContaPoupanca)
                return 2;
            else if (tipoConta == TipoConta.ContaSalario)
                return 3;
            else
                return ArgumentOutOfRangeException("Não foi possível recuperar o tipo da conta previamente cadastrada.");
        }
    }
}
