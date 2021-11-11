using AugustosFashion.Entidades.Endereco;
using Dapper;

namespace AugustosFashion.Repositorios
{
    public static class EnderecoSql
    {
        public static string ObterStringInsertEndereco() => "Insert into Enderecos " +
                "values (@IdUsuario, @CEP, @Logradouro, @Numero, @Cidade, @UF, @Complemento, @Bairro)";

        public static string ObterStringExcluisaoEndereco() => "delete from Enderecos where IdUsuario = @IdUsuario";

        public static string ObterStringAlterarEndereco() => @"
            update 
                Enderecos
            set
                CEP = @CEP, Logradouro = @Logradouro, Numero = @Numero, Cidade = @Cidade, UF = @Uf, Complemento = @Complemento, Bairro = @Bairro
            where
                IdUsuario = @IdUsuario";

        public static string ObterStringRecuperarInfoEndereco() =>
            "select CEP, Logradouro, Numero, Cidade, UF, Complemento, Bairro from Enderecos where IdUsuario = @IdUsuario";

        public static DynamicParameters MapearPropriedadesDeEndereco(EnderecoModel enderecoModel)
        {

            var parameters = new DynamicParameters();

            parameters.AddDynamicParams(new
            {
                enderecoModel.IdUsuario,
                CEP = enderecoModel.CEP.RetornaValor,
                enderecoModel.Logradouro,
                enderecoModel.Numero,
                enderecoModel.Cidade,
                enderecoModel.UF,
                enderecoModel.Complemento,
                enderecoModel.Bairro,
            });

            return parameters;
        }
    }
}
