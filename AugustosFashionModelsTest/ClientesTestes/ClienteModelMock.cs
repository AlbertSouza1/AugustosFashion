using AugustosFashion.Entidades.Cliente;
using AugustosFashionModels.Entidades.ContasClientes;
using System.Collections.Generic;

namespace AugustosFashionModelsTest.ClientesTestes
{
    public static class ClienteModelMock
    {
        public static ClienteModel RetornarCliente()
        {
            ClienteModel cliente = new ClienteModel();

            cliente.Email = "email@email.com";
            cliente.NomeCompleto.Nome = "José";
            cliente.NomeCompleto.SobreNome = "Aldo";
            cliente.LimiteCompraAPrazo = 1000;

            cliente.Contas = RetornarContasAReceberDeCliente();
            return cliente;
        }
        public static ClienteModel RetornarClienteComLimiteCompraInvalido()
        {
            ClienteModel cliente = new ClienteModel();

            cliente.Email = "email@email.com";
            cliente.NomeCompleto.Nome = "José";
            cliente.NomeCompleto.SobreNome = "Aldo";
            cliente.LimiteCompraAPrazo = 11000;

            cliente.Contas = RetornarContasAReceberDeCliente();
            return cliente;
        }

        public static List<ContaClienteModel> RetornarContasAReceberDeCliente()
        {
            var contas = new List<ContaClienteModel>();

            contas.Add(new ContaClienteModel()
            {
                Valor = 30m,
                Pago = false
            });

            contas.Add(new ContaClienteModel()
            {
                Valor = 50m,
                Pago = false
            });

            contas.Add(new ContaClienteModel()
            {
                Valor = 100m,
                Pago = false
            });

            return contas;
        }
    }
}
