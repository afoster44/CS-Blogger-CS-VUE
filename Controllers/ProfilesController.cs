using bloggr_CS.Models;
using bloggr_CS.Services;
using Microsoft.AspNetCore.Mvc;

namespace bloggr_CS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _psService;

        public ProfilesController(ProfilesService psService)
        {
            _psService = psService;
        }

        [HttpGet("{id}")]
        public ActionResult<Profile> Get(string id)
        {
            try
            {
                return Ok(_psService.GetProfileById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}