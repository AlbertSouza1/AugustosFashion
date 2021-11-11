using AugustosFashion.Entidades;
using Dapper;

namespace AugustosFashion.Repositorios
{
    public static class UsuarioSql
    {
        public static string ObterStringInsertUsuario() => "Insert into Usuarios (Nome, SobreNome, Sexo, DataNascimento, Email, CPF) " +
                "output inserted.IdUsuario " +
                "values (@Nome, @SobreNome, @Sexo, @DataNascimento, @Email, @CPF)";
        public static string ObterStringExclusaoUsuario() => "delete from Usuarios " +
                "where IdUsuario = @IdUsuario";

        public static string ObterStringAlterarUsuario() => @"
        update
            Usuarios
        set
            Nome = @Nome, SobreNome = @SobreNome, Sexo = @Sexo, DataNascimento = @DataNascimento, Email = @Email, CPF = @CPF
        where
            IdUsuario = @IdUsuario;";

        public static string ObterStringRecuperarInfoUsuario() =>
            "select Nome, Sobrenome, Sexo, DataNascimento, Email, CPF from Usuarios where IdUsuario = @IdUsuario";

        public static DynamicParameters MapearPropriedadesDeUsuario(UsuarioModel usuarioModel) {

            var parameters = new DynamicParameters();

            parameters.AddDynamicParams(new
            {
                usuarioModel.NomeCompleto.Nome,
                usuarioModel.NomeCompleto.SobreNome,
                usuarioModel.Sexo,
                usuarioModel.DataNascimento,
                Email = usuarioModel.Email.RetornaValor,
                CPF = usuarioModel.CPF.RetornaValor,
                usuarioModel.IdUsuario
            });

            return parameters;
        }
    }
}
