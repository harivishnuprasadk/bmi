using System;
namespace BmiApp.Models.DTO
{
	public class BmiUserDataDto
	{
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }

        public BmiUserData ToModel(BmiUserDataDto bmiUserDataDto)
        {
           return new BmiUserData()
            {
                Email = bmiUserDataDto.Email,
                PhoneNumber = bmiUserDataDto.PhoneNumber,
                DateOfBirth = DateTime.Parse(bmiUserDataDto.DateOfBirth),
                Created = DateTime.UtcNow,
                Updated = null,
                isActive = true,
                CreatedBy= bmiUserDataDto.Email,
                UpdatedBy="null"
           };
        }

        public BmiUserDataDto ModelToDto(BmiUserData bmiUserData)
        {
            return new BmiUserDataDto()
            {
                Email=bmiUserData.Email,
                PhoneNumber=bmiUserData.PhoneNumber,
                DateOfBirth=bmiUserData.DateOfBirth.ToShortDateString()
            };
        }
    }
}

