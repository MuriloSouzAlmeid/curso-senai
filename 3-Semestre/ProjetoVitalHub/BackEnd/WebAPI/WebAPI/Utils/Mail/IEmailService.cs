namespace WebAPI.Utils.Mail
{
    public interface IEmailService
    {
        //Método assíncrono para envio de Email (O task indica um método assíncrono)
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
