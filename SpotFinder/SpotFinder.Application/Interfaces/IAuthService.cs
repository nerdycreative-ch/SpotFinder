using Microsoft.AspNetCore.Identity;
using SpotFinder.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotFinder.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> Register(RegisterUserViewModel registerViewModel);

        Task<string> Login(LoginViewModel loginViewModel);

        Task<bool> GetUserByEmail(string email);
    }
}
