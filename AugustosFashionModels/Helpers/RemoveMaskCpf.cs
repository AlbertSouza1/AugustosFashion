using System.Linq;

namespace AugustosFashion.Helpers
{
    public static class RemoveMaskCpf
    {
        public static string RemoverMaskCpf(string cpf)
        {
            string cpfSemPontos = cpf;

            cpfSemPontos = new string((from c in cpfSemPontos
                                       where char.IsDigit(c)
                                       select c
            ).ToArray());

            return cpfSemPontos;
        }
    }
}
