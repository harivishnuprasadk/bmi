using System;
using BmiApp.DataAccess;
using BmiApp.Models;
using BmiApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BmiApp.Services
{
    public class BmiUserService : IBmiUserService
    {
        private readonly IBmiUserRepository _bmiUserRepository;
        public BmiUserService(IBmiUserRepository bmiUserRepository)
        {
            _bmiUserRepository = bmiUserRepository;
        }
        

        public async Task AddUserData(BmiUserDataDto bmiUserDataDto)
        {
            BmiUserDataDto bmiUserDataDtoModel = new BmiUserDataDto();
            if (bmiUserDataDto.Email==null || bmiUserDataDto.DateOfBirth==null || bmiUserDataDto.PhoneNumber==null)
            {
                throw new Exception("Invalid input");
            }
            BmiUserData bmiUserData = bmiUserDataDtoModel.ToModel(bmiUserDataDto);
            await _bmiUserRepository.Add(bmiUserData);
        }

        public async Task <BmiUserDataDto> GetUserDataDto(string email)
        {
            BmiUserDataDto bmiUserDataDtoModel = new BmiUserDataDto();
            BmiUserData bmiUserData = await _bmiUserRepository.GetUserData(email);
            return bmiUserDataDtoModel.ModelToDto(bmiUserData);
        }

        public async Task UpdateUserPhoneNumber(string email, string phoneNumber)
        {
            await _bmiUserRepository.Update(email, phoneNumber);
        }

        public async Task hardDeleteUser(string email)
        {
            await _bmiUserRepository.hardDelete(email);
        }

        public async Task softDeleteUser(string email)
        {
            await _bmiUserRepository.softDelete(email);
        }
    }
}

