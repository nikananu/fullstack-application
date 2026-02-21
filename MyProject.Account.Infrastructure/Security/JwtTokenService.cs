using MyProject.Account.Application.Interfaces;
using MyProject.Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Account.Infrastructure.Security
{
    public class JwtTokenService : IJwtTokenService
    {
        public string GenerateToken(User user)
        {
            return "FAKE_TOKEN_FOR_NOW";
        }
    }

}
