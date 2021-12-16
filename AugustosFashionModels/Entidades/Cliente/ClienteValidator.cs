using AugustosFashion.Entidades.Cliente;
using AugustosFashionModels.Entidades.Usuario;
using FluentValidation;

namespace AugustosFashionModels.Entidades.Cliente
{
    public class ClienteValidator : AbstractValidator<ClienteModel>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.LimiteCompraAPrazo.RetornaValor).LessThanOrEqualTo(10000).WithMessage("O limite de compra a prazo deve ser menor que R$ 10.000");
            RuleFor(x => x.LimiteCompraAPrazo.RetornaValor).GreaterThanOrEqualTo(0).WithMessage("O limite de compra a prazo não pode ser negativo.");
            RuleFor(x => x).SetValidator(new UsuarioValidator());
        }
    }
}
