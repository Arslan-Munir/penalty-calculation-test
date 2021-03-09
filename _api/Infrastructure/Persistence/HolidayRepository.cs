using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PenaltyCalculation.API.Entities;
using PenaltyCalculation.API.Infrastructure.Persistence.Interfaces;

namespace PenaltyCalculation.API.Infrastructure.Persistence
{
    public class HolidayRepository : IHolidayRepository
    {
        private readonly DataContext _context;

        public HolidayRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Holiday>> GetCountryHolidays(int countryId)
        {
            return await _context.Holidays
                .Where(h => h.CountryId == countryId)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<WeekHoliday>> GetCountryWeekHolidays(int countryId)
        {
            return await _context.WeekHolidays
                .Where(h => h.CountryId == countryId)
                .ToListAsync();
        }
    }
}