using System.ComponentModel.DataAnnotations;
using BmiApp.DataAccess;
using BmiApp.Utilities;
using BmiApp.Services;
using BmiApp.Models;
using BmiApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BmiApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BmiUserHealthController : ControllerBase
    {
        private readonly IBmiUserHealthService _bmiUserHealthService;

        public BmiUserHealthController(IBmiUserHealthService bmiUserHealthService)
        {
            _bmiUserHealthService = bmiUserHealthService;
        }

        [HttpPost("addUserHealthData")]
        public async Task<IActionResult> AddUseHealthData(string email, decimal height, decimal weight, IFormFile file)
        {
            await _bmiUserHealthService.AddUserHealthData( email,  height,  weight,  file);
            return Ok("Addition Success");
        }

        [HttpGet("getUserHealthDataSummary")]
        public async Task<IActionResult> GetUserHealthDataSummary(string email)
        {
           return Ok(await _bmiUserHealthService.GetUserHealthDataSummary(email));
        }

        [HttpGet("getUserHealthDataHistory")]
        public async Task<IActionResult> GetUserHealthDataHistory(string email)
        {
            return Ok(await _bmiUserHealthService.GetUserHealthDataHistory(email));
        }
    }
}