using AutoMapper;
using MailKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tatoo_SaiGon.EntityTatoo;
using Tatoo_SaiGon.EntityTatoo;
using Tatoo_SaiGon.Mail;
using Tatoo_SaiGon.Model;
using Tatoo_SaiGon.User.Response;

namespace Tatoo_SaiGon.User
{
    public class UserService : IUserService

    {
        private IConfiguration _config;
        private IMapper _mapper;
        private TattooSaigonContext _context;
        private ImailService _mailservice;

        public UserService(IConfiguration config, IMapper mapper, TattooSaigonContext tatto, ImailService mailservice)
        {
            _config = config;
            _mapper = mapper;
            _context = tatto;
            _mailservice = mailservice;
        }

        public async Task ChangePassword(int userid,ChangePassword changepass)
        {
            var user = await _context.TblUsers.FirstOrDefaultAsync(x => x.UserId == userid);
            if (user == null) throw new Exception("No user");
            if (changepass.OldPassword != user.Password) throw new Exception("Different pass");
            if (changepass.NewPassword != changepass.ConfirmNewPassword) throw new Exception("Different pass");
            
            user.Password = changepass.NewPassword;
           await _context.SaveChangesAsync();
        }

        public Task<Token> Login(UserLogin userLogin)
        {
            var user = _context.TblUsers.FirstOrDefault(x => x.Email == userLogin.Email && x.Password == userLogin.Password);
            if (user == null) throw new Exception("No user");
            var token = GenarateToken(user);
            return token;
        }

        public void Logout(ClaimsPrincipal user)
        {
            var users = user.Claims.ToList();
            var tokenClaim = users.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti);
            if (tokenClaim != null)
            {
                users.Remove(tokenClaim);
            }
        }

        public  void RegiterUser(UserRegister userRegister)
        {
          var mapper =   _mapper.Map<TblUser>(userRegister);
            _context.TblUsers.Add(mapper);
            _context.SaveChanges();
            var mail = new MailRequest
            {
                ToEmail = mapper.Email,
                SubJect = "[TATOO PLATFORM] Bạn đã đăng kí thành công",
                Body = $"Hãy đăng nhập và trải nghiệm"
            };
            _mailservice.SendMailRequest(mail);
            
        }

        public void ResetPassword(ResetPassword reset)
        {
            var email = _context.TblUsers.FirstOrDefault(x => x.Email == reset.Email);
            if (email == null) throw new Exception("No email");
            string newpassword = "123abc";
            email.Password = newpassword;
            _context.SaveChanges();
            var mail = new MailRequest()
            {
                ToEmail = email.Email,
                SubJect = "[TATOO PLATFORM] Thông tin mật khẩu mới",
                Body = $"Mật khẩu mới của bạn là : {newpassword}"

            };
            _mailservice.SendMailRequest(mail);
          
        }

        private async Task<Token> GenarateToken(TblUser user)
        {
            var jwttokenHandler = new JwtSecurityTokenHandler();
            var secretkey = Encoding.UTF8.GetBytes(_config["JWT:Key"]);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("UserId", user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
         new Claim("Email", user.Email),
         new Claim(ClaimTypes.Role, user.RoleId),
            };
            var tokendescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"],
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretkey), SecurityAlgorithms.HmacSha512),
                Claims = new Dictionary<string, object>
                {

                }

            };
            var token = jwttokenHandler.CreateToken(tokendescription);
            var accesstoken = jwttokenHandler.WriteToken(token);
            return new Token
            {
                Tokens = accesstoken
            };
        }
    }
}
