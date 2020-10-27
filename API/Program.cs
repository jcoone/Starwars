using System;
using System.Threading.Tasks;
using API.Data;
using API.Entitys;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           var host = CreateHostBuilder(args).Build();
           using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            // We cannot debug this at Run time so the exception will catch errors at our seed
            try{
                    var context = services.GetRequiredService<StarwarsContext>();
                    // Create the data base if none exsite and add migration and seeding;
                    // await context.Database.MigrateAsync();
                    // @todo fix this seeding 
                    // await Seed.SeedDataBase(context);
            } catch(Exception ex){
            Console.WriteLine("Error in seed ", ex);
            var logger = services.GetRequiredService<Logger<Program>>();
            logger.LogError(ex, "Error in migration  or seed");
            }

            //now run our soulution.
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
