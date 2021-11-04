using FluentValidation;

namespace AugustosFashionModels.Entidades.NomesCompletos
{
    public class NomeCompletoValidator : AbstractValidator<NomeCompleto>
    {
        public NomeCompletoValidator()
        {
            RuleFor(x => x.Nome).NotEqual(x => x.SobreNome).WithMessage("Nome e sobrenome não podem ser iguais");
        }
    }
}
