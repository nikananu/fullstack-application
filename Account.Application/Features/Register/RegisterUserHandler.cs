using MyProject.Account.Application.Dtos;
using MyProject.Account.Application.Interfaces;
using MyProject.Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Account.Application.Features.Register
{
    public class RegisterUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<RegisterResponseDto> Handle(RegisterRequestDto request)
        {
            // 1. Check if user exists
            if (await _userRepository.ExistsByEmailAsync(request.Email))
                throw new Exception("User already exists");

            // 2. Hash password
            var hash = _passwordHasher.Hash(request.Password);

            // 3. Create domain entity
            var user = new User(request.Name,request.Phone,request.DateOfBirth,request.Email, hash);

            // 4. Save user
            await _userRepository.AddAsync(user);

            // 5. Return response
            return new RegisterResponseDto
            {
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email,
                phone = user.Phone,
                DateOfBirth = user.DateOfBirth,
                CreatedAt = user.CreatedAt,
                

            };
        }
    }

}
