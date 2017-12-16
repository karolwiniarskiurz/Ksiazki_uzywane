namespace UzywaneKsiazki.Models.Repository
{
    using System.Linq;

    using UzywaneKsiazki.Models.DomainModels;

    public interface IPostRepository
    {
        IQueryable<PostModel> Posts { get; }
    }
}