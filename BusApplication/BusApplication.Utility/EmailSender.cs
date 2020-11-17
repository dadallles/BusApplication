using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using Microsoft.AspNetCore.Mvc;

namespace BusApplication.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Bus Application", "dawid.jonienc.bus@onet.pl"));
                message.To.Add(new MailboxAddress("Client", email));
                message.Subject = subject;
                message.Body = new TextPart("html")
                {
                    Text = htmlMessage
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {

                    client.Connect("smtp.poczta.onet.pl", 465, true);

                    client.Authenticate("dawid.jonienc.bus@onet.pl", "asdasDsdf4g#g&dsSdD3@sd@fsd@");

                    client.Send(message);

                    client.Disconnect(true);
                }

            }
            catch (Exception ex)
            {
                
            }

            return Task.CompletedTask;
        }
    }
}
