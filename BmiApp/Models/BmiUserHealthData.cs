using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace BmiApp.Models
{
	public class BmiUserHealthData:AuditEntity
	{
        public int Id { get; set; }
        public int FkBmiUserData { get; set; }
        public decimal Height { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public decimal Bmi { get; set; }
        [Required]
        public string WeightStatus { get; set; }
        public string DocUrl { get; set; }
        public int age { get; set; }
        public BmiUserData BmiUserData { get; set; }
    }
}

