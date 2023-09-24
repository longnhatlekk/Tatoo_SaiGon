namespace Tatoo_SaiGon.Model
{
    public class MemberRegister
    {
        public string? MemberName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? CreateMember = DateTime.Now;
    }
}
