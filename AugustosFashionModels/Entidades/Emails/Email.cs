using System.Text.RegularExpressions;

namespace AugustosFashionModels.Entidades.Emails
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

        public string RetornaValor { get => _valor; }
        public string RetornarMensagemErro { get => _mensagemErro; }

        //public string RetornarMensagemErro() => _mensagemErro;

        public static implicit operator Email(string valor) => new Email(valor);
    }
}
