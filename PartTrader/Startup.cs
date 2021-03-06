using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PartTrader.API.Helpers.AutoMapper;
using PartTrader.API.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartTrader
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton(provider =>

               new MapperConfiguration(config =>
               {

                   config.AddProfile(new AutoMapperProfiles());
               }).CreateMapper()

           );
            services.AddSingleton(c => new DataAccess());

            //adding CORS!
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(builder =>
            builder.AllowAnyOrigin()
             .AllowAnyMethod()
                 .AllowAnyHeader()
           );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
