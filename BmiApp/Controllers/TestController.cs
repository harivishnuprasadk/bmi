using BmiApp.DataAccess;
using BmiApp.Models;
using BmiApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;
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
    public class TestController : ControllerBase
    {
       
        [HttpGet("test")]
        public async Task<IActionResult> GetTest ()
        {
            return Ok("test");
        }
    }
}