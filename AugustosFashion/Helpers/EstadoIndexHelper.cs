﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AugustosFashion.Helpers
{
    public static class EstadoIndexHelper
    {
        public static int RetornarIndexComboBoxUfCadastrado(string uf)
        {
            switch (uf)
            {
                case "AC":
                    return 0;
                case "AL":
                    return 1;
                case "AP":
                    return 2;
                case "AM":
                    return 3;
                case "BA":
                    return 4;
                case "CE":
                    return 5;
                case "DF":
                    return 6;
                case "ES":
                    return 7;
                case "GO":
                    return 8;
                case "MA":
                    return 9;
                case "MT":
                    return 10;
                case "MS":
                    return 11;
                case "MG":
                    return 12;
                case "PA":
                    return 13;
                case "PB":
                    return 14;
                case "PR":
                    return 15;
                case "PE":
                    return 16;
                case "PI":
                    return 17;
                case "RJ":
                    return 18;
                case "RN":
                    return 19;
                case "RS":
                    return 20;
                case "RO":
                    return 21;
                case "RR":
                    return 22;
                case "SC":
                    return 23;
                case "SP":
                    return 24;
                case "SE":
                    return 25;
                case "TO":
                    return 26;
                default:
                    throw new ArgumentOutOfRangeException("Não foi possível carregar a UF cadastrada");
            }
        }
    }
}
