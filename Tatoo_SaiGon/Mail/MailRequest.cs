namespace Tatoo_SaiGon.Mail
{
    public class MailRequest
    {
        public string ToEmail { get; set; } = default!;
        public string SubJect { get; set; } = default!;
        public string Body { get; set;} = default!;
    }
}
