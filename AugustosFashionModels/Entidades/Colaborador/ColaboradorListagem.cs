using AugustosFashion.Entidades.Endereco;
using System;
using System.ComponentModel;

namespace AugustosFashion.Entidades.Colaborador
{
    public class ColaboradorListagem
    {
        public int IdColaborador { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public int Idade { get; set; }

        [Browsable(false)]
        public EnderecoModel Endereco { get; set; }
       
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
    }
}
