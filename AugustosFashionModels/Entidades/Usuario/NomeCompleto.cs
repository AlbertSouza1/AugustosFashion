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
        public string Nome { get; }
        public string SobreNome { get; }

        public override string ToString()
        {
            return $"{Nome} {SobreNome}";
        }
    }
}
