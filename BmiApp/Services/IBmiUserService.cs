using System;
using BmiApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BmiApp.Services
{
	public interface IBmiUserService
	{
        Task AddUserData(BmiUserDataDto bmiUserDataDto);
        Task UpdateUserPhoneNumber(string email, string phoneNumber);
        Task softDeleteUser(string email);
        Task hardDeleteUser(string email);
        Task <BmiUserDataDto> GetUserDataDto(string email);
    }
}

