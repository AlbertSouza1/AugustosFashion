using System.Net.Mail;

namespace AugustosFashionModels.Servicos.ServicosDeEmails
{
    public interface IServicoDeEmail
    {
        void EnviarEmail();
        MailMessage PrepararMensagemDeEmail();
        SmtpClient PrepararSmtp();
        string ConstruirCorpoDoEmail();
    }
}
