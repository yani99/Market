using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace Market.Services.Implementation
{
    public class EmailService :IEmailService
    {
        public async Task SendEmailAsync(string email,string subject,string msg)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("universalmarket", "universalmarket@abv.bg"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html) {
                Text = msg
            };

            using(var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.abv.bg", 465, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync("universalmarket@abv.bg", "universalmarket123");                
                await client.SendAsync(message);
                client.Disconnect(true);
            }       
        }
    }
}
