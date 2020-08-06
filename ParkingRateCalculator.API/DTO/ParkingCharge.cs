using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingRateCalculator.API
{
    public class ParkingCharge
    {
        public string RateName { get; set; }
        public string RateType { get; set; }
        public double Amount { get; set; }
    }
}
