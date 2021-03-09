using System.Collections.Generic;
using System.Threading.Tasks;
using PenaltyCalculation.API.Entities;

namespace PenaltyCalculation.API.Infrastructure.Persistence.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountries();
    }
}