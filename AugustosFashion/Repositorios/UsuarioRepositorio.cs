namespace AugustosFashion.Repositorios
{
    public static class UsuarioRepositorio
    {
        public static string ObterStringInsertUsuario() => "Insert into Usuarios " +
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
    }
}
