using AugustosFashion.Entidades.Endereco;
using System;
using System.ComponentModel;

namespace AugustosFashion.Entidades.Colaborador
{
    public class ColaboradorConsulta
    {
        public int IdColaborador { get; set; }
        public int IdUsuario { get; set; }
        public double Salario { get; set; }
        public int PorcentagemComissao { get; set; }
    }
}
