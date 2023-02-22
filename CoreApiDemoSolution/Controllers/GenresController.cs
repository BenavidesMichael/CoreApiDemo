using CoreApiDemo.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;

        public GenresController(IGenreRepository genreRepository)
        {
            this._genreRepository = genreRepository;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<Models.Genre>>> GetAllGenres()
        {
            return Ok(await _genreRepository.GetAllGenres());
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Models.Genre>> GetGenreById(int id)
        {
            var result = await _genreRepository.GetGenreById(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}

