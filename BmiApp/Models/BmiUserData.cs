using System;
using System.ComponentModel.DataAnnotations;

namespace BmiApp.Models
{
	public class BmiUserData:AuditEntity
	{
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<BmiUserHealthData> BmiUserHealthData { get; set; }
    }
}
