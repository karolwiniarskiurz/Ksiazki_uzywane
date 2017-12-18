namespace UzywaneKsiazki.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using UzywaneKsiazki.Models.DomainModels;
    using UzywaneKsiazki.Models.Repository;
    using UzywaneKsiazki.Models.Services;

    [Route("[controller]")]
    public class PostController : Controller
    {
        private IPostService service;

        public PostController(IPostService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return this.Json(this.service.GetAll());
        }

        [HttpGet("{title}")]
        public IActionResult GetByTitle(string title)
        {
            return this.Json(this.service.GetByTitle(title));
        }
    }
}