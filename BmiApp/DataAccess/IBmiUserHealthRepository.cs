using System;
using BmiApp.Models;
using BmiApp.Models.DTO;

namespace BmiApp.DataAccess
{
	public interface IBmiUserHealthRepository :IRepository<BmiUserHealthData>
	{
		Task <BmiUserHealthDataSummaryDto> GetUserHealthSummary(int id, string email);
		Task <IEnumerable<BmiUserHealthDataSummaryDto>> GetUserHealthHistory(string email);
		Task <DateTime> GetDateOfBirth(string email);
    }
}

