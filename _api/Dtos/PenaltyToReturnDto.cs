namespace PenaltyCalculation.API.Dtos
{
    public class PenaltyToReturnDto
    {
        public double BusinessDays { get; set; }
        public double Penalty { get; set; }

        public PenaltyToReturnDto(double businessDays, double penalty)
        {
            BusinessDays = businessDays;
            Penalty = penalty;
        }
    }
}