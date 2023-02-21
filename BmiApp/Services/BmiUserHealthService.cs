using System;
using BmiApp.DataAccess;
using BmiApp.Utilities;
using BmiApp.Models;
using BmiApp.Models.DTO;

namespace BmiApp.Services
{
    public class BmiUserHealthService : IBmiUserHealthService
    {
        private readonly IBmiUserRepository _bmiUserRepository;
        private readonly IBmiRepository _bmiRepository;
        private readonly IBmiUserHealthRepository _bmiUserHealthRepository;
        private readonly BmiBlobUtility _bmiBlobUtility;
        public BmiUserHealthService(IBmiUserRepository bmiUserRepository, IBmiRepository bmiRepository, IBmiUserHealthRepository bmiUserHealthRepository, BmiBlobUtility bmiBlobUtility)
        {
            _bmiRepository = bmiRepository;
            _bmiUserRepository = bmiUserRepository;
            _bmiUserHealthRepository = bmiUserHealthRepository;
            _bmiBlobUtility = bmiBlobUtility;
        }

        public async Task AddUserHealthData(string email, decimal height, decimal weight, IFormFile file)
        {
            decimal userBmi = BmiCalcUtility.BmiCalculator(height, weight);
            DateTime dateOfBirth =await _bmiUserHealthRepository.GetDateOfBirth(email);
            BmiUserHealthData bmiUserHealthData = new BmiUserHealthData()
            {
                FkBmiUserData =await _bmiUserRepository.GetUserId(email),
                Height = height,
                Weight = weight,
                Bmi = userBmi,
                WeightStatus = await _bmiRepository.GetStatusByBmi(userBmi),
                Created = DateTime.Now,
                Updated = null,
                isActive = true,
                DocUrl = _bmiBlobUtility.GetBlobUrl(file),
                age = BmiAgeCalcUtility.GetUserAge(dateOfBirth),
                CreatedBy = email,
                UpdatedBy = null
            };
            
            await _bmiUserHealthRepository.Add(bmiUserHealthData);
        }


        public async Task <BmiUserHealthDataSummaryDto> GetUserHealthDataSummary(string email)
        {
            int userId = await _bmiUserRepository.GetUserId(email);
            return await _bmiUserHealthRepository.GetUserHealthSummary(userId, email);
        }

        public async Task<IEnumerable<BmiUserHealthDataSummaryDto>> GetUserHealthDataHistory(string email)
        {
            return await _bmiUserHealthRepository.GetUserHealthHistory(email);
        }
    }
}

