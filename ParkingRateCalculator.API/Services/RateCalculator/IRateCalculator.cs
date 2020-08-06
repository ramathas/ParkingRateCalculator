using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingRateCalculator.API
{
    public interface IRateCalculator
    {
        public ParkingCharge GetRate(DateTime entryDateTime, DateTime exitDateTime);
    }
}
