using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ParkingRateCalculator.API;
using ParkingRateCalculator.API.Controllers;
using System;

namespace ParkingRateCalculatorTest
{
    public class Tests
    {
        IRateRepository repository;
        IRateCalculatorService calculatorService;
        ParkingRateController rateController;

      [SetUp]
        public void Setup()
        {
            repository = new InMemoryRateRepository();
            calculatorService = new RateCalculatorService(repository);
            rateController = new ParkingRateController(calculatorService);
        }        

        [Test]
        public void Test_EarlyBird()
        {
            DateTime entryTime = new DateTime(2020, 08, 06, 8, 30, 0);
            DateTime exitTime = new DateTime(2020, 08, 06, 16, 30, 0);

            var rate = rateController.GetRate(entryTime, exitTime);
            var okResult = rate as OkObjectResult;
            var changes = okResult.Value as ParkingCharge;

            Assert.That(changes.RateName == "Early Bird");
            Assert.That(changes.Amount == 13);
        }

        [Test]
        public void Test_NightRate()
        {
            DateTime entryTime = new DateTime(2020, 08, 06, 19, 30, 0);
            DateTime exitTime = new DateTime(2020, 08, 06, 22, 30, 0);

            var rate = rateController.GetRate(entryTime, exitTime);
            var okResult = rate as OkObjectResult;
            var changes = okResult.Value as ParkingCharge;

            Assert.That(changes.RateName == "Night Rate");
            Assert.That(changes.Amount == 6.5);
        }

        [Test]
        public void Test_WeekEndRate()
        {
            DateTime entryTime = new DateTime(2020, 08, 08, 2, 30, 0);
            DateTime exitTime = new DateTime(2020, 08, 09, 22, 30, 0);

            var rate = rateController.GetRate(entryTime, exitTime);
            var okResult = rate as OkObjectResult;
            var changes = okResult.Value as ParkingCharge;

            Assert.That(changes.RateName == "WeekEnd Rate");
            Assert.That(changes.Amount == 10);
        }

        [Test]
        public void Test_StandardRate()
        {
            DateTime entryTime = new DateTime(2020, 08, 06, 9, 30, 0);
            DateTime exitTime = new DateTime(2020, 08, 06, 14, 30, 0);

            var rate = rateController.GetRate(entryTime, exitTime);
            var okResult = rate as OkObjectResult;
            var changes = okResult.Value as ParkingCharge;

            Assert.That(changes.RateName == "Standard Rate");
            Assert.That(changes.Amount == 20);
        }
    }
}