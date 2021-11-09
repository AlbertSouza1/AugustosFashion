using AugustosFashion.Entidades.Colaborador;
using AugustosFashionModels.Entidades.Usuario;
using FluentValidation;

namespace AugustosFashionModels.Entidades.Colaborador
{
    public class ColaboradorValidator : AbstractValidator<ColaboradorModel>
    {
        public ColaboradorValidator()
        {
            RuleFor(x => x.Salario).GreaterThan(0).WithMessage("Salário deve ser maior do que 0");
            RuleFor(x => x.PorcentagemComissao).LessThanOrEqualTo(100).WithMessage("Porcentagem de comissão não pode ser maior do que 100%");
            RuleFor(x => x.PorcentagemComissao).GreaterThanOrEqualTo(0).WithMessage("Porcentagem de comissão não pode ser negativa");
            RuleFor(x => x).SetValidator(new UsuarioValidator());
        }
    }
}
