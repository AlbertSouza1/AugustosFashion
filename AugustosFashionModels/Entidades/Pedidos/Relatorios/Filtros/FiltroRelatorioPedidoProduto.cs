using AugustosFashion.Entidades.Cliente;
using AugustosFashionModels.Entidades.Pedidos.Relatorios.Enums;
using System;
using System.Collections.Generic;

namespace AugustosFashionModels.Entidades.Pedidos.Relatorios.Filtros
{
    public class FiltroRelatorioPedidoProduto
    {
        public List<ListaGenericaModel> Produtos { get; private set; }
        public List<ListaGenericaModel> Clientes { get; private set; }
        public DateTime DataInicial { get; private set; }
        public DateTime DataFinal { get; private set; }
        public EOrdenacaoPedidoProduto Ordenacao { get; private set; }
        public DateTime DataFinalFormatada { get => new DateTime(DataFinal.Year, DataFinal.Month, DataFinal.Day, 23, 59, 59); }
        public FiltroRelatorioPedidoProduto()
        {
            Clientes = new List<ListaGenericaModel>();
            Produtos = new List<ListaGenericaModel>();
        }

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

        public bool VerificarSeClienteJaEstaInserido(int idCliente)
        {
            var indice = Clientes.FindIndex(x => x.Id == idCliente);

            if(indice == -1)
                return false;
            return true;
        }

        public void AdicionarProduto(PedidoProduto produto)
        {
            if (VerificarSeProdutoJaEstaInserido(produto.IdProduto))
                return;

            Produtos.Add(new ListaGenericaModel()
            {
                Nome = produto.Nome,
                Id = produto.IdProduto
            });
        }

        public bool VerificarSeProdutoJaEstaInserido(int idProduto)
        {
            var indice = Produtos.FindIndex(x => x.Id == idProduto);

            if (indice == -1)
                return false;
            return true;
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

        public void SetarFiltros(DateTime dataInicial, DateTime dataFinal, int ordenacao)
        {
            DataInicial = dataInicial;
            DataFinal = dataFinal;
            Ordenacao = (EOrdenacaoPedidoProduto)ordenacao;
        }

        public void LimparFiltros(DateTime inicial, DateTime final)
        {
            DataInicial = inicial;
            DataFinal = final;
            Ordenacao = 0;
            Produtos = new List<ListaGenericaModel>();
            Clientes = new List<ListaGenericaModel>();
        }
    }
}
