using API.Interfaces.Access;
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

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] string cpf, string password)
        {
            var user = await _loginRepository.SingingIn(cpf, password);
            return Ok(user);
        }

    }
}
