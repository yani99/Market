using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace Market.Services.Implementation
{
    public class EmailService :IEmailService
    {
        public void SendEmailAsync(string email,string subject,string msg)
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
                client.Connect("smtp.abv.bg", 465, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("universalmarket@abv.bg", "universalmarket123");
                
                client.Send(message);
                client.Disconnect(true);
            }       
        }
    }
}
