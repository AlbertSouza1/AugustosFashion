namespace AugustosFashionModels.Entidades.UsuariosSistema
{
    public class UsuarioSistemaModel
    {
        public int IdUsuarioSistema { get; set; }
        public int IdColaborador { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }

        public UsuarioSistemaModel(string nomeUsuario, string senha)
        {
            NomeUsuario = nomeUsuario;
            Senha = senha;
        }
        public UsuarioSistemaModel() {}
    }
}
