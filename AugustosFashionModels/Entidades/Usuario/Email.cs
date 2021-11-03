using System.Text.RegularExpressions;

namespace AugustosFashionModels.Entidades.Usuario
{
    public class Email
    {
        private string _valor;
        private string _mensagemErro;

        public Email(string valor)
        {
            _valor = valor;
            _mensagemErro = "";
        }

        public string RetornarMensagemErro { get => _mensagemErro; }

        //public string RetornarMensagemErro() => _mensagemErro;

        public void ValidarEmail()
        {
            if (!Regex.IsMatch(_valor, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                _mensagemErro = "E-mail inválido";
        }
        public static implicit operator Email(string valor) => new Email(valor);
    }
}
