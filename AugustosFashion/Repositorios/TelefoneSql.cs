namespace AugustosFashion.Repositorios
{
    public static class TelefoneSql
    {
        public static string ObterStringInsertTelefone() => "Insert into Telefones " +
                "values(@IdUsuario, @Numero, @TipoTelefone)";
        public static string ObterStringExclusaoTelefone() => "delete from Telefones " +
               "where IdUsuario = @IdUsuario";

        internal static string ObterStringAlterarTelefone() => @"
            update
	            Telefones
            set
	            Numero = @Numero
            where
	            IdUsuario = @IdUsuario and IdTelefone = @IdTelefone;";

        public static string ObterStringRecuperarInfoTelefones() =>
            "select IdTelefone, IdUsuario, Numero, TipoTelefone from Telefones where IdUsuario = @IdUsuario";
    }
}
