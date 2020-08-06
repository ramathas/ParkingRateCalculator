using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingRateCalculator.API.Services
{
    public class EarlyBirdRateCalculator : IRateCalculator
    {
       

        
        public ParkingCharge GetRate(DateTime entryDateTime, DateTime exitDateTime)
        {
            if (entryDateTime.TimeOfDay >= new TimeSpan(6, 0, 0)
               && entryDateTime.TimeOfDay <= new TimeSpan(9, 0, 0)
               && exitDateTime.TimeOfDay >= new TimeSpan(13, 30, 0)
               && exitDateTime.TimeOfDay <= new TimeSpan(23, 30, 0))
            {
                return new ParkingCharge
                {
                    RateName = "Early Bird",
                    RateType = "Flat Rate",
                    Amount = 13
                };
            }
            return null;
        }
    }
}
