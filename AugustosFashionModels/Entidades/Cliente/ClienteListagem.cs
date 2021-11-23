using AugustosFashion.Entidades.Endereco;
using AugustosFashionModels.Entidades.Emails;
using AugustosFashionModels.Entidades.NomesCompletos;
using System;
using System.ComponentModel;

namespace AugustosFashion.Entidades.Cliente
{
    public class ClienteListagem
    {
        public int IdCliente { get; set; }

        [DisplayName("Nome")]
        public NomeCompleto NomeCompleto { get; set; }
        public Email Email { get; set; }
        public string Sexo { get; set; }
        public int Idade { get; set; }

        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        public EnderecoModel Endereco { get; set; }

        public ClienteListagem()
        {
            NomeCompleto = new NomeCompleto();
        }
    }
}
