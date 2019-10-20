using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SnackStoreV3.Domain.Models;
using SnackStoreV3.Models;
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
                        snackPrice  = 10.5,                      
                        snackQuantity=10,
                        snackLikes=10

                    },
                        new SnackModel
                        {
                            snackName = "Lolipop",
                            snackPrice = 1.5,
                            snackQuantity = 4,
                            snackLikes = 4

                        },
                        new SnackModel
                        {
                            snackName = "PopTart",
                            snackPrice = 1.2,
                            snackQuantity = 20,
                            snackLikes = 4

                        },
                        new SnackModel
                        {
                            snackName = "Peanuts",
                            snackPrice = 1.2,
                            snackQuantity = 20,
                            snackLikes = 7

                        },
                        new SnackModel
                        {
                            snackName = "Cookies",
                            snackPrice = 4.2,
                            snackQuantity = 12,
                            snackLikes = 2

                        },
                        new SnackModel
                        {
                            snackName = "Gum",
                            snackPrice = 3.2,
                            snackQuantity = 20,
                            snackLikes = 80

                        },
                        new SnackModel
                        {
                            snackName = "Dorito",
                            snackPrice = 2.5,
                            snackQuantity = 2,
                            snackLikes = 24

                        },
                        new SnackModel
                        {
                            snackName = "Cheese",
                            snackPrice = 4.5,
                            snackQuantity = 14,
                            snackLikes = 40

                        },
                        new SnackModel
                        {
                            snackName = "Lays",
                            snackPrice =.85,
                            snackQuantity = 10,
                            snackLikes = 17

                        },
                        new SnackModel
                        {
                            snackName = "Pizza",
                            snackPrice = 2.5,
                            snackQuantity = 14,
                            snackLikes = 40

                        }
                    );

                context.UserAccountsDbSet.AddRange(
                     new UserAccounts
                     {
                         UserName = "admin",
                         Password = "admin01".ToSha256(),
                         Role = Role.Admin

                     },
                      new UserAccounts
                      {
                          UserName = "user",
                          Password = "user01".ToSha256(),
                          Role = Role.User

                      }

                 );

                //context.LogChangePrices.AddRange(
                //    new LogChangePricesModel { 
                //        IdLogPrice = 1,
                //        OldPrice = 50,
                //        NewPrice = 100,
                //        ProductName = "Prueba"
                    
                //    }
                //    );

                context.SaveChanges();



            }


      
        }


    }
}
