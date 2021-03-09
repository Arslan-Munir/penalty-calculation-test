using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PenaltyCalculation.API.Dtos;
using PenaltyCalculation.API.Services.Interfaces;

namespace PenaltyCalculation.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PenaltyController : ControllerBase
    {
        private readonly IPenaltyService _penaltyService;

        public PenaltyController(IPenaltyService penaltyService)
        {
            _penaltyService = penaltyService ?? throw new ArgumentNullException(nameof(penaltyService));
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(PenaltyToCalculateDto dto)
        {
            if (dto.CheckoutDate >= dto.ReturnedDate)
                throw new InvalidOperationException("Dates are not correct");

            var penaltyToReturn = await _penaltyService.CalculatePenalty(dto);
            return Ok(penaltyToReturn);
        }
    }
}