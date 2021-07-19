using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CsiNumberSorter.DataAccess.Implementation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsiNumberSorter.Service.RequestHandlers;
using CsiNumberSorter.Service.RequestHandlers.Implementation;
using CsiNumberSorter.Domain;
using CsiNumberSorter.DataAccess;
using CsiNumberSorter.Service.Mappers;
using CsiNumberSorter.Website.Mappers;



namespace CsiNumberSorter
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
            
            services.AddDbContext<NumbersUnitOfWork>(options => options.UseSqlServer(Configuration.GetConnectionString("NumbersConnection")));
            services.AddScoped<DbContext, NumbersUnitOfWork>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddControllersWithViews();

            //Repos
            services.AddScoped<IAsyncAddRepository<SortedNumbers>, AsyncAddRepository<SortedNumbers>>();
            services.AddScoped<IAsyncListRepository<SortedNumbers>, AsyncListRepository<SortedNumbers>>();

            //Handlers
            services.AddScoped<IAsyncRequestHandler<GetAllSortsRequest, List<SortedNumbers>>, GetAllSortsRequestHandler>();
            services.AddScoped<IAsyncRequestHandler<SaveAndSortRequest, SaveAndSortResult>, SortAndSaveNumbersRequestHandler>();

            //Mappers
            services.AddScoped<ISaveAndSortRequestMapper, SaveAndSortRequestMapper>();
            services.AddScoped<ISortedNumbersViewModelMapper, SortedNumbersViewModelMapper>();
            

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

            app.Use(async (ctx, next) =>
            {
                ctx.Response.Headers.Add("Content-Security-Policy-Report-Only",
                                         "default-src 'self' 'unsafe-eval'; " +
                                         "base-uri 'self'; " );
                                         
                await next();
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
