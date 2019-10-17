using Microsoft.EntityFrameworkCore;
using SnackStoreV3.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnackStoreV3.Repository
{
   public  class StoreDbContext:DbContext
    {
        DbSet<Snack> Snack { get; set; }
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }
    }
}
