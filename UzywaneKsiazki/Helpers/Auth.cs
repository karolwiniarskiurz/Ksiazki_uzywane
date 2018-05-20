using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UzywaneKsiazki.Models.DomainModels;

namespace UzywaneKsiazki.Helpers
{
    public class Auth
    {
        private readonly AppSettingsSecret _appSettings;

        public Auth(AppSettingsSecret appSettings)
        {
            _appSettings = appSettings;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userSalt)
        {
            using (var hmac = new HMACSHA512(userSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != userPasswordHash[i]) return false;
                }
            }

            return true;
        }

        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretCode);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // tutaj możemy dodać do tokena jakiekolwiek dane tylko chcemy
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(
                            ClaimTypes.Name,
                            user.Nickname),
                        new Claim(
                            ClaimTypes.Role,
                            user.Role.ToString()),
                        new Claim(
                            "CustomClaim",
                            "moge tutaj wpisac co chce :)"), 
                    }),
                Expires = DateTime.UtcNow.AddDays(7), // czas uplyniecia tokenu
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}