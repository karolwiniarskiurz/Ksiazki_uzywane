namespace UzywaneKsiazki.Models.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using UzywaneKsiazki.Models.DomainModels;

    public class EFPostsRepository : IPostRepository
    {
        private ApplicationDbContext context;

        public EFPostsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<PostModel> Posts => this.context.Posts;

        public IEnumerable<PostModel> GetAll() => this.Posts;

        //todo zrob lepsze query
        public IEnumerable<PostModel> GetByTitle(string title) => this.Posts.Where(p => p.Title.Contains(title));
    }
}