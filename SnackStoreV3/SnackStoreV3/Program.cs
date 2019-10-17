﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SnackStoreV3.Repository;

namespace SnackStoreV3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            var host = CreateWebHostBuilder(args);
            using (var serviceScope = host..CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<StoreDbContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
              
                context.SaveChanges();
            }
            host.Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
