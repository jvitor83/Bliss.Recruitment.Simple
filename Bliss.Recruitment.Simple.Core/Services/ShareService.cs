using Bliss.Recruitment.Simple.Core.Email;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Recruitment.Simple.Core.Services
{
    public class ShareService : IShareService
    {
        protected readonly NotificationMetadata _notificationMetadata;
        public ShareService(NotificationMetadata notificationMetadata)
        {
            this._notificationMetadata = notificationMetadata;
        }

        public async Task ShareByEmail(string to, string body, string subject = null, string from = null)
        {
            string toUse = String.IsNullOrWhiteSpace(to) ? throw new ArgumentNullException(nameof(to)) : to;
            string bodyUse = String.IsNullOrWhiteSpace(body) ? throw new ArgumentNullException(nameof(body)) : body;


            string fromToUse = String.IsNullOrWhiteSpace(from) ? this._notificationMetadata.Sender : from;

            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(InternetAddress.Parse(fromToUse));
            mimeMessage.To.Add(InternetAddress.Parse(toUse));
            mimeMessage.Subject = subject;
            mimeMessage.Body = new TextPart("plain")
            {
                Text = bodyUse
            };

            using (SmtpClient smtpClient = new SmtpClient())
            {
                await smtpClient.ConnectAsync(_notificationMetadata.SmtpServer, _notificationMetadata.Port, true);
                await smtpClient.AuthenticateAsync(_notificationMetadata.UserName, _notificationMetadata.Password);
                await smtpClient.SendAsync(mimeMessage);
                await smtpClient.DisconnectAsync(true);
            }
        }
    }
}
