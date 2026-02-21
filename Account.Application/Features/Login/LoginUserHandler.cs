using MyProject.Account.Application.Dtos;
using MyProject.Account.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Account.Application.Features.Login
{
    public class LoginUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenService _jwtService;

        public LoginUserHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IJwtTokenService jwtService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task<LoginResponseDto> Handle(LoginRequestDto request)
        {
            // 1. Find user
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
                throw new Exception("Invalid email or password");

            // 2. Verify password
            var valid = _passwordHasher.Verify(request.Password, user.PasswordHash);

            if (!valid)
                throw new Exception("Invalid email or password");

            // 3. Generate token
            var token = _jwtService.GenerateToken(user);

            return new LoginResponseDto
            {
                Token = token
            };
        }
    }

}
