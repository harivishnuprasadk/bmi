using System;
using System.ComponentModel.DataAnnotations;

namespace BmiApp.Models.DTO
{
	public class BmiUserHealthDataDto
	{
        public string email { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
    }
}

