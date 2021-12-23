using System;
using System.Collections.Generic;
using Xunit;

namespace RetirementCalculator
{
    public class CalculatorTest
    {
        [Fact]
        public void WhenUserInputNumberAsString_ThenConvertToInt()
        {
            Assert.Equal(1, ConvertToNumber("1"));
            Assert.Equal(2, ConvertToNumber("2"));
            Assert.Equal(3, ConvertToNumber("3"));
            Assert.Equal(4, ConvertToNumber("4"));

        }
        [Theory]
        [InlineData(25, 65, 40)]
        [InlineData(30, 60, 30)]
        [InlineData(65, 40, 0)]
        [InlineData(40, 20, 0)]
        public void WhenUserInputAgeAndRetireNumber_ThenCalculateTheRetireTime(int age, int retirePlan, int expected)
        {
            Assert.Equal(expected, CalculateRetireTime(age, retirePlan));
        }

        [Theory]
        [InlineData(25, 65, 2061)]
        [InlineData(30, 60, 2051)]
        [InlineData(65, 40, 0)]
        [InlineData(40, 20, 0)]
        public void WhenUserInputAgeAndRetireNumber_ThenCalculateTheYearOfRetirement(int age, int retirePlan, int expected)
        {
            Assert.Equal(expected, CalculateYearOfRetirement(age, retirePlan));
        }

        private int CalculateYearOfRetirement(int age, int retirePlan)
        {
            var year = DateTime.Now.Year;
            var retirePlanTime = retirePlan - age;
            return year + retirePlanTime > year ? year + retirePlanTime : 0;   
        }

        private int CalculateRetireTime(int age, int retirePlan)
        {
            var retPlan = retirePlan - age;
            return retPlan > 0 ? retPlan : 0;
        }

        private int ConvertToNumber(string input)
        {
            return Int32.Parse(input);
        }
    }
}