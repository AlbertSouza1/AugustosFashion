using AugustosFashion.Entidades.ContaBancaria;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using AugustosFashionModels.Entidades.Colaborador;
using System;
using System.Collections.Generic;

namespace AugustosFashion.Entidades.Colaborador
{
    public class ColaboradorModel : UsuarioModel
    {
        public int IdColaborador { get; set; }
        public double Salario { get; set; }
        public int PorcentagemComissao { get; set; }

        public ContaBancariaModel ContaBancaria { get; set; }

        public ColaboradorModel()
        {
            ContaBancaria = new ContaBancariaModel();
        }
        public ColaboradorModel(string nome, string sobreNome, char sexo, DateTime dataNascimento, string email, string cpf, double salario, int porcentagemComissao, EnderecoModel endereco, List<TelefoneModel> telefones, ContaBancariaModel contaBancaria)
         : base(nome, sobreNome)
        {
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Email = email;
            CPF = cpf;
            Salario = salario;
            PorcentagemComissao = porcentagemComissao;
            Endereco = endereco;
            Telefones = telefones;
            ContaBancaria = contaBancaria;
        }

        public string ValidarColaborador()
        {
            var retorno = new ColaboradorValidator().Validate(this);

            if (retorno.IsValid)
                return string.Empty;

            return retorno.ToString();
        }
    }
}
