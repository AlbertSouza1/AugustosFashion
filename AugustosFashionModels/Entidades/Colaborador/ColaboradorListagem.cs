using AugustosFashion.Entidades.Endereco;
using AugustosFashionModels.Entidades.NomesCompletos;
using System.ComponentModel;

namespace AugustosFashion.Entidades.Colaborador
{
    public class ColaboradorListagem
    {
        public int IdColaborador { get; set; }

        [DisplayName("Nome")]
        public NomeCompleto NomeCompleto { get; set; }
        public int Idade { get; set; }
        public EnderecoModel Endereco { get; set; }   
    }
}
