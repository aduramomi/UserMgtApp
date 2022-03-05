using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMgtApp.Models;
using Microsoft.EntityFrameworkCore;
using UserMgtApp.Services;
using UserMgtApp.Classes;
using Newtonsoft.Json.Serialization;

namespace UserMgtApp
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
            //register the UserMgtDbContext so that it can be available to the entire app via DI
            services.AddDbContext<UserMgtDbContext>(options => options.UseMySQL(Configuration.GetConnectionString("UserMgtDbConnStr")));

            //register the IUserService so that it can be available to the entire app via DI
            services.AddScoped<IUserService, UserService>();

            //register the INationalityService so that it can be available to the entire app via DI
            services.AddScoped<INationalityService, NationalityService>();

            //register the IUserTypeService so that it can be available to the entire app via DI
            services.AddScoped<IUserTypeService, UserTypeService>();

            //register the UserApiConsumptionClass so that it can be available to the entire app via DI
            services.AddScoped<UserApiConsumptionClass, UserApiConsumptionClass>();

            //register the NationalityApiConsumptionClass so that it can be available to the entire app via DI
            services.AddScoped<NationalityApiConsumptionClass, NationalityApiConsumptionClass>();

            //register the UserTypeApiConsumptionClass so that it can be available to the entire app via DI
            services.AddScoped<UserTypeApiConsumptionClass, UserTypeApiConsumptionClass>();

            services.AddSwaggerGen();

            services.AddMvc()
              .AddNewtonsoftJson(options =>
              options.SerializerSettings.ContractResolver =
                 new DefaultContractResolver());

            services.AddControllersWithViews();           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "UserMgtAppApi");
            });
        }
    }
}
