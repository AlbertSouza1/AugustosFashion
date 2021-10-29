using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using System;
using System.Collections.Generic;

namespace AugustosFashion.Entidades.Cliente
{
    public class ClienteModel : UsuarioModel
    {
        public int IdCliente { get; set; }
        public double  LimiteCompraAPrazo { get; set; }
        public string  Observacao { get; set; }
        public ClienteModel(string nome, string sobreNome, char sexo, DateTime dataNascimento, string email, string cpf, double limiteCompraAPrazo, string observacao, EnderecoModel endereco, List<TelefoneModel> telefones)
        : base(nome, sobreNome)
        {          
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Email = email;
            CPF/*.NumeroCpf*/ = cpf;
            LimiteCompraAPrazo = limiteCompraAPrazo;
            Observacao = observacao;
            Endereco = endereco;
            Telefones = telefones;                    
        }
        public ClienteModel(){ }
        public string VerificarSeEhAniversarioDoCliente() =>
            DataNascimento == DateTime.Now ? $"{NomeCompleto.Nome} está fazendo aniversário hoje." : string.Empty;
    }
}
