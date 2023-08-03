using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ServiceLifeTime.Models;

namespace ServiceLifeTime
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IUtilitySingleton,UtilitySingleton>(); //programın başında oluşturulan nesne tüm isteklerde kullanılıyor. program tekrardan run edilene kadar hep aynı nesne üzerinden istekler alınıyor
            services.AddTransient<IUtilityTransient,UtilityTransient>(); //her istekte yeni nesne oluşturuluyor.
            services.AddScoped<IUtilityScoped, UtilityScoped>(); //her çağrıldığında her kullanıcı için yeni nesne oluşuyor. fakat aynı http request içinde aynı nesne kullanılıyor.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes => 
            {
                routes.MapRoute(
                    name:"default",
                    template:"{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
