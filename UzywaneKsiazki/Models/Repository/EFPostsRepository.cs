namespace UzywaneKsiazki.Models.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using UzywaneKsiazki.Models.DomainModels;

    public class EfPostsRepository : IPostRepository
    {
        private ApplicationDbContext context;

        public EfPostsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<PostModel> Posts => this.context.Posts;

        public IEnumerable<PostModel> GetAll() => this.Posts;

        // todo zrob lepsze query
        public IEnumerable<PostModel> GetByTitle(string title) => this.Posts.Where(p => p.Title.Contains(title));

        public void AddPost(PostModel post) => this.context.Add(post);

        public void DeletePost(Guid id)
        {
            var post = this.Posts.Where(p => p.Id == id);
            this.context.Remove(post);
        }

        public void UpdatePost(PostModel post) => this.context.Update(post);
    }
}