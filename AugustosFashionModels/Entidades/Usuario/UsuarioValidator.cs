using AugustosFashion.Entidades;
using AugustosFashionModels.Entidades.Cpfs;
using AugustosFashionModels.Entidades.Emails;
using FluentValidation;

namespace AugustosFashionModels.Entidades.Usuario
{
    public class UsuarioValidator : AbstractValidator<UsuarioModel>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Email).SetValidator(new EmailValidator());
            RuleFor(x => x.CPF).SetValidator(new CPFValidator());
        }
    }
}
