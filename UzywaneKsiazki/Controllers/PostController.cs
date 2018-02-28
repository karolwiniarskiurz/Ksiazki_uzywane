using System.Threading.Tasks;
using UzywaneKsiazki.Helpers.Exceptions;

namespace UzywaneKsiazki.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using UzywaneKsiazki.Models.DTO;
    using UzywaneKsiazki.Models.Services;

    [Route("[controller]")]
    public class PostController : Controller
    {
        private IPostService service;

        public PostController(IPostService service)
        {
            this.service = service;
        }
        
#if DEBUG
        [HttpGet("/get/all")]
        public IActionResult GetAll()
        {
            return Ok(this.service.GetAll());
        }
#endif

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var post = await this.service.GetByIdAsync(id);
                return Ok(post);
            }
            catch (PostNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //todo zmien sciezke na cos w stylu /szukaj/fraza/strona
        [HttpGet("search/{page}/{searchQuery}")]
        public async Task<IActionResult> GetBySearchQuery(string searchQuery, int page)
        {
            return Ok(await this.service.GetBySearchQueryAsync(searchQuery, page));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PostModelDTO model)
        {
            try
            {
                await this.service.AddPostAsync(model);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await this.service.DeletePostAsync(id);
                return Ok();
            }
            catch (PostNotFoundException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdatePost([FromBody] PostModelDTO model)
        {
            try
            {
                await this.service.UpdatePostAsync(model);
                return Ok();
            }
            catch (PostNotFoundException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}