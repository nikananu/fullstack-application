using MyProject.Account.Domain.Common;
using MyProject.Account.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Account.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; } = null!;
        public string Phone { get; private set; } = null!;
        public DateOnly DateOfBirth { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public string Email { get; private set; } = null!;
        public string PasswordHash { get; private set; } = null!;
        public UserRole Role { get; private set; }

        public User(string name, string phone, DateOnly dateOfBirth, string email, string passwordHash)
        {
            Id = Guid.NewGuid();
            Name = name;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            Email = email;
            PasswordHash = passwordHash;
            Role = UserRole.User; // Default role

        }

        public void ChangePassword(string newPasswordHash)
        {
            PasswordHash = newPasswordHash;
        }

        public void ChangeRole(UserRole role)
        {
            Role = role;
        }

    }
}
