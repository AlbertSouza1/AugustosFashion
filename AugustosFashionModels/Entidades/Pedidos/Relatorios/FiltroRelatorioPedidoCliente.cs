using AugustosFashion.Entidades.Cliente;
using System;
using System.Collections.Generic;

namespace AugustosFashionModels.Entidades.Pedidos.Relatorios
{
    public class FiltroRelatorioPedidoCliente
    {
        public List<ListaGenericaModel> Clientes { get; private set; }
        public DateTime DataInicial { get; private set; }
        public DateTime DataFinal { get; private set; }
        public int QuantidadeResultados { get; private set; }
        public EOrdenacaoPedidoCliente Ordenacao { get; private set; }
        public ETipoValorBasePedidoCliente TipoValorBase { get; private set; }
        public decimal ValorBase { get; private set; }

        public DateTime DataFinalFormatada { get => new DateTime(DataFinal.Year, DataFinal.Month, DataFinal.Day, 23, 59, 59); }
        public FiltroRelatorioPedidoCliente()
        {
            Clientes = new List<ListaGenericaModel>();
        }

        public int EncontrarIndexDoCliente(int id) => Clientes.FindIndex(x => x.Id == id);

        public void AdicionarCliente(ClienteModel cliente)
        {
            Clientes.Add(new ListaGenericaModel()
            {
                Nome = $"{cliente.NomeCompleto.Nome} {cliente.NomeCompleto.SobreNome}",
                Id = cliente.IdCliente
            });
        }

        public void RemoverCliente(int indexClienteSelecionado)
        {
            if (indexClienteSelecionado == -1)
                return;

            Clientes.RemoveAt(indexClienteSelecionado);
        }

        public void SetarFiltros(DateTime dataInicial, DateTime dataFinal, int acimaDe , string valorBase, string qtdResultados, int ordenacao)
        {
            DataInicial = dataInicial;
            DataFinal = dataFinal;
            TipoValorBase = (ETipoValorBasePedidoCliente) acimaDe;
            ValorBase = decimal.TryParse(valorBase, out decimal valorCompra) ? valorCompra : 0;
            QuantidadeResultados = int.TryParse(qtdResultados, out int qtd) ? qtd : 0;
            Ordenacao = (EOrdenacaoPedidoCliente)ordenacao;
        }
    }
}
