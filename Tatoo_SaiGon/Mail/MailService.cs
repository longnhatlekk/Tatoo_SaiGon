using AutoMapper.Internal;
using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;
using Tatoo_SaiGon.Model;

namespace Tatoo_SaiGon.Mail
{
    public class MailService : ImailService
    {
        private readonly string _host;
        private readonly int _port;
        private readonly string _username;
        private readonly string _password;
        public MailService(IConfiguration config)
        {
            _host = config["MailSettings:Host"];
            _port = config["MailSettings:From"] != null ? int.Parse(config["MailSettings:From"]) : 587;
            _username = config["MailSettings:Mail"];
            _password = config["MailSettings:Password"];
        }
        public async Task SendMailRequest(MailRequest mailModel)
        {

            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_username);
            email.To.Add(MailboxAddress.Parse(mailModel.ToEmail));
            email.Subject = mailModel.SubJect;
            var builder = new BodyBuilder();

            builder.HtmlBody = mailModel.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_host, _port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_username, _password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
