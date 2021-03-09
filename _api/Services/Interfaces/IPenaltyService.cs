using System.Threading.Tasks;
using PenaltyCalculation.API.Dtos;

namespace PenaltyCalculation.API.Services.Interfaces
{
    public interface IPenaltyService
    {
        Task<PenaltyToReturnDto> CalculatePenalty(PenaltyToCalculateDto dto);
    }
}