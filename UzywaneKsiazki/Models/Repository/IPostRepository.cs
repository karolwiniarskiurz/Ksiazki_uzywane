using System.Threading.Tasks;

namespace UzywaneKsiazki.Models.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UzywaneKsiazki.Models.DomainModels;

    public interface IPostRepository
    {
        IQueryable<PostModel> Posts { get; }

        Task<PostModel> GetByIdAsync(int id);

        Task<IEnumerable<PostModel>> GetBySearchQueryAsync(string searchQuery, int pageNumber);

        Task AddPostAsync(PostModel post);

        Task DeletePostAsync(int id);

        Task UpdatePostAsync(PostModel post);
    }
}