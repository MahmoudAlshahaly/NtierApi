using Microsoft.AspNetCore.Mvc;
using N_TierArch.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace N_TierArch.DAL.CutomFilter
{
    public class TypeFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var car = context.ActionArguments["car"] as Car;
            var regex = new Regex("^(Eletric|Gas|Diesel|Hybrid)$", RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2));

            if (car.Type == null || !regex.IsMatch(car.Type))
            {
                context.ModelState.AddModelError("Type", "Car Is Not Valid");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }

}
