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
        public string Email { get; private set; } = null!;
        public string PasswordHash { get; private set; } = null!;
        public UserRole Role { get; private set; }

        private User() { } 

        public User(string email, string passwordHash)
        {
            Id = Guid.NewGuid();
            Email = email;
            PasswordHash = passwordHash;
            Role = UserRole.User;
        }
    }

}
