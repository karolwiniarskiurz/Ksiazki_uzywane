using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.IdentityModel.Tokens;
using UzywaneKsiazki.Helpers;
using UzywaneKsiazki.Models.DomainModels;
using UzywaneKsiazki.Models.DTO;
using UzywaneKsiazki.Models.Repository;

namespace UzywaneKsiazki.Models.Services
{
    public class AuthService : IAuthService
    {
        private IPostRepository _postRepo;

        private IUserRepository _userRepo;

        private Auth _auth;

        public AuthService(IPostRepository postRepo, IUserRepository userRepo, Auth auth)
        {
            _postRepo = postRepo;
            _userRepo = userRepo;
            _auth = auth;
        }

        public async Task RegisterUserAsync(AuthDTO authDTO)
        {
            this.Validate(authDTO);

            _auth.CreatePasswordHash(authDTO.Password, out var passwordHash, out var passwordSalt);

            var user = new User(authDTO.Nickname, passwordHash, passwordSalt, Role.User);

            await _userRepo.RegisterAsync(user);
        }


        public async Task<string> LoginUserAsync(AuthDTO loginDTO)
        {
            this.Validate(loginDTO);

            var user = await this._userRepo.GetUserAsync(loginDTO.Nickname);
            if (user == null)
            {
                throw new NullReferenceException("Nie znaleziono takiego użytkownika");
            }

            if (!_auth.VerifyPasswordHash(loginDTO.Password, user.PasswordHash, user.Salt))
            {
                throw new Exception("Nie można zalogować");
            }

            var token = _auth.GenerateJwtToken(user);

            return token;
        }


        private void Validate(AuthDTO authDTO)
        {
            // sprawdz jakies rzeczy

            if (string.IsNullOrEmpty(authDTO.Nickname) || string.IsNullOrEmpty(authDTO.Password))
            {
                throw new Exception("Password is invalid");
            }
        }
    }
}