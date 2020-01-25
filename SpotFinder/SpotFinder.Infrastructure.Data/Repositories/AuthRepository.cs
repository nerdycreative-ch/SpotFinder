using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SpotFinder.Domain.IdentityModels;
using SpotFinder.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SpotFinder.Infrastructure.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByNameAsync(email);

            if (user != null)
                return true;

            return false;
        }

        public async Task<string> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
            {
                var tokenString = GenerateJWToken(user);

                return tokenString;
            }

            return "";
        }

        public async Task<string> Register(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var tokenString = GenerateJWToken(user);

                return tokenString;
            }

            return "";
        }

        public string GenerateJWToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            //var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
            var key = Encoding.ASCII.GetBytes("_Spot-Finder2020@`~Secret./Key");

            var tokenString = "";

            try
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.FirstName + ' ' + user.LastName),
                        //new Claim(ClaimTypes.Role, employeeFromRepo.EmployeeTypeId.ToString())
                    }),
                    Expires = DateTime.Now.AddHours(12),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                tokenString = tokenHandler.WriteToken(token);
            }

            catch
            {
                throw new Exception("You need to login first!");
            }

            return tokenString;
        }
    }
}
