using CoreApiDemo.Contracts;
using CoreApiDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace CoreApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AccountsController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }


        [HttpPost(nameof(Login))]
        [SwaggerOperation(Summary = "Authenticates a user", Description = "Authenticates a user")]
        public async Task<ActionResult<AuthResponse>> Login(Login model)
        {
            var isCorrect = await _authRepository.IsLoginAccesCorrectAsync(model);

            if (!isCorrect)
                return Unauthorized();

            return Ok(await _authRepository.LoginAsync(model));
        }


        [HttpPost(nameof(Register))]
        [SwaggerOperation(Summary = "Register a user", Description = "Register a user")]
        public async Task<ActionResult> Register(Register model)
        {
            var result = await _authRepository.RegisterAsync(model);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return StatusCode(201);
        }

    }
}
