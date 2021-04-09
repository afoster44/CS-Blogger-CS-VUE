using System;
using System.Threading.Tasks;
using bloggr_CS.Models;
using bloggr_CS.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace bloggr_CS.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        public readonly BlogsService _service;

        public BlogsController(BlogsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<Blog> Get()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Blog> Get(int id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Blog>> CreateAsync([FromBody] Blog newBlog)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newBlog.CreatorId = userInfo.Id;
                Blog created = _service.Create(newBlog);
                return Ok(created);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Blog>> EditAsync([FromBody] Blog editData, int id)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                editData.Id = id;
                editData.CreatorId = userInfo.Id;
                Blog editedAdmission = _service.Edit(editData);
                return Ok(editedAdmission);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Blog>> DeleteAsync(int id)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_service.Delete(id, userInfo.Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}