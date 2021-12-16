using FluentValidation;

namespace AugustosFashionModels.Entidades.Produtos
{
    public class ProdutoValidator : AbstractValidator<ProdutoModel>
    {
        public ProdutoValidator()
        {
            RuleFor(x => x.PrecoCusto.RetornaValor).LessThanOrEqualTo(0).WithMessage("O preço de custo deve ser maior que 0");
            RuleFor(x => x.PrecoVenda.RetornaValor).LessThan(x=>x.PrecoCusto.RetornaValor).WithMessage("O preço de venda não pode ser menor que o preço de custo");
        }
    }
}
