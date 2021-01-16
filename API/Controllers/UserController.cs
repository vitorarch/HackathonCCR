using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/user")]
    public class UserController : ControllerBase
    {
        #region Welcome

        [HttpGet("v1/welcome/jobsvacancies")]
        public IActionResult Jobs()
        {
            return Ok();
        }

        [HttpGet("v1/welcome/aboutfuture")]
        public IActionResult Posts()
        {
            return Ok();
        }

        [HttpGet("v1/welcome/culture")]
        public IActionResult Events()
        {
            return Ok();
        }

        [HttpGet("v1/welcome/profile")]
        public IActionResult User()
        {
            return Ok();
        }

        #endregion

    }
}
