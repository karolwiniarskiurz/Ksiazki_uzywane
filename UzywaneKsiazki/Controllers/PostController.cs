namespace UzywaneKsiazki.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using UzywaneKsiazki.Models.DomainModels;
    using UzywaneKsiazki.Models.Repository;

    [Route("[controller]")]
    public class PostController : Controller
    {
        private IPostRepository repo;

        public PostController(IPostRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<PostModel> list = this.repo.Posts.Take(3);
            return this.Json(list);

            // return Json("XDD");
        }
    }
}