using CSharpWars.Common.DependencyInjection;
using CSharpWars.Web.Api.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static System.Convert;
using static System.Environment;

namespace CSharpWars.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigurationHelper(c =>
            {
                c.ConnectionString = GetEnvironmentVariable("CONNECTION_STRING");
                c.ArenaSize = ToInt32(GetEnvironmentVariable("ARENA_SIZE"));
                c.ValidationHost = GetEnvironmentVariable("VALIDATION_HOST");
            });

            services.ConfigureWebApi();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseCors("AllowAll");
        }
    }
}