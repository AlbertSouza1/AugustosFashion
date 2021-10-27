using System;
using System.Collections.Generic;
using System.Text;

namespace AugustosFashion.Helpers
{
    public static class SexoIndexComboBoxHelper
    {
        public static int RetornarIndexComboBoxSexoCadastrado(char sexo)
        {
            switch (sexo)
            {
                case 'm':
                    return 0;
                case 'f':
                    return 1;
                default:
                    throw new ArgumentOutOfRangeException("Não foi possível recuperar o sexo previamente cadastrado.");
            }
        }
    }
}
