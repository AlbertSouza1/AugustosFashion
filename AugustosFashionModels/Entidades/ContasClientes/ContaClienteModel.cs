using AugustosFashionModels.Entidades.Dinheiros;
using System;
using System.ComponentModel;

namespace AugustosFashionModels.Entidades.ContasClientes
{
    public class ContaClienteModel
    {
        [DisplayName("Código da Conta")]
        public int IdConta { get; set; }
        
        [DisplayName("Código do Cliente")]
        public int IdCliente { get; set; }
        [DisplayName("Código do Pedido")]
        public int IdPedido { get; set; }
        public Dinheiro Valor { get; set; }
        [DisplayName("Data de Emissão")]
        public DateTime DataEmissao { get; set; }
        
        [DisplayName("Data do Pagamento")]
        public DateTime DataPagamento { get; set; }

        [Browsable(false)]
        public bool Pago { get; set; }
        [DisplayName("Pago")]
        public string RetornaPago { get => Pago ? "Sim" : "Não"; }
    }
}
