using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoginService.Model;
using LoginService.Repositories;

namespace LoginService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILogin _loginrepo;
        public LoginController(ILogin loginRepository)
        {
            _loginrepo = loginRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var tokenString = await _loginrepo.LoginUser(login);
            if (tokenString == null)
            {
                return Unauthorized();
            }
            return Ok(new { token = tokenString });
        }
    }
}
