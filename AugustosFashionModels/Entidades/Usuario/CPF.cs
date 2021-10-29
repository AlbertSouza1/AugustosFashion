namespace AugustosFashionModels.Entidades.Usuario
{
    public class CPF
    {
        private string _mensagem = string.Empty;
        public string NumeroCpf { get; set; }
        public string ValidarCPF()
        {
            if (NumeroCpf.Length != 11)
            {
                _mensagem = "CPF inválido";
            }
            return _mensagem;
        }
    }
}
