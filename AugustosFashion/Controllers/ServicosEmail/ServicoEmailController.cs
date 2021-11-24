using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Repositorios;
using AugustosFashionModels.Entidades.Pedidos;
using AugustosFashionModels.Entidades.ServicoEmails;
using AugustosFashionModels.Servicos.ServicosDeEmails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AugustosFashion.Controllers.ServicosEmail
{
    public class ServicoEmailController
    {
        public void EnviarEmailDeConfirmacaoDePedido(ClienteModel cliente, PedidoModel pedido)
        {
            try
            {
                var email = RecuperarInformacoesDeEmail();

                var servicoDeEmail = new ServicoDeEmail(cliente, pedido, email.Email, email.RetornarSenhaDescriptografada());
                servicoDeEmail.EnviarEmail();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EmailLojaModel RecuperarInformacoesDeEmail()
        {
            try
            {
                return EmailRepositorio.RecuperarEmail();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
