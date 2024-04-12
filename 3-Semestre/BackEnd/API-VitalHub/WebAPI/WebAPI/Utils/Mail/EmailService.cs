
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace WebAPI.Utils.Mail
{
    public class EmailService : IEmailService
    {
        //Variável que guarda as configurações de EmailSettings
        private readonly EmailSettings emailSettings;
        
        //Garante que toda vez que um objeto da classe for instanciado teremos de passar os parâmetros de EmailSettings
        //Construtor que recebe a dependence injection de EmailSettings
        public EmailService(IOptions<EmailSettings> options)
        {
            emailSettings = options.Value;
        }

        //Método para envio de email
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                //Objeto que representa o Email criada da classe MimeMessage
                var email = new MimeMessage();

                //define o remetente do email que está especificado no emailSettings
                email.Sender = MailboxAddress.Parse(emailSettings.Email);

                //define o destinatário que está especificado no mailRequest
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));

                //define o assunto do email (não precisa transformar em MailboxAdress pq não é um endereço)
                email.Subject = mailRequest.Subject;

                //cria o corpo do email
                var builder = new BodyBuilder();

                //define o corpo do email e o transforma em HTML
                builder.HtmlBody = mailRequest.Body;

                //define de fato o corpo do email no objeto MimeMessage
                email.Body = builder.ToMessageBody();

                //cria um client SMTP para enviar o email
                using (var smtp = new SmtpClient())
                {
                    //Conecta-se ao servidor SMTP usando os dados que estão no emailSettings
                    smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);

                    //autentica-se no servidor usando as configurações de usuário no emailSettings
                    smtp.Authenticate(emailSettings.Email, emailSettings.Password);

                    //envia o email ao esperar todas as configurações
                    await smtp.SendAsync(email);
                }

            }catch (Exception)
            {
                throw;
            }
        }
    }
}
