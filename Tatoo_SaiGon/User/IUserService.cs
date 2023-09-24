using System.Security.Claims;
using Tatoo_SaiGon.Model;
using Tatoo_SaiGon.User.Response;

namespace Tatoo_SaiGon.User
{
    public interface IUserService
    {
        public void RegiterUser(UserRegister userRegister);
        public Task<Token> Login(UserLogin userLogin);
        public void Logout(ClaimsPrincipal user);
        public void ResetPassword(ResetPassword reset);
        public Task ChangePassword(int userid,ChangePassword changepass);
    }
}
