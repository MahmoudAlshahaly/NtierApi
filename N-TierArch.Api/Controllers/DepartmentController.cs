using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N_TierArch.BLL.services.Deparment;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace N_TierArch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
          return Ok(  departmentService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetDeparmentByID(int id)
        {

            //HttpContext.Session.SetString("sessionsSet","ahmed");
            //var name=  HttpContext.Session.GetString("sessionsSet");
            //HttpContext.Session.Remove("sessionsSet");

            //CookieOptions cookie = new CookieOptions();
            //cookie.Expires = DateTime.Now.AddDays(1);
            //cookie.IsEssential = true;
            //HttpContext.Response.Cookies.Append("CookieSet1", "KHLAlID", cookie);
            //var a = Request.Cookies["CookieSet1"];
            //Response.Cookies.Delete("CookieSet1");

            //ClaimsIdentity claims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            //claims.AddClaim(new Claim("CookieSet2", "mahmoud"));
            //claims.AddClaim(new Claim("id", "123"));
            //ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claims);
            
            //HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
            

            var dept = departmentService.GetByID(id);
            if(dept is null)
            {
                return NotFound();
            }
            return Ok(dept);
        }
    }
}
