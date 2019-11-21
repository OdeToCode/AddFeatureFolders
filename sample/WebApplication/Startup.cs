using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToCode.AddFeatureFolders;

namespace WebApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .AddFeatureFolders()
                    .AddAreaFeatureFolders();

            // "Features" is the default feature folder root. To override, pass along 
            // a new FeatureFolderOptions object with a different FeatureFolderName
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseEndpoints(e => {
                e.MapControllerRoute(name:"areaRoute", pattern:"{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
