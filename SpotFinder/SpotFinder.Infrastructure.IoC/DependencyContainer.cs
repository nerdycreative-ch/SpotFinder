using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpotFinder.Application.Interfaces;
using SpotFinder.Application.Services;
using SpotFinder.Domain.IdentityModels;
using SpotFinder.Domain.Models;
using SpotFinder.Infrastructure.Data.Interfaces;
using SpotFinder.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpotFinder.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Layer 
            services.AddScoped<ISpotTypesService, SpotTypesService>();
            services.AddScoped<IAuthService, AuthService>();

            //Infrastructure.Data Layer
            services.AddScoped<ISpotTypesRepository, SpotTypesRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();


            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../SpotFinder.Web/appsettings.json").Build();
            var connectionString = configuration.GetConnectionString("SpotFinderDBConnection");

            services.AddDbContext<SpotFinderDBContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<SpotFinderDBContext>()
            .AddDefaultTokenProviders();
        }
    }
}
