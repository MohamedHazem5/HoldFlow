using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;

namespace HoldFlow.BL.Managers
{
    public class EmailManager : IEmailManager
    {
        private readonly MailSettingsGmail _mailSettingsGmail;

        public EmailManager(IOptions<MailSettingsGmail> mailSettings)
        {
            _mailSettingsGmail = mailSettings.Value;
        }
        public async Task SendEmailAsync(string mailTo, string subject, string body, IList<IFormFile> attachments = null)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailSettingsGmail.Email),
                Subject = subject
            };
            email.To.Add(MailboxAddress.Parse(mailTo));

            var builder = new BodyBuilder();

            if (attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in attachments)
                {
                    if (file.Length > 0)
                    {
                        using var ms = new MemoryStream();
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }
                    else
                    {
                        fileBytes = new byte[0];
                    }
                    builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                }
            }

            builder.HtmlBody = body;
            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(_mailSettingsGmail.DisplayName, _mailSettingsGmail.Email));

            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettingsGmail.Host, _mailSettingsGmail.Port, SecureSocketOptions.SslOnConnect);
            smtp.Authenticate(_mailSettingsGmail.Email, _mailSettingsGmail.Password);
            await smtp.SendAsync(email);


            smtp.Disconnect(true);


        }
    }
}
