namespace UzywaneKsiazki.Models.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using UzywaneKsiazki.Extensions;
    using UzywaneKsiazki.Models.DomainModels;

    public class EfPostsRepository : IPostRepository
    {
        private ApplicationDbContext context;

        private int itemsPerPage = 15;

        public EfPostsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<PostModel> Posts => this.context.Posts;

        public IEnumerable<PostModel> GetAll() => this.Posts;

        // todo zrob lepsze query przetestuj paginacje
        public IEnumerable<PostModel> GetBySearchQuery(string searchQuery, int pageNumber) => this.Posts
            .Where(p => p.SearchTags.Contains(searchQuery)).OrderBy(p => p.Id).Skip((pageNumber - 1) * this.itemsPerPage)
            .Take(this.itemsPerPage);

        public void AddPost(PostModel post)
        {
            this.context.Add(post);
            this.context.SaveChanges();

        }

        public void DeletePost(Guid id)
        {
            var post = this.Posts.Where(p => p.Id == id);
            this.context.Remove(post);
        }

        public void UpdatePost(PostModel post) => this.context.Update(post);
    }
}