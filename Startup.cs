using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Repository.Hospital;
using WebApplication1.Repository.Patient;
using WebApplication1.Repository.User;

namespace WebApplication1
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AkmegnDb")));
            services.AddControllers();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddScoped<IHospitalReporitory,Hospitals_reposirory>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            var provider = services.BuildServiceProvider();
            var configuration =provider.GetService<IConfiguration>();
            services.AddCors(
                options =>
                {
                    var frontendUrl = configuration.GetValue<string>("frontend_url");
                    options.AddDefaultPolicy(builder =>
                    {
                        builder.WithOrigins(frontendUrl).AllowAnyMethod().AllowAnyHeader();
                        
                    });
            }
                
                 );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors();
          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
