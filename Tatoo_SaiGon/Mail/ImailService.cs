namespace Tatoo_SaiGon.Mail
{
    public interface ImailService
    {
        public Task SendMailRequest(MailRequest request);
    }
}
