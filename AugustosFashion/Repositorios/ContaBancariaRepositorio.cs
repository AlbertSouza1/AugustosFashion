using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Repositorios
{
    public static class ContaBancariaRepositorio
    {
        public static string ObterStringInsertContaBancaria() => "insert into ContaBancaria values(@IdColaborador, @Banco, @Agencia, @Conta, @TipoConta)";
    }
}
