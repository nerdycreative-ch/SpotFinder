using SpotFinder.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotFinder.Application.Interfaces
{
    public interface ISpotTypesService
    {
        Task<IEnumerable<SpotTypesViewModel>> GetSpotTypes();
    }
}
