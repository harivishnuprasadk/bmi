using System;
using BmiApp.Models;
using BmiApp.Models.DTO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BmiApp.DataAccess
{
	public class BmiUserHealthRepository :Repository<BmiUserHealthData>, IBmiUserHealthRepository
	{
        private readonly BmiDbContext _dbContext;

        public BmiUserHealthRepository(BmiDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task <DateTime> GetDateOfBirth(string email)
        {  
            BmiUserData bmiUserData = await _dbContext.BmiUserData.Where(w => w.Email == email).FirstOrDefaultAsync();
            if(bmiUserData==null)
            {
                throw new ApplicationException("User doesn't exist");
            }
            return bmiUserData.DateOfBirth;
        }

        public async Task <BmiUserHealthDataSummaryDto> GetUserHealthSummary(int id, string email)
        {
            try
            {
                BmiUserHealthDataSummaryDto bmiUserHealthDataSummaryDtoModel = new BmiUserHealthDataSummaryDto();
                BmiUserHealthData bmiUserHealthData = await _dbContext.BmiUserHealthData.Where(u => u.FkBmiUserData == id).OrderByDescending(u => u.Id).FirstOrDefaultAsync();
                BmiUserHealthDataSummaryDto bmiUserHealthDataSummaryDto = bmiUserHealthDataSummaryDtoModel.ModelToDto(id, bmiUserHealthData, email);

                return bmiUserHealthDataSummaryDto;
            }
            catch(Exception e)
            {
                throw new ApplicationException("invalid email address");
            }
        }

        public async Task<IEnumerable<BmiUserHealthDataSummaryDto>> GetUserHealthHistory(string email)
        {
            try
            {
                BmiUserData bmiUserData = await _dbContext.BmiUserData.Where(w => w.Email == email).FirstOrDefaultAsync();
                int userId = bmiUserData.Id;
                IEnumerable<BmiUserHealthData> bmiUserHealthData = await _dbContext.BmiUserHealthData.Where(u => u.FkBmiUserData == userId).ToListAsync();
                IEnumerable<BmiUserHealthDataSummaryDto> bmiUserHealthDataSummaryDto = bmiUserHealthData.Select(data => new BmiUserHealthDataSummaryDto
                {
                    Id = data.FkBmiUserData,
                    email = email,
                    Height = data.Height,
                    Weight = data.Weight,
                    Bmi = data.Bmi,
                    WeightStatus = data.WeightStatus,
                    DocUrl = data.DocUrl,
                    age = data.age
                }).ToList();
                return bmiUserHealthDataSummaryDto;
            }
            catch(Exception e)
            {
                throw new ApplicationException("invalid email address");
            }
            
        }
    }
}

