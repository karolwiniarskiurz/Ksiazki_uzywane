using System.Threading.Tasks;
using UzywaneKsiazki.Models.DTO;

namespace UzywaneKsiazki.Models.Services
{
    public interface IAuthService
    {
        Task RegisterUserAsync(AuthDTO authDTO);

        Task<string> LoginUserAsync(AuthDTO loginDTO);
    }
}