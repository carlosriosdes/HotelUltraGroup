using HotelApp.Domain.Contracts;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace HotelApp.Infraestructure.Persistence.Email
{
    public class SmtpEmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public SmtpEmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using (var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.Port))
            {
                client.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);
                client.EnableSsl = _emailSettings.UseSsl;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(to);

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
