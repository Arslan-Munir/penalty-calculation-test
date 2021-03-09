using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PenaltyCalculation.API.Configurations;
using PenaltyCalculation.API.Infrastructure.Persistence;
using PenaltyCalculation.API.Infrastructure.Persistence.Interfaces;
using PenaltyCalculation.API.Services;
using PenaltyCalculation.API.Services.Interfaces;

namespace PenaltyCalculation.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x =>
                x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IPenaltyService, PenaltyService>();
            services.AddTransient<IHolidayRepository, HolidayRepository>();
            
            services.Configure<PenaltyConfigurations>(Configuration.GetSection(nameof(PenaltyConfigurations)));

            services.AddCors();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}