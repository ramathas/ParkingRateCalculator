using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingRateCalculator.API
{
    public class InMemoryRateRepository : IRateRepository
    {
        // ideally should keep the rates in DB table.
        // not using in memory data structure
        private Dictionary<string, double> _rates;
        
        public InMemoryRateRepository()
        {
            _rates = new Dictionary<string, double>();
            _rates.Add("Early Bird", 13);
            _rates.Add("Night Rate", 6.5);
            _rates.Add("WeekEnd Rate", 10);
            _rates.Add("Standard Rate", 20);
        }

        public Dictionary<string, double> GetParkingRates()
        {
            return _rates;
        }
    }
}
