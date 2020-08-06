using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkingRateCalculator.API;

namespace ParkingRateCalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingRateController : ControllerBase
    {
        

        private readonly IRateCalculatorService _calculatorService;
        public ParkingRateController(IRateCalculatorService calculatorService)
        {
            _calculatorService = calculatorService ?? throw new ArgumentNullException(nameof(calculatorService));
        }

        [HttpGet]
        [Route("Rate")]
        public IActionResult GetRate(DateTime entryDateTime, DateTime ExitDateTime)
        {
            ParkingCharge charge;
            try
            {
                charge = _calculatorService.CalculateCharges(entryDateTime, ExitDateTime);
                return Ok(charge);
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }
    }
}