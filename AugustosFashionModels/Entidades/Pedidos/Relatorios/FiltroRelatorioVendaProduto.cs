using System;

namespace AugustosFashionModels.Entidades.Pedidos.Relatorios
{
    public class FiltroRelatorioVendaProduto
    {
        public int IdProduto { get; set; }
        public int IdCliente { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
