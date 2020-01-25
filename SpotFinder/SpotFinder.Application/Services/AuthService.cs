using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SpotFinder.Application.Interfaces;
using SpotFinder.Application.ViewModels;
using SpotFinder.Domain.IdentityModels;
using SpotFinder.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotFinder.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public async Task<bool> GetUserByEmail(string email)
        {
            return await _authRepository.GetUserByEmail(email);
        }

        public async Task<string> Login(LoginViewModel loginViewModel)
        {
            var token = await _authRepository.Login(username: loginViewModel.Username, password: loginViewModel.Password);

            return token;
        }

        public async Task<string> Register(RegisterUserViewModel registerViewModel)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = registerViewModel.Email,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
            };

            var token = await _authRepository.Register(user, registerViewModel.Password);

            return token;
        }
    }
}
