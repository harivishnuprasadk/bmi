using System;
using BmiApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BmiApp.DataAccess
{
	public class BmiUserRepository : Repository<BmiUserData>, IBmiUserRepository
    {
        private readonly BmiDbContext _dbContext;


        public BmiUserRepository(BmiDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<int> GetUserId(string email)
        {
                BmiUserData bmiUserData = await _dbContext.BmiUserData.Where(u => u.Email == email).FirstOrDefaultAsync();
                if (bmiUserData == null) throw new Exception("User doesn't exist");
                int userId = bmiUserData.Id;
               return userId; 
        }

        public async Task Update<T>(T email, T phoneNo)
        {
            try
            {

                int id = await GetUserId(email.ToString());
                await _dbContext.BmiUserData
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(b => b
                .SetProperty(u => u.PhoneNumber, phoneNo.ToString())
                .SetProperty(u => u.Updated, DateTime.Now)
                .SetProperty(u => u.UpdatedBy, email.ToString())
                 );
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new ApplicationException();
            }
        }

        public async Task softDelete(string email)
        {
            try
            {
                int id = await GetUserId(email.ToString());
                await _dbContext.BmiUserData
                    .Where(u => u.Id == id)
                    .ExecuteUpdateAsync(b => b.SetProperty(u => u.isDeleted, true));
                await _dbContext.BmiUserHealthData
                     .Where(u => u.FkBmiUserData == id)
                     .ExecuteUpdateAsync(b => b.SetProperty(u => u.isDeleted, true));
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new ApplicationException();
            }

        }

        public async Task hardDelete(string email)
        {
            try
            {
                int id = await GetUserId(email.ToString());
                await _dbContext.BmiUserData.Where(u => u.Id == id).ExecuteDeleteAsync();
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new ApplicationException();
            }
        }

        public async Task<BmiUserData> GetUserData(string email)
        {
            try
            {
                int id = await GetUserId(email.ToString());
                return await _dbContext.BmiUserData.Where(u => u.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new ApplicationException();
            }
        }
    }
}
