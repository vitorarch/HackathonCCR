using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("company")]
    public class CompanyController : ControllerBase
    {

        #region Register
        [HttpPost("/register")]
        public IActionResult SingUp()
        {
            return Ok();
        }

        #endregion

        #region Login

        [HttpPost("/login")]
        public IActionResult SingIn()
        {
            return Ok();
        }

        #endregion

    }
}
