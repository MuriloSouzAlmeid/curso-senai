﻿namespace WebAPI.Utils.Mail
{
    public class MailRequest
    {
        // Email do destinatário
        public string? ToEmail {get; set;}

        // Assunto do Email
        public string? Subject { get; set; }

        // Conteúdo do Email
        public string? Body { get; set; }
    }
}
