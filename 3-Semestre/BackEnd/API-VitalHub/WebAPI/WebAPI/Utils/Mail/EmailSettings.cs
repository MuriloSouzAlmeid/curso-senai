namespace WebAPI.Utils.Mail
{
    public class EmailSettings
    {
        //Email do remetente
        public string? Email { get; set; }
        
        //Senha do remetente
        public string? Password { get; set; }
        
        //Host do servidor SMTP (protocolo de transferencia de email simples)
        public string? Host { get; set; }
        
        //Nome exibido do remetente
        public string? DisplayName { get; set; }
        
        //Porta do servidor SMTP
        public int Port { get; set; }
    }
}
