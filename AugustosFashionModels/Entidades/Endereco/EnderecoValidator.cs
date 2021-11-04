using AugustosFashion.Entidades.Endereco;
using AugustosFashionModels.Entidades.Endereco.CEPs;
using FluentValidation;

namespace AugustosFashionModels.Entidades.Endereco
{
    class EnderecoValidator : AbstractValidator<EnderecoModel>
    {
        public EnderecoValidator()
        {
            RuleFor(x => x.CEP).SetValidator(new CEPValidator());
        }
    }
}
