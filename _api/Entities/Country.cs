using System.Collections.Generic;

namespace PenaltyCalculation.API.Entities
{
    public class Country : Entity
    {
        public string Name { get; set; }
        public ICollection<Holiday> Holidays { get; set; }
    }
}