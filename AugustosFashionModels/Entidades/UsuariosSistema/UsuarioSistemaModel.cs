using AugustosFashionModels.Servicos.Criptografias;

namespace AugustosFashionModels.Entidades.UsuariosSistema
{
    public class UsuarioSistemaModel
    {
        public int IdUsuarioSistema { get; set; }
        public int IdColaborador { get; set; }
        public string NomeUsuario { get;}
        public string Senha { get; private set; }

        public UsuarioSistemaModel(string nomeUsuario, string senha)
        {
            NomeUsuario = nomeUsuario;
            Senha = senha;
        }
        public UsuarioSistemaModel(int idColaborador, string nomeUsuario, string senha) 
        {
            IdColaborador = idColaborador;
            NomeUsuario = nomeUsuario;
            Senha= senha;
        }

        public void CriptografarSenha(string chave)
        {
            Senha = Criptografia.Encrypt(Senha, true, chave);
        }
    }
}
