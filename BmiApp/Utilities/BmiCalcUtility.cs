using System;

namespace BmiApp.Utilities
{
	public static class BmiCalcUtility
	{
        public static decimal BmiCalculator(decimal height, decimal weight)
        {
            double doubleHeight = (double)height;
            double doubleWeight = (double)weight;
            double heightInMetres = (double)(doubleHeight / 100);
            double bmi = doubleWeight / ((heightInMetres) * (heightInMetres));
            decimal bmiRounded = Math.Round((decimal)bmi, 2);

            return bmiRounded;
        }
    }
}

