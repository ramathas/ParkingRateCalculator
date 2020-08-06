using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingRateCalculator.API
{
    public class StandardRateCalculator : IRateCalculator
    {
        public ParkingCharge GetRate(DateTime entryDateTime, DateTime exitDateTime)
        {
            var hours = (exitDateTime - entryDateTime).TotalHours;
            double amount;
            if (hours <= 3)
            {
                amount = Math.Ceiling(hours) * 5;
            }
            else
            {
                amount = (Math.Ceiling((exitDateTime - entryDateTime).TotalDays)) * 20;
            }

            return new ParkingCharge
            {
                RateName = "Standard Rate",
                RateType = "Hourly Rate",
                Amount = amount
            };
        }
    }
}
