using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using System;
using System.Collections.Generic;

namespace AugustosFashion.Entidades
{
    public abstract class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public char Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public EnderecoModel Endereco { get; set; }
        public List<TelefoneModel> Telefones { get; set; }

        public UsuarioModel()
        {
            Endereco = new EnderecoModel();
            Telefones = new List<TelefoneModel>();
        }
    }
}
