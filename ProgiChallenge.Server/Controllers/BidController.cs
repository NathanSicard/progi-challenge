using Microsoft.AspNetCore.Mvc;
using ProgiChallenge.Server.Models;
using ProgiChallenge.Server.Utils;
using System.Net;

namespace ProgiChallenge.Server.Controllers
{
    public class VehicleBody
    {
        public double basePrice { get; set; }
        public string vehicleType { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class BidController : ControllerBase
    {
        private readonly ILogger<BidController> _logger;
        private readonly FeeCalculator feeCalculator = new FeeCalculator();

        public BidController(ILogger<BidController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "PostBid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([Bind("BasePrice,VehicleType")] VehicleBody vehicleBody)
        {
            if (vehicleBody.basePrice < 0 || vehicleBody.basePrice * 100 != Math.Floor(vehicleBody.basePrice * 100)) { return BadRequest("Invalid base price"); }

            // FIXME: This solution lacks elegance and should be solvable with a solution that exists outside the controller which better uses polymorphism.
            if (vehicleBody.vehicleType == "Common") { return Ok(feeCalculator.CalculateFees(new CommonVehicle(vehicleBody.basePrice))); }
            if (vehicleBody.vehicleType == "Luxury") { return Ok(feeCalculator.CalculateFees(new LuxuryVehicle(vehicleBody.basePrice))); }

            // TODO: This should return a 400 type error
            return BadRequest("Invalid vehicle type");
        }
    }
}
