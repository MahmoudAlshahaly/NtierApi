using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace N_TierArch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController(UserManager<ApplicationUser> manager)
        {
            Manager = manager;
        }

        public UserManager<ApplicationUser> Manager { get; }

        [HttpGet]
        [Route("GetInfoForManager")]
        [Authorize(Policy = "AdminOnly")]
        public string[] GetInfoForManager()
        {
            return new[] { "Value1 For Admin only", "Value2  For Admin only" };
        }

        [HttpGet]
        [Route("GetInfoForUser")]
        [Authorize(Policy = "UserOrAdmin")]
        public string[] GetInfoForUser()
        {
            return new[] { "value1 For Admin Or User", "Value2 For Admin Or User" };
        }

        [HttpGet]
        [Route("GetAuthUser")]
        [Authorize]
        public IActionResult GetUser()
        {
            var userName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var usercolor = User.Claims.FirstOrDefault(c => c.Type == "Color");
            return Ok(new userData(userName?.Value, usercolor?.Value, userEmail?.Value));
        }
    }
}
