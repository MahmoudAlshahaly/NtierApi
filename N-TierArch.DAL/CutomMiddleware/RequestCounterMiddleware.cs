using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArch.DAL.CutomMiddleware
{
    public class RequestCounterMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var Req = context.RequestServices.GetService<Request>();
            if (Req != null)
            {
                Req.Count += 1;
            }
            await next.Invoke(context);
        }
    }
}
