using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PenaltyCalculation.API.Dtos;
using PenaltyCalculation.API.Infrastructure.Persistence.Interfaces;
using PenaltyCalculation.API.Services.Interfaces;
using PenaltyCalculation.API.Services.Mappers;

namespace PenaltyCalculation.API.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        }

        public async Task<IEnumerable<CountryToReturnDto>> GetCountries()
        {
            var countries = await _countryRepository.GetCountries();
            return CountryMapper.MapFromEntity(countries);
        }
    }
}