using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SnackStoreV3.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnackStoreV3.Repository
{
    public  class DataGenerator
    {



        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<StoreDbContext>>()))
            {
                if (context.Snack.Any())
                {
                    return;
                }
                context.Snack.AddRange(
                    new Snack
                    {
                        nameSnack = "Candy",
                        priceSnack = 10,
                        likingSnack = 20,
                    },
                         new Snack
                         {
                             nameSnack = "Lolipop",
                             priceSnack = 5,
                             likingSnack = 15,
                         },
                         new Snack
                         {
                             nameSnack = "Chocolate",
                             priceSnack = 2,
                             likingSnack = 40,
                         }
                    );
                context.SaveChanges();
            }
        }
            
        
    }
}
