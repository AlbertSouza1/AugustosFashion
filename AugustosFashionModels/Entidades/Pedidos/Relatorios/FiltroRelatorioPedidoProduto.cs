using AugustosFashion.Entidades.Cliente;
using System;
using System.Collections.Generic;

namespace AugustosFashionModels.Entidades.Pedidos.Relatorios
{
    public class FiltroRelatorioPedidoProduto
    {
        public List<ListaGenericaModel> Produtos { get; private set; }
        public List<ListaGenericaModel> Clientes { get; private set; }
        public DateTime DataInicial { get; private set; }
        public DateTime DataFinal { get; private set; }
        public DateTime DataFinalFormatada { get => new DateTime(DataFinal.Year, DataFinal.Month, DataFinal.Day, 23, 59, 59); }
        public FiltroRelatorioPedidoProduto()
        {
            Clientes = new List<ListaGenericaModel>();
            Produtos = new List<ListaGenericaModel>();
        }

        public void AdicionarCliente(ClienteModel cliente)
        {
            Clientes.Add(new ListaGenericaModel()
            {
                Nome = $"{cliente.NomeCompleto.Nome} {cliente.NomeCompleto.SobreNome}",
                Id = cliente.IdCliente
            });
        }

        public void AdicionarProduto(PedidoProduto produto)
        {
            Produtos.Add(new ListaGenericaModel()
            {
                Nome = produto.Nome,
                Id = produto.IdProduto
            });
        }

        public void RemoverProduto(int indexProdutoSelecionado)
        {
            if (indexProdutoSelecionado == -1)
                return;

            Produtos.RemoveAt(indexProdutoSelecionado);
        }

        public void RemoverCliente(int indexClienteSelecionado)
        {
            if (indexClienteSelecionado == -1)
                return;

            Clientes.RemoveAt(indexClienteSelecionado);
        }

        public int EncontrarIndexDoProduto(int id) => Produtos.FindIndex(x => x.Id == id);

        public int EncontrarIndexDoCliente(int id) => Clientes.FindIndex(x => x.Id == id);

        public void AdicionarFiltrosData(DateTime dataInicial, DateTime dataFinal)
        {
            DataInicial = dataInicial;
            DataFinal = dataFinal;
        }
    }
}
