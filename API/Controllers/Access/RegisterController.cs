using API.Interfaces.Access;
using API.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Access
{
    [ApiController]
    [Route("register")]

    public class RegisterController : ControllerBase
    {

        private readonly IRegisterRepository _registerRepository;

        public RegisterController(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var result = await _registerRepository.SingingUp(user);

            if (!result) return BadRequest("Objeto enviado de forma incorreta");
            return Ok(user);
        }
    }
}
