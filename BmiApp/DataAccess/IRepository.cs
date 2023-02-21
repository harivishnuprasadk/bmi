using System;
using System.Collections.Generic;

namespace BmiApp.DataAccess
{
    public interface IRepository<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> GetAll();
        Task Add(TModel entity);
    }
}
