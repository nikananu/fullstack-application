using Microsoft.AspNetCore.Identity;
using MyProject.Account.Application.Interfaces;


namespace MyProject.Account.Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly Microsoft.AspNetCore.Identity.PasswordHasher<string> _hasher
            = new();

        public string Hash(string password)
        {
            return _hasher.HashPassword(null, password);
        }

        public bool Verify(string password, string passwordHash)
        {
            var result = _hasher.VerifyHashedPassword(null, passwordHash, password);
            return result == PasswordVerificationResult.Success;
        }
    }

}

