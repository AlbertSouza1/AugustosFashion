using FluentValidation;
using System.Linq;

namespace AugustosFashionModels.Entidades.Cpfs
{
    public class CPFValidator : AbstractValidator<CPF>
    {
        public CPFValidator()
        {
            RuleFor(x => x.ToString()).Length(11).WithMessage("CPF deve ter 11 números");
            RuleFor(x => x.ToString()).Must(NumerosNaoRepetidos).WithMessage("CPF inválido");
        }

        private bool NumerosNaoRepetidos(string value)
            => string.IsNullOrEmpty(value) ? true : !value.All(x => x.Equals(value.First()));
    }
}
