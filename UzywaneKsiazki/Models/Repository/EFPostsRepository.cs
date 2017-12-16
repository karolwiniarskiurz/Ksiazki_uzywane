namespace UzywaneKsiazki.Models.Repository
{
    using System.Linq;

    using UzywaneKsiazki.Models.DomainModels;

    public class EFPostsRepository : IPostRepository
    {
        private readonly ApplicationDbContext context;

        public EFPostsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<PostModel> Posts => this.context.Posts;
    }
}