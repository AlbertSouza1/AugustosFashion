using System.Text.RegularExpressions;

namespace AugustosFashionModels.Entidades.Emails
{
    public class Email
    {
        private string _valor;

        public Email(string valor)
        {
            _valor = valor;
        }

        public string RetornaValor { get => _valor; }

        public override string ToString()
        {
            return _valor;
        }

        public static implicit operator Email(string valor) => new Email(valor);

    }
}
