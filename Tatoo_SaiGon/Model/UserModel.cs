namespace Tatoo_SaiGon.Model
{
    public class UserRegister
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? Status = false;
        public string? Dob = "N";
        public DateTime? CreateUser = DateTime.Now;
        public string? RoleId = "US";
    }
    public class UserLogin
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
    public class ResetPassword
    {
        public string Email { get; set; }
    }
    public class ChangePassword
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
