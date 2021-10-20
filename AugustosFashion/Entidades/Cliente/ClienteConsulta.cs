using AugustosFashion.Entidades.Endereco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Entidades.Cliente
{
    public class ClienteConsulta
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Sexo { get; set; }

        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }

        [Browsable(false)]
        public EnderecoModel Endereco { get; set; }

        [DisplayName("CEP")]
        public string EnderecoCep
        {
            get => Endereco.CEP;
        }
        [DisplayName("Logradouro")]
        public string EnderecoLogradouro
        {
            get => Endereco.Logradouro;
        }
        [DisplayName("Número")]
        public string EnderecoNumero
        {
            get => Endereco.Numero.ToString();
        }
        [DisplayName("Cidade")]
        public string EnderecoCidade
        {
            get => Endereco.Cidade;
        }
        [DisplayName("Estado")]
        public string EnderecoUF
        {
            get => Endereco.UF;
        }
        [DisplayName("Complemento")]
        public string EnderecoComplemento
        {
            get => Endereco.Complemento;
        }
        [DisplayName("Bairro")]
        public string EnderecoBairro
        {
            get => Endereco.Bairro;
        }
    }
}
