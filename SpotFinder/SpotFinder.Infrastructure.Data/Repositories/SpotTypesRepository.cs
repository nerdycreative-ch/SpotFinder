using Microsoft.EntityFrameworkCore;
using SpotFinder.Domain.Models;
using SpotFinder.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotFinder.Infrastructure.Data.Repositories
{
    public class SpotTypesRepository : ISpotTypesRepository
    {
        private SpotFinderDBContext _ctx;
        public SpotTypesRepository(SpotFinderDBContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<SpotTypes> GetSpotTypes()
        {
            return _ctx.SpotTypes;
        }
    }
}
