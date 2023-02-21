using System;
using BmiApp.Models;

namespace BmiApp.DataAccess
{
public interface IBmiRepository : IRepository<BmiMetrics>
{
        Task<string> GetStatusByBmi(decimal bmi);
}
}