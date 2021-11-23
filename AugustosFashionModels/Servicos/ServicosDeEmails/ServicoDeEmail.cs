using AugustosFashion.Entidades.Cliente;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AugustosFashionModels.Servicos.ServicosDeEmails
{
    public class ServicoDeEmail : IServicoDeEmail
    {
        private readonly ClienteModel _destinatario;
        private readonly string _emailRemetente;
        private readonly string _senhaRemetente;

        public ServicoDeEmail(ClienteModel destinatario, string emailRemetente, string senhaRemetente)
        {
            _destinatario = destinatario;
            _emailRemetente = emailRemetente;
            _senhaRemetente = senhaRemetente;
        }
        public string ConstruirCorpoDoEmail()
        {
            StringBuilder mensagem = new StringBuilder();

            mensagem.Append($"Olá, {_destinatario.NomeCompleto.Nome}!");
            mensagem.AppendLine();
            mensagem.AppendLine();
            mensagem.Append($"Estamos enviando este e-mail como confirmação do seu pedido.");
            mensagem.AppendLine();
            mensagem.Append("Agradecemos a preferência. Volte sempre que desejar!");
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
            message.From = new MailAddress(_emailRemetente);

            return message;
        }

        public SmtpClient PrepararSmtp()
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(_emailRemetente, _senhaRemetente);

            return smtp;
        }
    }
}
