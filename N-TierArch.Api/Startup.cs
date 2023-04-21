using DataBase;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using N_TierArch.BLL.MappingDomain;
using N_TierArch.BLL.services.Deparment;
using N_TierArch.BLL.services.Developer;
using N_TierArch.BLL.services.Tiket;
using N_TierArch.DAL.CutomMiddleware;
using N_TierArch.DAL.Models;
using N_TierArch.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_TierArch.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSession(options =>
            //{
            //    options.Cookie.Name = ".AdventureWorks.Session";
            //    options.IdleTimeout = TimeSpan.FromSeconds(500);
            //    options.Cookie.IsEssential = true;
            //});
            services.AddDistributedMemoryCache();
            services.AddAutoMapper(map => map.AddProfile(new DomainProfie()));
            services.AddDbContext<DBHelper>(
                options =>options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ITicketService,TicketService>();
            services.AddScoped<IDeveloperService, DeveloperService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddControllers();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "N_TierArch.Api", Version = "v1" });
            });
            services.AddSingleton<Request>();
            services.AddTransient<RequestCounterMiddleware>();
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;
            })
          .AddEntityFrameworkStores<DBHelper>();


            // Adding Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JWT";
                options.DefaultChallengeScheme = "JWT";

            }).AddJwtBearer("JWT", options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            builder.Configuration.GetValue<string>("Authentication:SecurityKey") ?? ""))
                };
            });

            // Adding Authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                {
                    policy.RequireRole("Admin");
                });

                options.AddPolicy("UserOrAdmin", policy =>
                {
                    policy.RequireRole("Admin", "User");
                });
            });
        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "N_TierArch.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseMiddleware(typeof(RequestCounterMiddleware));

            //app.UseSession();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
