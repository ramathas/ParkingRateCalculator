using System;

namespace ParkingRateCalculator.API
{
    public interface IRateCalculatorService
    {
        public ParkingCharge CalculateChages(DateTime entryDateTime, DateTime exitDateTime);
    }
}