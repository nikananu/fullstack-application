using MyProject.Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Account.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> ExistsByEmailAsync(string email);
        Task<User?> GetByEmailAsync(string email);

        Task AddAsync(User user);
    }

}
