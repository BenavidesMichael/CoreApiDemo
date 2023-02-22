using CoreApiDemo.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiDemo.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }


        [HttpGet("id:int")]
        public async Task<ActionResult<Models.Movie>> Get(int id)
        {
            var result = await _movieRepository.GetMovieById(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
