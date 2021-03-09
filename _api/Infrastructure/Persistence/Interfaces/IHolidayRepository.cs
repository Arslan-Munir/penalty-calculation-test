using System.Collections.Generic;
using System.Threading.Tasks;
using PenaltyCalculation.API.Entities;

namespace PenaltyCalculation.API.Infrastructure.Persistence.Interfaces
{
    public interface IHolidayRepository
    {
        Task<IEnumerable<Holiday>> GetCountryHolidays(int countryId);
        Task<IEnumerable<WeekHoliday>> GetCountryWeekHolidays(int countryId);
    }
}