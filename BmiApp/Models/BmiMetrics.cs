using System;
using System.ComponentModel.DataAnnotations;
using BmiApp.Models;

namespace BmiApp.Models
{
	public class BmiMetrics: AuditEntity
    {
        public int Id { get; set; }
        [Required]
        public decimal Bmi { get; set; }
        [Required]
        public WeightStatus WeightStatus  { get; set; }
    }
}