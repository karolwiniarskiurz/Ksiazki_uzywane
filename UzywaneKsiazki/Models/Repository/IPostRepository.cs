namespace UzywaneKsiazki.Models.Repository
{
    using System.Collections.Generic;
    using System.Linq;

    using UzywaneKsiazki.Models.DomainModels;

    public interface IPostRepository
    {
        IQueryable<PostModel> Posts { get; }
    }
}