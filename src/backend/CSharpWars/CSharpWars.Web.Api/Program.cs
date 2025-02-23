using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CSharpWars.Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://*:5000")
                .UseKestrel()
                .UseStartup<Startup>();
    }
}