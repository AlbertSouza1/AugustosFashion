using AugustosFashion.Entidades.Cliente;
using AugustosFashionModels.Entidades.Pedidos;
using AugustosFashionModelsTest.PedidosTestes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AugustosFashionModelsTest.ClientesTestes
{
    [TestClass]
    public class ClienteModelTestes
    {      
        [TestMethod]
        public void Se_data_nascimento_cliente_for_igual_a_data_de_hoje_retornar_mensagem_avisando_aniversario()
        {   
           //arrange
            ClienteModel cliente = new ClienteModel();
            cliente.NomeCompleto.Nome = "Carlos";
            cliente.DataNascimento = DateTime.Now;

            //act assert
            Assert.AreEqual("Carlos está fazendo aniversário hoje.", cliente.VerificarSeEhAniversarioDoCliente());
        }

        [TestMethod]
        public void Se_data_nascimento_cliente_for_diferente_da_data_de_hoje_retornar_string_vazia()
        {
            //arrange
            ClienteModel cliente = new ClienteModel();
            cliente.NomeCompleto.Nome = "Carlos";
            cliente.DataNascimento = DateTime.Now.AddDays(-1);

            //act assert
            Assert.AreEqual(string.Empty, cliente.VerificarSeEhAniversarioDoCliente());
        }

        [TestMethod]
        public void Se_limite_compra_a_prazo_for_maior_que_10000_deve_retornar_mensagem_erro()
        {
            //arrange
            var sut = ClienteModelMock.RetornarClienteComLimiteCompraInvalido();

            //act assert
            Assert.AreEqual("O limite de compra a prazo deve ser menor que R$ 10.000", sut.ValidarCliente());
        }

        [TestMethod]
        public void RetornarLimiteParaNovaCompra_deve_retornar_limite_cadastrado_menos_total_da_divida()
        {
            //arrange
            var sut = ClienteModelMock.RetornarCliente();

            //act assert
            Assert.AreEqual(820m, sut.RetornarLimiteParaNovaCompra());
        }

        [TestMethod]
        public void RetornarLimiteParaAlteracaoDeCompra_deve_retornar_limite_cadastrado_menos_divida_sem_valor_pre_alteracao()
        {
            //arrange
            var sut = ClienteModelMock.RetornarCliente();
            var pedido = new PedidoModel();
            pedido.SetarTotalLiquidoPreAlteracao(50);           

            //act assert
            Assert.AreEqual(870m, sut.RetornarLimiteParaAlteracaoDeCompra(pedido.TotalLiquidoPreAlteracao.RetornaValor));
        }
    }
}
