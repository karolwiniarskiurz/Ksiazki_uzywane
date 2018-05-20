using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UzywaneKsiazki.Models.DomainModels;

namespace UzywaneKsiazki.Models.Repository
{
    public class EfUserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public EfUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RegisterAsync(User user)
        {
            await this._context.Users.AddAsync(user);
            await this._context.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(string userNickname)
        {
            return await this._context.Users.SingleOrDefaultAsync(user => user.Nickname.Equals(userNickname));
        }
    }
}