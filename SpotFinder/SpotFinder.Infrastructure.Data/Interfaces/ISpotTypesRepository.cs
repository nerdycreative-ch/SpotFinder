using SpotFinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotFinder.Infrastructure.Data.Interfaces
{
    public interface ISpotTypesRepository
    {
        IQueryable<SpotTypes> GetSpotTypes();
    }
}
