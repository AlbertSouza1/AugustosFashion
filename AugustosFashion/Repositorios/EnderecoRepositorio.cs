using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Repositorios
{
    public static class EnderecoRepositorio
    {
        public static string ObterStringInsertEndereco() => "Insert into Enderecos " +
                "values (@IdUsuario, @CEP, @Logradouro, @Numero, @Cidade, @UF, @Complemento, @Bairro)";
    }
}
