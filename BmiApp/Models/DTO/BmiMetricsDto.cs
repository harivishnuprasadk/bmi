using System;
using System.ComponentModel.DataAnnotations;

namespace BmiApp.Models.DTO
{
	public class BmiMetricsDto
	{
        public decimal Bmi { get; set; }
        public WeightStatus WeightStatus { get; set; }

        public BmiMetrics ToModel()
        {
           return new BmiMetrics()
            {
                Bmi = Bmi,
                WeightStatus = WeightStatus,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                isActive = true,
                CreatedBy="Administrator",
                UpdatedBy="null"
           };
        }

        public List<BmiMetricsDto> ModelToDto(IEnumerable<BmiMetrics> bmiMetrics)
        {
          return bmiMetrics.Select(metric => new BmiMetricsDto
          {
              Bmi = metric.Bmi,
              WeightStatus = metric.WeightStatus
          }).ToList();

            //IEnumerable<BmiMetricsDto> bmiMetricsDto = from b in bmiMetrics
            //                            select new BmiMetricsDto
            //{
            //    Bmi = b.Bmi,
            //    WeightStatus = b.WeightStatus
            //};
            //return bmiMetricsDto;
        }
    }
}

