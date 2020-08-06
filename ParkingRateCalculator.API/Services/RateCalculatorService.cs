using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingRateCalculator.API
{
    public class RateCalculatorService: IRateCalculatorService
    {

        IRateRepository _rateRepository;

        public RateCalculatorService(IRateRepository rateRepository)
        {
            _rateRepository = rateRepository ?? throw new ArgumentNullException(nameof(rateRepository));
        }

        public ParkingCharge CalculateChages(DateTime entryDateTime, DateTime exitDateTime)
        {
            ParkingCharge charges = null;
            ParkingCharge comparitionRate = null;

            // get all type of rates and order by price
            Dictionary<string, double> rateDictionary = _rateRepository.GetParkingRates();
            var orderedDictionary = rateDictionary.OrderBy(r => r.Value);

            IRateCalculator rateCalculator;

            //ordering by cheapest
            foreach (KeyValuePair<string, double> item in orderedDictionary)
            {
                rateCalculator = RateCalculatorFactory.GetCalculator(item.Key);

                comparitionRate  = rateCalculator.CalculateChages(entryDateTime, exitDateTime);
                if (charges == null && comparitionRate != null)
                {
                    charges = comparitionRate;
                }
                else if(charges != null && comparitionRate != null)
                {
                    if(charges.Amount > comparitionRate.Amount)
                    {
                        charges = comparitionRate;
                    }
                }
            }
            return charges;
        }
    }
}
