using System;
using BmiApp.Utilities;
namespace BmiAppTest
{
    public class BmiUtilityTest
    {
        [Fact]
        public void WhenDataIsPassedReturnBmi()
        {
            decimal bmi=BmiCalcUtility.BmiCalculator(177.22m,77.2m);
            Assert.IsType<decimal>(bmi);
            Assert.Equal(24.58m, bmi);
        }

        [Fact]
        public void WhenDataIsPassedReturnAge()
        {
            int expectedAge = 27;
            int actualAge = BmiAgeCalcUtility.GetUserAge(new DateTime(1995,10,10,00,00,0000));
            Assert.IsType<int>(actualAge);
            Assert.Equal(expectedAge, actualAge);
        }
    } 
}