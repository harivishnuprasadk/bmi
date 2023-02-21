using System;
namespace BmiApp.Utilities
{
	public static class BmiAgeCalcUtility
	{
        public static int GetUserAge(DateTime dateOfBirth)
        {
            int birthYear = dateOfBirth.Year;
            int currentYear = DateTime.Now.Year;
            int age = currentYear - birthYear;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
            {
                age = age - 1;
            }
            return age;
        }
    }
}

