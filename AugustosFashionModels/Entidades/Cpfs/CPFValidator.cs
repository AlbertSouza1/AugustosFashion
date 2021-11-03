using FluentValidation;
using System.Linq;

namespace AugustosFashionModels.Entidades.Cpfs
{
    public class CPFValidator : AbstractValidator<CPF>
    {
        public CPFValidator()
        {
            RuleFor(x => x.ToString()).NotNull().NotEmpty().Length(11);
            RuleFor(x => x.ToString()).Must(NumerosNaoRepetidos).WithMessage("CPF inválido");
        }

        private bool NumerosNaoRepetidos(string value) =>
            !value.All(x => x.Equals(value.First()));
    }
}
