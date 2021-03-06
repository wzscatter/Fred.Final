using Final.Core.RepositoryInterfaces;
using Final.Core.ServiceInterfaces;
using Final.Infrastructure.Data;
using Final.Infrastructure.Repository;
using Final.Infrastructure.Service;
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

namespace Final.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Final.API", Version = "v1" });
            });
            services.AddControllersWithViews();
            services.AddTransient<IClientService, ClientService>(); // whenever we see IMovieService as a constructor parameter, will replace that with MovieService Class; change here if we want to pass a new class as parameters
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IInteractionService, InteractionService>();

            services.AddTransient<IClientRepository, ClientRepository>(); // whenever we see IMovieService as a constructor parameter, will replace that with MovieService Class; change here if we want to pass a new class as parameters
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IInteractionRepository, InteractionRepository>();

            services.AddDbContext<FinalDbContext>(option =>
               option.UseSqlServer(Configuration.GetConnectionString("FinalConnection")));

            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Final.API v1"));
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("clientSPAUrl")).AllowAnyHeader()
                    .AllowAnyMethod().AllowCredentials();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
