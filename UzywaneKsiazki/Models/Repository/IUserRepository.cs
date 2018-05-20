using System.Threading.Tasks;
using UzywaneKsiazki.Models.DomainModels;

namespace UzywaneKsiazki.Models.Repository
{
    public interface IUserRepository
    {
        Task RegisterAsync(User user);
        Task<User> GetUserAsync(string userNickname);
    }
}