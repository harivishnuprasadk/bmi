using System;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs;
using System.IO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using BmiApp.Models.DTO;
using BmiApp.DataAccess;
using BmiApp.Models;

namespace BmiApp.Services
{
    public class BmiService : IBmiService
    {
        private IBmiRepository _bmiRepository;
        private readonly IBmiUserHealthRepository _bmiUserHealthRepository;
        public BmiService(IBmiRepository bmiRepository, IBmiUserHealthRepository bmiUserHealthRepository)
        {
            _bmiRepository = bmiRepository;
            _bmiUserHealthRepository = bmiUserHealthRepository;
        }

       public async Task <List<BmiMetricsDto>> GetAllBmiMetrics()
        {
            BmiMetricsDto bmiMetricsDtoModel = new BmiMetricsDto();
            IEnumerable<BmiMetrics> bmimetrics = await _bmiRepository.GetAll();
            return bmiMetricsDtoModel.ModelToDto(bmimetrics);
        }

      public async Task InsertBmiMetrics(BmiMetricsDto bmiMetricsDto)
        {
            if (bmiMetricsDto.Bmi==0 || bmiMetricsDto.WeightStatus==WeightStatus.none)
            {
                throw new ApplicationException("Invalid input");
            }
           BmiMetrics bmiMetrics= bmiMetricsDto.ToModel();
          await _bmiRepository.Add(bmiMetrics);
        }
    }
}
