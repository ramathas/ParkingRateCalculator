using System.Collections.Generic;

namespace ParkingRateCalculator.API
{
    public interface IRateRepository
    {
        public Dictionary<string, double> GetParkingRates();
    }
}