using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SnackStoreV3.Repository;

namespace SnackStoreV3
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // CreateWebHostBuilder(args).Build().Run();
            var hostBuilder = CreateHostBuilder(args).Build();

            using (var serviceScope = hostBuilder.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var context=services.GetRequiredService<StoreDbContext>();

                DataGenerator.Initialize(services);

            }
            hostBuilder.Run();

        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
