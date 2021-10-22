using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Entidades.Endereco
{
    public class EnderecoModel
    {
        List<string> _mensagens;
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

        public EnderecoModel(){
            _mensagens = new List<string>();
        }

        public int IdEndereco { get; set; }
        public int IdUsuario { get; set; }
        public string CEP { get; set; }
        public string Logradouro  { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }

        public bool EnderecoEhValido()
        {
            if (CEP.Length != 8)
                _mensagens.Add("CEP inválido");
            if (string.IsNullOrEmpty(Logradouro))
                _mensagens.Add("Logradouro não pode ser vazio");
            if (string.IsNullOrEmpty(Numero.ToString()))
                _mensagens.Add("Número residencial não pode ser vazio");
            if (string.IsNullOrEmpty(Cidade))
                _mensagens.Add("Cidade não pode ser vazia");
            if (string.IsNullOrEmpty(UF))
                _mensagens.Add("Estado não pode ser vazio");
            if (string.IsNullOrEmpty(Bairro))
                _mensagens.Add("Bairro não pode ser vazio");

            if (_mensagens.Count == 0)
                return true;
            else
                return false;

        }
    }
}
