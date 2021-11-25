using AugustosFashion.Entidades;
using AugustosFashion.Repositorios;
using AugustosFashionModels.Entidades.Pedidos;
using AugustosFashionModels.Entidades.ServicoEmails;
using AugustosFashionModels.Servicos.ServicosDeEmails;
using System;

namespace AugustosFashion.Controllers.ServicosEmail
{
    public class ServicoEmailController
    {
        public void EnviarEmail(IServicoDeEmail servicoDeEmail)
        {
            try
            {              
                servicoDeEmail.EnviarEmail();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void PrepararServicoDeEmailDePedido(UsuarioModel destinatario, PedidoModel pedido)
        {
            var email = RecuperarInformacoesDeEmail();

            var servicoDeEmail = new ServicoDeEmail(destinatario, pedido, email);

            EnviarEmail(servicoDeEmail);
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
