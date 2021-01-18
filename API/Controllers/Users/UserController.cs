using API.Interfaces.Users;
using API.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Users
{

    [ApiController]
    //[Authorize]
    [Route("/user/profile")]

    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepsoitory;

        public UserController(IUserRepository userRepsoitory)
        {
            _userRepsoitory = userRepsoitory;
        }

        [HttpGet("v1")]
        public async Task<IActionResult> GetProfile([FromForm] string CPF)
        {
            var profile = await _userRepsoitory.GetUserProfile(CPF);
            return Ok(profile);
        }

        [HttpGet("v1/edit")]
        public async Task<IActionResult> EditProfile([FromForm] User user)
        {
            var _user = await _userRepsoitory.EditUserProfile(user);
            
            if (_user == null) return NotFound();
            else return Ok(_user);
        }

        [HttpGet("v1/delete")]
        public async Task<IActionResult> DeleteProfile([FromForm] string cpf)
        {
            var _user = await _userRepsoitory.DeleteUserProfile(cpf);
            
            if (_user == false) return NotFound();
            else return Ok("Usuário deletado");
        }

    }

}
