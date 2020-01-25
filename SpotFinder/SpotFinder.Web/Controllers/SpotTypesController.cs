using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotFinder.Application.Interfaces;

namespace SpotFinder.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotTypesController : ControllerBase
    {
        private readonly ISpotTypesService _spotTypesService;

        public SpotTypesController(ISpotTypesService spotTypesService)
        {
            _spotTypesService = spotTypesService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var spotTypes = _spotTypesService.GetSpotTypes();

            return Ok(spotTypes.Result);
        }
    }
}