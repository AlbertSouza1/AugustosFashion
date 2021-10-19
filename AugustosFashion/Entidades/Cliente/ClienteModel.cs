using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Entidades.Cliente
{
    public class ClienteModel : UsuarioModel
    {
        public int IdCliente { get; set; }
        public double  LimiteCompraAPrazo { get; set; }
        public string  Observacao { get; set; }
        public ClienteModel(string nome, string sobreNome, char sexo, DateTime dataNascimento, string email, string cpf, double limiteCompraAPrazo, string observacao)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Email = email;
            CPF = cpf;
            LimiteCompraAPrazo = limiteCompraAPrazo;
            Observacao = observacao;
        }
    }
}
