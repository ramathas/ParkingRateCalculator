using ParkingRateCalculator.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingRateCalculator.API
{
    public static class RateCalculatorFactory
    {
        public static IRateCalculator GetCalculator(string RateType)
        {
            IRateCalculator calculator;
            switch(RateType)
            {
                case "Early Bird":
                    calculator = new EarlyBirdRateCalculator();
                    break;
                case "WeekEnd Rate":
                    calculator = new WeekEndRateCalculator();
                    break;
                case "Night Rate":
                    calculator = new NightRateCalculator();
                    break;
                default:
                    calculator = new StandardRateCalculator();
                    break;
            }

            return calculator;
        }
    }
}
