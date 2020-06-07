using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Market.Services
{
    public interface IEmailService
    {
        public void SendEmailAsync(string email, string subject, string msg);
    }
}
