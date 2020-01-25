using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpotFinder.Domain.Context
{
    //public class SpotFinderDBContext : IdentityDbContext
    //{
    //    public SpotFinderDBContext(DbContextOptions<SpotFinderDBContext> options)
    //        : base(options)
    //    {
    //    }
    //}

    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SpotFinderDBContext>
    //{
    //    public SpotFinderDBContext CreateDbContext(string[] args)
    //    {
    //        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../SpotFinder.Web/appsettings.json").Build();
    //        var builder = new DbContextOptionsBuilder<SpotFinderDBContext>();
    //        var connectionString = configuration.GetConnectionString("SpotFinderDBConnection");
    //        builder.UseSqlServer(connectionString);
    //        return new SpotFinderDBContext(builder.Options);
    //    }
    //}

}
