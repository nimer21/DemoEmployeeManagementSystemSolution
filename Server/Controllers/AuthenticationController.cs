using BaseLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Route("api/[controller]")]
    //[Route("api/[controller]/[action]")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    //[Route("")]
    //[Route("Authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserAccount accountInterface;

        public AuthenticationController(IUserAccount accountInterface)
        {
            this.accountInterface = accountInterface;
        }


        [HttpPost("register")]
        //[HttpPost]
        //[HttpPost(Name = "register")]
        public async Task<IActionResult> CreateAsync(Register user)
        {
            if (user == null) return BadRequest("Model is empty");
                var result = await accountInterface.CreateAsync(user);
            return Ok(result);
        }

        [HttpPost("login")]
        //[HttpPost]
        public async Task<IActionResult> SignInAsync(Login user)
        {
            if (user == null) return BadRequest("Model is empty");
            var result = await accountInterface.SignInAsync(user);
            return Ok(result);
        }

    }
}
