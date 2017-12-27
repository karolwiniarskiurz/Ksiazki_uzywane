namespace UzywaneKsiazki.Models.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using UzywaneKsiazki.Models.DomainModels;
    using UzywaneKsiazki.Models.DTO;

    public interface IPostService
    {
        IQueryable<PostModelDTO> Posts { get; }

        IEnumerable<PostModelDTO> GetAll();

        IEnumerable<PostModelDTO> GetBySearchQuery(string searchQuery, int pageNumber);

        void AddPost(PostModelDTO post);

        void DeletePost(Guid id);

        void UpdatePost(PostModelDTO post);
    }
}