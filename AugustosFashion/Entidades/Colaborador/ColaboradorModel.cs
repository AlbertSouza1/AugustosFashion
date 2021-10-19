using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Entidades.Colaborador
{
    public class ColaboradorModel : UsuarioModel
    {
        public int IdColaborador { get; set; }
        public double Salario { get; set; }
        public int PorcentagemComissao { get; set; }
        public ColaboradorModel(string nome, string sobreNome, char sexo, DateTime dataNascimento, string email, string cpf, double salario, int porcentagemComissao)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Email = email;
            CPF = cpf;
            Salario = salario;
            PorcentagemComissao = porcentagemComissao;
        }
    }
}
