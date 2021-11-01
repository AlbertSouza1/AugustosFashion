using System;

namespace AugustosFashionModels.Entidades.Usuario
{
    public class NomeCompleto
    {
        public NomeCompleto(string nome, string sobreNome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("Nome inválido.");
            if (string.IsNullOrWhiteSpace(sobreNome))
                throw new Exception("SobreNome inválido.");

            Nome = nome;
            SobreNome = sobreNome;
        }
        public string Nome { get; set; }
        public string SobreNome { get; set; }

        public override string ToString()
        {
            return $"{Nome} {SobreNome}";
        }

        public NomeCompleto()
        {

        }
    }
}
