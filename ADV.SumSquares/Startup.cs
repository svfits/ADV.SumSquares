using System;
using ADV.Model.EF;
using ADV.SumSquares.BL;
using ADV.SumSquares.BL.Interfaces;
using ADV.SumSquares.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ADV.SumSquares
{
    public class Startup
    {
        private readonly Random _random;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _random = new Random();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ParametersOptions>(Configuration.GetSection(ParametersOptions.Parameters));

            var confParams = Configuration.GetSection(ParametersOptions.Parameters).Get<ParametersOptions>();
            services.AddSingleton<I�achingCalcProxy>(new �achingCalcProxy(_random, confParams.MinPause, confParams.MaxPause));

            services.AddDbContext<DataContextApp>(options => options.UseInMemoryDatabase("DBName"));

            //services.AddTransient<IBalance>();
            //services.AddTransient<IDeliveryGoods>();

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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Number}/{id?}");
            });
        }
    }
}
