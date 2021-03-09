using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PenaltyCalculation.API.Services.Interfaces;

namespace PenaltyCalculation.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var countries = await _countryService.GetCountries();
            return Ok(countries);
        }
    }
}