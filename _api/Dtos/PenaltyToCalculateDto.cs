using System;

namespace PenaltyCalculation.API.Dtos
{
    public class PenaltyToCalculateDto
    {
        public int CountryId { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime ReturnedDate { get; set; }
    }
}