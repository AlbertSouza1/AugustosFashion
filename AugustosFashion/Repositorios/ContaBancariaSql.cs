namespace AugustosFashion.Repositorios
{
    public static class ContaBancariaSql
    {
        public static string ObterStringInsertContaBancaria() => "insert into ContaBancaria values(@IdColaborador, @Agencia, @Conta, @TipoConta, @Banco)";

        public static string ObterStringExclusaoConta() => "delete from ContaBancaria where IdColaborador = @IdColaborador";

        public static string ObterStringAlterarContaBancaria() =>
             @"update ContaBancaria set Agencia = @Agencia, Conta = @Conta, TipoConta = @TipoConta, Banco = @Banco  
                where IdColaborador = @IdColaborador";

    }
}
