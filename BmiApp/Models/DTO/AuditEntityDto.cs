using System;
namespace BmiApp.Models
{
	public class AuditEntityDto
    {
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}

