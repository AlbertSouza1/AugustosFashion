using AugustosFashion.Entidades;
using AugustosFashionModels.Entidades.Cpfs;
using FluentValidation;

namespace AugustosFashionModels.Entidades.Usuario
{
    public class UsuarioValidator : AbstractValidator<UsuarioModel>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Email não pode ser vazio");
            RuleFor(x => x.CPF).SetValidator(new CPFValidator());
        }
    }
}
