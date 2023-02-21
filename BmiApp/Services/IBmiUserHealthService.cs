using System;
using BmiApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BmiApp.Services
{
	public interface IBmiUserHealthService
	{
         Task AddUserHealthData(string email, decimal height, decimal weight, IFormFile file);
         Task <BmiUserHealthDataSummaryDto> GetUserHealthDataSummary(string email);
         Task <IEnumerable<BmiUserHealthDataSummaryDto>> GetUserHealthDataHistory(string email);
    }
}

