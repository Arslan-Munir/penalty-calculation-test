using System;

namespace PenaltyCalculation.API.Entities
{
    public class WeekHoliday : Entity
    {
        public int CountryId { get; set; } 
        public DayOfWeek Day { get; set; }
        public Country Country { get; set; }
    }
}