using CoreApiDemo.Contracts;
using CoreApiDemo.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
                return BadRequest("Login/Password Wrong");

            return Ok(await _authRepository.LoginAsync(model.Email));
        }


        [HttpPost(nameof(Register))]
        [SwaggerOperation(Summary = "Register a user", Description = "Register a user")]
        public async Task<ActionResult> Register(Register model)
        {
            var result = await _authRepository.RegisterAsync(model);

            if (result is null || !result.Succeeded)
                return BadRequest(result?.Errors);

            return StatusCode(201);
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(nameof(RefreshToken))]
        [SwaggerOperation(Summary = "Refresh Token", Description = "Refresh Token")]
        public async Task<ActionResult<Tokens>> RefreshToken()
        {
            var result = await _authRepository.RefreshToken();

            if (result is null)
                return Unauthorized();

            return Ok(result);
        }
    }
}
