using System;
using BmiApp.DataAccess;
using BmiApp.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BmiApp.DataAccess
{

    public class BmiRepository : Repository<BmiMetrics>, IBmiRepository
    {
        //public BmiDbContext _bmiDbContext
        //{
        //    get { return _databaseContext as BmiDbContext; }
        //}
        private readonly BmiDbContext _dbContext;


        public BmiRepository(BmiDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext??throw new ArgumentNullException(nameof(dbContext));
        } 
    
        public async Task<string> GetStatusByBmi(decimal bmi)
        {
            try
            {
                BmiMetrics bmiMetrics = await _dbContext.BmiMetrics.Where(u => u.Bmi >= bmi).FirstOrDefaultAsync();
                string stat = bmiMetrics.WeightStatus.ToString();
                return stat;
            }
            catch(Exception e)
            {
                throw new ApplicationException("metrics not found/invalid bmi");
            }
        }
    }
}
