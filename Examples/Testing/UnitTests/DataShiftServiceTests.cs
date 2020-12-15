using System;
using FluentAssertions;
using NUnit.Framework;
using UnitTestsTarget;

namespace UnitTests
{
    public class DataShiftServiceTests
    {
        private DayShiftService ServiceInstance = new DayShiftService(new DayOfWeekService());

        [Test]
        public void GetShiftDay_halfYear_Before()
        {
            var startedTestDate = new DateTime(2020, 12, 15);
            var resultDate = new DateTime(2020, 6, 15);

            ServiceInstance.GetShiftBusinessDay(startedTestDate, -183).Should().Be(resultDate);
        }

        [Test]
        public void GetShiftDay_halfYear_After()
        {
            var startedTestDate = new DateTime(2020, 6, 15);
            var resultDate = new DateTime(2020, 12, 15);

            ServiceInstance.GetShiftBusinessDay(startedTestDate, 183).Should().Be(resultDate);
        }
        
        [Test]
        public void GetShiftBusinessDay_RealLogic_From_End_Of_Month()
        {
            var initialDate = new DateTime(2020, 02, 28);
            var resultDate = new DateTime(2020, 03, 2);

            ServiceInstance.GetShiftBusinessDay(initialDate, 2).Should().Be(resultDate);
        }
        
        [Test]
        public void GetShiftBusinessDay_RealLogic_From_Begin_Of_Month()
        {
            var initialDate = new DateTime(2021, 01, 01);
            var resultDate = new DateTime(2020, 12, 31);

            ServiceInstance.GetShiftBusinessDay(initialDate, -1).Should().Be(resultDate);
        }
        
    }
}