using CoreApiDemo.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TheatersController : ControllerBase
    {
        private readonly ITheaterRepository _theaterRepository;

        public TheatersController(ITheaterRepository theaterRepository)
        {
            _theaterRepository = theaterRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Theatre>>> Get()
        {
            return Ok(await _theaterRepository.GetAllTheatres());
        }


        [HttpGet("{longitude:double}/{latitude:double}/{kilommetres:int}")]
        public async Task<ActionResult<IEnumerable<Models.Theatre>>> FindNearTheatres(double longitude, double latitude, int kilommetres)
        {
            return Ok(await _theaterRepository.GetNearTheatres(longitude, latitude, kilommetres));
        }
    }
}
