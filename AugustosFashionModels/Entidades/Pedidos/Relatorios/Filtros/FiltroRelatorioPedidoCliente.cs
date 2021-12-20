using AugustosFashion.Entidades.Cliente;
using AugustosFashionModels.Entidades.Pedidos.Relatorios.Enums;
using System;
using System.Collections.Generic;

namespace AugustosFashionModels.Entidades.Pedidos.Relatorios.Filtros
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
            if (VerificarSeClienteJaEstaInserido(cliente.IdCliente))
                return;

            Clientes.Add(new ListaGenericaModel()
            {
                Nome = $"{cliente.NomeCompleto.Nome} {cliente.NomeCompleto.SobreNome}",
                Id = cliente.IdCliente
            });
        }
        private bool VerificarSeClienteJaEstaInserido(int idCliente)
        {
            var indice = Clientes.FindIndex(x => x.Id == idCliente);

            if (indice == -1)
                return false;
            return true;
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
            ValorBase = string.IsNullOrEmpty(valorBase) ? 0 : decimal.Parse(valorBase);
            QuantidadeResultados = string.IsNullOrEmpty(qtdResultados) ? 0 : int.Parse(qtdResultados);
            Ordenacao = (EOrdenacaoPedidoCliente)ordenacao;
        }

        public bool ValidarFiltros(string valorBase, string qtdResultados)
        {
            if (!decimal.TryParse(valorBase, out _) && !string.IsNullOrEmpty(valorBase))
                return false;
            if (!int.TryParse(qtdResultados, out _) && !string.IsNullOrEmpty(qtdResultados))
                return false;
            
            return true;
        }

        public void LimparFiltros(DateTime inicial, DateTime final)
        {
            DataInicial = inicial;
            DataFinal = final;
            Ordenacao = 0;
            Clientes = new List<ListaGenericaModel>();
            TipoValorBase = 0;
            ValorBase = 0;
            QuantidadeResultados = 0;
        }
    }
}
