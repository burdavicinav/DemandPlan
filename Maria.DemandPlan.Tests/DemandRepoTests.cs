using System;
using Xunit;

using Maria.DemandPlan.UI.Models;
using Maria.DemandPlan.UI.Exceptions;

namespace DemandPlanTests
{
    public class DemandRepoTests
    {
        private IDemandRepo demandRepo;

        [Theory]
        [InlineData("")]
        [InlineData("test1")]
        [InlineData("0001")]
        public void AddNumFormatTest(string num)
        {
            demandRepo = new DemandRepo();

            Demand demand = new()
            {
                Num = num
            };

            Assert.Throws<DemandNumFormatException>(() => demandRepo.Add(demand));
        }

        [Theory]
        [InlineData("8 903 111111")]
        [InlineData("9 903 9033212")]
        [InlineData("8 496 1234234")]
        public void AddPhoneFormatTest(string phone)
        {
            demandRepo = new DemandRepo();

            Demand demand = new Demand()
            {
                Num = "111111",
                Phone = phone
            };

            Assert.Throws<DemandPhoneFormatException>(() => demandRepo.Add(demand));
        }


    }
}
