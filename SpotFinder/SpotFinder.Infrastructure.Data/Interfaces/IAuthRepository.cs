using SpotFinder.Domain.IdentityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotFinder.Infrastructure.Data.Interfaces
{
    public interface IAuthRepository
    {
        Task<string> Register(ApplicationUser user, string password);

        Task<string> Login(string username, string password);

        Task<bool> GetUserByEmail(string email);
    }
}
