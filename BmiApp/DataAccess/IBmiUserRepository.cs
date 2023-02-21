using System;
using BmiApp.Models;

namespace BmiApp.DataAccess
{
	public interface IBmiUserRepository : IRepository<BmiUserData>
    {
        Task <int> GetUserId(string email);
        Task Update<T>(T email, T phoneNo);
        Task  softDelete(string email);
        Task hardDelete(string email);
        Task <BmiUserData> GetUserData(string email);
    }
}

