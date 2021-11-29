namespace AugustosFashionModels.Entidades.Dinheiros
{
    public class Dinheiro
    {
        private decimal _valor;

        public Dinheiro(decimal valor)
        {
            _valor = valor;
        }

        public decimal RetornaValor 
        {
            get => _valor; 
        }
        public string ValorFormatado { get => RetornaValor.ToString("c"); }

        public override string ToString() =>       
             RetornaValor.ToString("c");

        public static implicit operator Dinheiro(decimal valor) => new Dinheiro(valor);    
    }
}
