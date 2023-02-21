using System;
namespace BmiApp.Models.DTO
{
    public class BmiUserHealthDataSummaryDto
    {
        public int Id { get; set; }
        public string email { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal Bmi { get; set; }
        public string WeightStatus { get; set; }
        public string DocUrl { get; set; }
        public int age { get; set; }

        public BmiUserHealthDataSummaryDto ModelToDto(int id, BmiUserHealthData bmiUserHealthData, string email)
        {
            return new BmiUserHealthDataSummaryDto()
            {
                Id = id,
                email = email,
                Height = bmiUserHealthData.Height,
                Weight = bmiUserHealthData.Weight,
                Bmi = bmiUserHealthData.Bmi,
                WeightStatus = bmiUserHealthData.WeightStatus,
                DocUrl = bmiUserHealthData.DocUrl,
                age = bmiUserHealthData.age
            };
        }  
    }
}

