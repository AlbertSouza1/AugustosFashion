using FluentValidation;

namespace AugustosFashionModels.Entidades.Endereco.CEPs
{
    public class CEPValidator : AbstractValidator<CEP>
    {
        public CEPValidator()
        {
            RuleFor(x => x.ToString()).NotNull().NotEmpty().Length(8).WithMessage("CEP inválido");
        }

    }
}
