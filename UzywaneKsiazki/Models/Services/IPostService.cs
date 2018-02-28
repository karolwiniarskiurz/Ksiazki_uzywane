using System.Threading.Tasks;

namespace UzywaneKsiazki.Models.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UzywaneKsiazki.Models.DomainModels;
    using UzywaneKsiazki.Models.DTO;

    public interface IPostService
    {
        Task<PostModelDTO> GetByIdAsync(int id);

        Task<IEnumerable<PostModelDTO>> GetBySearchQueryAsync(string searchQuery, int pageNumber);

        Task AddPostAsync(PostModelDTO post);

        Task DeletePostAsync(int id);

        Task UpdatePostAsync(PostModelDTO post);

#if DEBUG
        IEnumerable<PostModelDTO> GetAll();
#endif
    }
}