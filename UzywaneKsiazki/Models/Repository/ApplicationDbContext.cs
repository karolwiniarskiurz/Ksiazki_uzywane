namespace UzywaneKsiazki.Models.Repository
{
    using Microsoft.EntityFrameworkCore;
    using UzywaneKsiazki.Models.DomainModels;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PostModel> Posts { get; set; }
    }
}