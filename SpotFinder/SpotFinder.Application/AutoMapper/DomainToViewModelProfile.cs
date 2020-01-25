using AutoMapper;
using SpotFinder.Application.ViewModels;
using SpotFinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotFinder.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<SpotTypes, SpotTypesViewModel>();
        }
    }
}
