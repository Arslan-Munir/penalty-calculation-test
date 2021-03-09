using System;

namespace PenaltyCalculation.API.Entities
{
    public class Holiday : Entity
    {
        public int CountryId { get; set; }   
        public DateTime HolidayDate { get; set; }
        public Country Country { get; set; }
    }
}