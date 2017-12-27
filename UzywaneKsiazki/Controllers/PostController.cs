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

        //todo remove this is strictly for development porpouses
        [HttpGet]
        public IActionResult GetAll()
        {
            return this.Json(this.service.GetAll());
        }

        //todo zmien sciezke na cos w stylu /szukaj/fraza/strona
        [HttpGet("search/{page}/{searchQuery}")]
        public IActionResult GetBySearchQuery(string searchQuery, int page)
        {
            return this.Json(this.service.GetBySearchQuery(searchQuery, page));
        }

        [HttpPost]
        public void AddPost([FromBody] PostModelDTO model)
        {
            this.service.AddPost(model);
        }

        [HttpDelete("delete/{id}")]
        public void DeletePost(Guid id)
        {
            this.service.DeletePost(id);
        }

        [HttpPut]
        public void UpdatePost([FromBody] PostModelDTO model)
        {
            this.service.UpdatePost(model);
        }
    }
}