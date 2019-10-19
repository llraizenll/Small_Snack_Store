using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SnackStoreV3.Domain.Models;
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
                if (context.SnackDbSet.Any())
                {
                    return;
                }
                context.SnackDbSet.AddRange(
                    new SnackModel
                    {
                        snackName = "Candy",
                        snackLikes = 10,
                        likingSnack = 20,
                    },
                        new SnackModel
                        {
                            snackName = "Lolipop",
                            snackLikes = 5,
                            likingSnack = 15,
                        },
                        new SnackModel
                        {
                            snackName = "Chocolate",
                            snackLikes = 2,
                            likingSnack = 40,
                        }
                    );
                context.SaveChanges();
            }
        }
            
        
    }
}
