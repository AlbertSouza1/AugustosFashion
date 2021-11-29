using AugustosFashion.Entidades;
using AugustosFashionModels.Entidades.Pedidos;
using AugustosFashionModels.Entidades.ServicoEmails;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AugustosFashionModels.Servicos.ServicosDeEmails
{
    public class EmailNovoPedido : IServicoDeEmail
    {
        private readonly UsuarioModel _destinatario;
        private readonly PedidoModel _pedido;
        private readonly EmailLojaModel _emailRemetente;

        public EmailNovoPedido(UsuarioModel destinatario, PedidoModel pedido, EmailLojaModel remetente)
        {
            _destinatario = destinatario;
            _emailRemetente = remetente;
            _pedido = pedido;
        }
       
        public string ConstruirCorpoDoEmail()
        {
            StringBuilder mensagem = new StringBuilder();

            mensagem.Append($"Olá, {_destinatario.NomeCompleto.Nome}!");
            mensagem.AppendLine();
            mensagem.AppendLine();
            mensagem.Append($"Seu pedido na Agustu's Fashion foi efetuado com sucesso.");
            mensagem.AppendLine();
            mensagem.Append($"Verifique se os itens listados abaixo estão de acordo com sua solicitação.");
            mensagem.AppendLine();
            mensagem.AppendLine();
            foreach (var item in _pedido.Produtos)
            {
                mensagem.AppendLine($"{item.Quantidade} {item.Nome} - {item.PrecoLiquido.ValorFormatado} a unidade");
            }
            mensagem.AppendLine();
            mensagem.AppendLine($"Total do pedido: {_pedido.TotalLiquido}");
            mensagem.AppendLine();
            mensagem.AppendLine();
            mensagem.Append("Agradecemos a preferência. Volte sempre que desejar! 😎👍");
            mensagem.AppendLine();
            mensagem.AppendLine();
            mensagem.Append("Att: Augustu's Fashion");

            return mensagem.ToString();
        }

        public void EnviarEmail()
        {
            var mensagem = PrepararMensagemDeEmail();
            var smtp = PrepararSmtp();

            try
            {
                smtp.Send(mensagem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MailMessage PrepararMensagemDeEmail()
        {
            MailMessage message = new MailMessage();
            message.To.Add(_destinatario.Email.RetornaValor);
            message.Body = ConstruirCorpoDoEmail();
            message.Subject = "Confirmação de Compra em Augustu's Fashion";
            message.From = new MailAddress(_emailRemetente.Email);

            return message;
        }

        public SmtpClient PrepararSmtp()
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(_emailRemetente.Email, _emailRemetente.RetornarSenhaDescriptografada());

            return smtp;
        }
    }
}
