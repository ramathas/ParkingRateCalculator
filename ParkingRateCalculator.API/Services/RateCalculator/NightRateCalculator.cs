using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingRateCalculator.API
{
    public class NightRateCalculator : IRateCalculator
    {
        public ParkingCharge CalculateChages(DateTime entryDateTime, DateTime exitDateTime)
        {
            if (entryDateTime.IsWeekDay() && (entryDateTime.Hour > 18)
                && exitDateTime.TimeOfDay >= new TimeSpan(15, 30, 0)
                && exitDateTime.TimeOfDay <= new TimeSpan(23, 30, 0))
            {
                return new ParkingCharge
                {
                    RateName = "Night Rate",
                    RateType = "Flat Rate",
                    Amount = 6.5
                };
            }
            return null;
        }
    }
}
