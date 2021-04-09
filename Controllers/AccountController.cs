using System.Threading.Tasks;
using bloggr_CS.Models;
using bloggr_CS.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bloggr_CS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly ProfilesService _psService;

        public AccountController(ProfilesService psService)
        {
            _psService = psService;
        }

        [HttpGet]
        public async Task<ActionResult<Profile>> GetAsync()
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_psService.GetOrCreateProfile(userInfo));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}