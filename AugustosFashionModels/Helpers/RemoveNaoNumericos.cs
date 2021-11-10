using System.Linq;

namespace AugustosFashionModels.Helpers
{
    public static class RemoveNaoNumericos
    {
        public static string RetornarApenasNumeros(string texto)
        {
            return new string((from c in texto
                                 where char.IsDigit(c)
                                 select c
            ).ToArray());
        }
    }
}
