using System;
using BmiApp.Models.DTO;

namespace BmiApp.Services
{
	public interface IBmiService
	{
		Task InsertBmiMetrics(BmiMetricsDto bmiMetricsDto);
        Task <List<BmiMetricsDto>> GetAllBmiMetrics();
    }
}

