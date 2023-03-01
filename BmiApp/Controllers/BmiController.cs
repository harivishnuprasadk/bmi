using BmiApp.DataAccess;
using Microsoft.AspNetCore.Mvc;
using BmiApp.Models;
using BmiApp.Models.DTO;
using System.Linq;
using BmiApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace BmiApp.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class BmiController : ControllerBase
    {
        private readonly IBmiService _bmiService;
        public BmiController (IBmiService bmiService)
        {
            _bmiService = bmiService;
        }
        [HttpPost("addMetric")]
        public async Task<IActionResult> AddMetric(BmiMetricsDto bmiMetricsDto)
        {
            await _bmiService.InsertBmiMetrics(bmiMetricsDto);
            return Ok("Metrics added successfully");
        }

        [HttpGet("getAllMetrics")] 
        public async Task<IActionResult> GetAllBmiMetrics()
        {
           return Ok(await _bmiService.GetAllBmiMetrics());
        }

        [HttpGet("getTest")]
        public async Task<IActionResult> Test()
        {
            return Ok("pass");
        }
    }

}