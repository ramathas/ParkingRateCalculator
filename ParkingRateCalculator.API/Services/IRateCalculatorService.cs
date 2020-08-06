using System;

namespace ParkingRateCalculator.API
{
    public interface IRateCalculatorService
    {
        public ParkingCharge CalculateCharges(DateTime entryDateTime, DateTime exitDateTime);
    }
}