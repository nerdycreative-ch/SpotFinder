using AutoMapper;
using AutoMapper.QueryableExtensions;
using SpotFinder.Application.Interfaces;
using SpotFinder.Application.ViewModels;
using SpotFinder.Domain.Models;
using SpotFinder.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotFinder.Application.Services
{
    public class SpotTypesService : ISpotTypesService
    {
        private readonly ISpotTypesRepository _repo;
        private readonly IMapper _autoMapper;

        public SpotTypesService(ISpotTypesRepository repo, IMapper autoMapper)
        {
            _repo = repo;
            _autoMapper = autoMapper;
        }
        public async Task<IEnumerable<SpotTypesViewModel>> GetSpotTypes()
        {
            return _autoMapper.Map<IEnumerable<SpotTypesViewModel>>(_repo.GetSpotTypes());
        }
    }
}
