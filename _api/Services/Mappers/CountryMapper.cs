using System.Collections.Generic;
using System.Linq;
using PenaltyCalculation.API.Dtos;
using PenaltyCalculation.API.Entities;

namespace PenaltyCalculation.API.Services.Mappers
{
    public static class CountryMapper
    {
        public static IEnumerable<CountryToReturnDto> MapFromEntity(IEnumerable<Country> countries)
        {
            return countries.Select(country => new CountryToReturnDto {Id = country.Id, Name = country.Name}).ToList();
        }
    }
}