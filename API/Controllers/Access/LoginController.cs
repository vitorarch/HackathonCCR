using API.Interfaces.Access;
using API.Models.Users;
using API.Repositories.Access;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers.Access
{
    [ApiController]
    [Route("/login")]

    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpGet("teste")]
        public IActionResult Login()
        {
            return Ok("teste");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var _user = await _loginRepository.SingingIn(user);

            if (_user == null) return NotFound("Usuário não encontrado!");
            else return Ok(_user);
        }

    }
}
