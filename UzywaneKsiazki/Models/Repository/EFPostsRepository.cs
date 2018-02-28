using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

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
        public async Task<IEnumerable<PostModel>> GetBySearchQueryAsync(string searchQuery, int pageNumber) =>
            this.context.Posts
                .Where(p => p.SearchTags.Contains(searchQuery))
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * this.itemsPerPage)
                .Take(this.itemsPerPage);

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
            this.context.Update(post);
            await this.context.SaveChangesAsync();
        }
    }
}