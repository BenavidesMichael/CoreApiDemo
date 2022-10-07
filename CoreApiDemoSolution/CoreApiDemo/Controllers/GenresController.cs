using CoreApiDemo.Contracts;
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
        public async Task<ActionResult<IEnumerable<Models.Genre>>> Get()
        {
            return Ok(await _genreRepository.GetAllGenres());
        }
    }
}

