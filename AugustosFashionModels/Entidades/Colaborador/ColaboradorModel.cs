using AugustosFashion.Entidades.ContaBancaria;
using System;

namespace AugustosFashion.Entidades.Colaborador
{
    public class ColaboradorModel : UsuarioModel
    {
        public int IdColaborador { get; set; }
        public double Salario { get; set; }
        public int PorcentagemComissao { get; set; }

        public ContaBancariaModel ContaBancaria { get; set; }

        public ColaboradorModel(string nome, string sobreNome) : base(nome, sobreNome)
        {
            ContaBancaria = new ContaBancariaModel();
        }
        public ColaboradorModel(string nome, string sobreNome, char sexo, DateTime dataNascimento, string email, string cpf, double salario, int porcentagemComissao)
         : base(nome, sobreNome)
        {
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Email = email;
            CPF = cpf;
            Salario = salario;
            PorcentagemComissao = porcentagemComissao;

            ContaBancaria = new ContaBancariaModel();
        }
    }
}
