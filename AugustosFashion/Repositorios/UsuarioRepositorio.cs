using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Repositorios
{
    public static class UsuarioRepositorio
    {
        public static string ObterStringInsertUsuario() => "Insert into Usuarios " +
                "output inserted.IdUsuario " +
                "values (@Nome, @SobreNome, @Sexo, @DataNascimento, @Email, @CPF)";
    }
}
