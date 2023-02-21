using BmiApp.DataAccess;
using BmiApp.Models;
using BmiApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using BmiApp.Services;

namespace BmiApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BmiUserController : ControllerBase
    {
        private readonly IBmiUserService _bmiUserService;

        public BmiUserController(IBmiUserService bmiUserService)
        {
            _bmiUserService = bmiUserService;
        }
        [HttpPost("addUserData")]
        public async Task<IActionResult> AddUserData(BmiUserDataDto bmiUserDataDto)
        {
            await _bmiUserService.AddUserData(bmiUserDataDto);
            return Ok("Addition Success");
        }

        [HttpGet("getUserInfo")]
        public async Task<IActionResult> GetUserInfo(string email)
        {
            return Ok(await _bmiUserService.GetUserDataDto(email));
        }

        [HttpPut("updateUserPhoneNumber")]
        public async Task<IActionResult> UpdateUserPhoneNumber(string email, string phoneNumber)
        {
            await _bmiUserService.UpdateUserPhoneNumber(email, phoneNumber);
            return Ok("Update is success");
        }

        [HttpDelete("softDeleteUser")]
        public async Task<IActionResult> softDeleteUser(string email)
        {
            await _bmiUserService.softDeleteUser(email);
            return Ok("Delete is success");
        }

        [HttpDelete("hardDeleteUser")]
        public async Task<IActionResult> hardDeleteUser(string email)
        {
            await _bmiUserService.hardDeleteUser(email);
            return Ok("Delete is success");
        }
    }
}