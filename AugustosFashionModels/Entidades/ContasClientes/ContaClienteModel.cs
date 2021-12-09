using AugustosFashionModels.Entidades.Dinheiros;
using System;
using System.ComponentModel;

namespace AugustosFashionModels.Entidades.ContasClientes
{
    public class ContaClienteModel
    {
        public int IdConta { get; set; }
        public int IdCliente { get; set; }
        public int IdPedido { get; set; }
        public Dinheiro Valor { get; set; }
        public DateTime DataEmissao { get; set; }
        [Browsable(false)]
        public bool Pago { get; set; }
        [DisplayName("Pago")]
        public string RetornaPago { get => Pago ? "Sim" : "Não"; }
    }
}
