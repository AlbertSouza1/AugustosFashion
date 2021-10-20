using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Repositorios
{
    public static class TelefoneRepositorio
    {
        public static string ObterStringInsertTelefone() => "Insert into Telefones " +
                "values(@IdUsuario, @Numero)";
    }
}
