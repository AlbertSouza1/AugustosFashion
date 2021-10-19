using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Entidades.Endereco
{
    public class EnderecoModel
    {
        public EnderecoModel(string cep, string logradouro, int numero, string cidade, string uf, string complemento, string bairro)
        {
            CEP = cep;
            Logradouro = logradouro;
            Numero = numero;
            Cidade = cidade;
            UF = uf;
            Complemento = complemento;
            Bairro = bairro;
        }

        public EnderecoModel(){ }

        public int IdEndereco { get; set; }
        public int IdUsuario { get; set; }
        public string CEP { get; set; }
        public string Logradouro  { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
    }
}
