using System.Collections.Generic;
using System.Threading.Tasks;
using PenaltyCalculation.API.Dtos;

namespace PenaltyCalculation.API.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryToReturnDto>> GetCountries();
    }
}