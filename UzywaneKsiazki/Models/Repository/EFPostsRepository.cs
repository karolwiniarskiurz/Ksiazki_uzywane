using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UzywaneKsiazki.Models.DTO;

namespace UzywaneKsiazki.Models.Repository
{
    using System.Collections.Generic;
    using System.Linq;
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

        public async Task<PostModel> GetByIdAsync(int id)
        {
            return await this.context.Posts.SingleOrDefaultAsync(post => post.Id == id);
        }

#if DEBUG
        public async Task<IEnumerable<PostModel>> GetAllAsync() => this.Posts;
#endif

        // todo zrob lepsze query przetestuj paginacje
        public async Task<SearchResults> GetBySearchQueryAsync(string searchQuery, int pageNumber)
        {
            var posts = this.context.Posts
                .Where(p => p.SearchTags.Contains(searchQuery))
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * this.itemsPerPage)
                .Take(this.itemsPerPage);
            var numberOfItems = this.context.Posts.Count(p => p.SearchTags.Contains(searchQuery));
            var totalPages = (int) Math.Ceiling(numberOfItems / (double) itemsPerPage);
            
            return new SearchResults(pageNumber, totalPages, itemsPerPage, posts);
        }

        public async Task AddPostAsync(PostModel post)
        {
            await this.context.AddAsync(post);
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await this.Posts.SingleAsync(p => p.Id == id);
            this.context.Remove(post);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(PostModel post)
        {
            var original = await this.context.Posts.SingleOrDefaultAsync(p => p.Id == post.Id);
            AutoMapper.Mapper.Map(post, original);
            this.context.Posts.Update(original);
            await this.context.SaveChangesAsync();
        }
    }
}