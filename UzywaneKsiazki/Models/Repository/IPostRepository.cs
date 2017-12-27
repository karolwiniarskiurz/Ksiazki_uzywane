namespace UzywaneKsiazki.Models.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using UzywaneKsiazki.Models.DomainModels;

    public interface IPostRepository
    {
        IQueryable<PostModel> Posts { get; }

        IEnumerable<PostModel> GetAll();

        IEnumerable<PostModel> GetBySearchQuery(string searchQuery, int pageNumber);

        void AddPost(PostModel post);

        void DeletePost(Guid id);

        void UpdatePost(PostModel post);
    }
}