using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingRateCalculator.API
{
    public interface IRateCalculator
    {
        public ParkingCharge CalculateChages(DateTime entryDateTime, DateTime exitDateTime);
    }
}
