using FluentValidation;
using System.Text.RegularExpressions;

namespace AugustosFashionModels.Entidades.Emails
{
    class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(x => x.RetornaValor).Must(EmailValido).WithMessage("E-mail inválido");
        }
        public bool EmailValido(string valor) =>
            Regex.IsMatch(valor, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
    }
}
