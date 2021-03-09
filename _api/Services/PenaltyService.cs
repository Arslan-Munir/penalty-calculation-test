using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PenaltyCalculation.API.Configurations;
using PenaltyCalculation.API.Dtos;
using PenaltyCalculation.API.Entities;
using PenaltyCalculation.API.Infrastructure.Persistence.Interfaces;
using PenaltyCalculation.API.Services.Interfaces;

namespace PenaltyCalculation.API.Services
{
    public class PenaltyService : IPenaltyService
    {
        private readonly IHolidayRepository _holidayRepository;
        private readonly PenaltyConfigurations _penaltyConfigs;

        public PenaltyService(IHolidayRepository holidayRepository, IOptions<PenaltyConfigurations> penaltyConfigs)
        {
            _holidayRepository = holidayRepository ?? throw new ArgumentNullException(nameof(holidayRepository));
            _penaltyConfigs = penaltyConfigs.Value ?? throw new ArgumentNullException(nameof(penaltyConfigs));
        }

        public async Task<PenaltyToReturnDto> CalculatePenalty(PenaltyToCalculateDto dto)
        {
            var excludedDates = await _holidayRepository.GetCountryHolidays(dto.CountryId);
            var excludedWeekDays = await _holidayRepository.GetCountryWeekHolidays(dto.CountryId);
            return Penalty(dto, excludedDates.ToList(), excludedWeekDays.ToList());
        }

        private PenaltyToReturnDto Penalty(PenaltyToCalculateDto dto, 
            IEnumerable<Holiday> excludedHolidays, IEnumerable<WeekHoliday> excludedWeekHolidays)
        {
            var totalHolidays = excludedHolidays.Count(h =>
                h.HolidayDate >= dto.CheckoutDate || h.HolidayDate <= dto.ReturnedDate);
            
            var totalWeekHolidays = GetDaysBetweenDates(dto.CheckoutDate, dto.ReturnedDate)
                .Count(d => excludedWeekHolidays.Any(e => d.DayOfWeek == e.Day));
            
            Console.WriteLine(totalWeekHolidays);
            
            var totalDays = ((dto.ReturnedDate - dto.CheckoutDate).TotalDays) - totalHolidays - totalWeekHolidays;

            if (totalDays <= _penaltyConfigs.MaxReturnDays)
                return new PenaltyToReturnDto(totalDays, 0);

            var penaltyDays = totalDays - _penaltyConfigs.MaxReturnDays;
            return new PenaltyToReturnDto(totalDays, penaltyDays * _penaltyConfigs.PenaltyFee);
        }
        
        private IEnumerable<DateTime> GetDaysBetweenDates(DateTime start, DateTime end)
        {
            for (var i = start; i < end; i = i.AddDays(1))
                yield return i;
        }
    }
}