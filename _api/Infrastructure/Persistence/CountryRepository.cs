using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PenaltyCalculation.API.Entities;
using PenaltyCalculation.API.Infrastructure.Persistence.Interfaces;

namespace PenaltyCalculation.API.Infrastructure.Persistence
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }
    }
}