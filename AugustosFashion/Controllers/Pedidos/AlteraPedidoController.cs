using AugustosFashion.Repositorios;
using AugustosFashionModels.Entidades.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Controllers.Pedidos
{
    public class AlteraPedidoController
    {
        public void AlterarPedido(PedidoModel pedido)
        {
            try
            {
                PedidoRepositorio.AlterarPedido(pedido);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
