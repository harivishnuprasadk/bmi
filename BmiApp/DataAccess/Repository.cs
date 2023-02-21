using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BmiApp.DataAccess
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        protected readonly DbContext _databaseContext;

        public Repository(DbContext context)
        {
            this._databaseContext = context;
        }

        public async Task Add(TModel entity)
        {
            _databaseContext.Set<TModel>().Add(entity);
           await _databaseContext.SaveChangesAsync();
        }

        public async Task <IEnumerable<TModel>> GetAll()
        {
            return await _databaseContext.Set<TModel>().ToListAsync();
        }
    }
}
