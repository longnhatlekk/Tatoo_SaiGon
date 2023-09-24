using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tatoo_SaiGon.Model;
using Tatoo_SaiGon.User;

namespace Tatoo_SaiGon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpPost("registerUser")]
        public async Task<IActionResult> Registeruser(UserRegister user)
        {
            _service.RegiterUser(user);
            return Ok(user);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLogin login)
        {
            var user = await _service.Login(login);
            return Ok(user);
        }
        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            _service.Logout(User);
            return Ok("Success");
        }
        [HttpPost("resetPass")]
        public async Task<IActionResult> ResetPassword(ResetPassword reset)
        {
            _service.ResetPassword(reset);
            return Ok("Check Your Email");
        }
        [HttpPost("ChangePass")]
        public async Task<IActionResult> ChangePassword(ChangePassword change)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "UserId");
            if (user == null) return BadRequest("Invalid token");
            int userId = int.Parse(user.Value);
            var changepass = _service.ChangePassword(userId, change);
            return Ok("Change Pass successfully");
        }
    }
}
