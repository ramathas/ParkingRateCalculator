using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingRateCalculator.API.Services
{
    public class WeekEndRateCalculator : IRateCalculator
    {
        public ParkingCharge CalculateChages(DateTime entryDateTime, DateTime exitDateTime)
        {
            // this will satisfy 
            //Enter anytime past midnight on Friday to Sunday
            //Exit any time before midnight of Sunday
            if (!entryDateTime.IsWeekDay() && !exitDateTime.IsWeekDay())
            {
                return new ParkingCharge
                {
                    RateName = "WeekEnd Rate",
                    RateType = "Flat Rate",
                    Amount = 10
                };
            }
            return null;
        }
    }
}
