using System.ComponentModel.DataAnnotations;

namespace UzywaneKsiazki.Models.DomainModels
{
    public class User
    {
        public User()
        {
        }

        [Key] public string Nickname { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] Salt { get; set; }

        public Role Role { get; set; }

        public User(string nickname, byte[] passwordHash, byte[] salt, Role role)
        {
            Nickname = nickname;
            PasswordHash = passwordHash;
            Salt = salt;
            Role = role;
        }
    }

    public enum Role
    {
        Admin,
        User
    }
}