using Microsoft.EntityFrameworkCore;
using SnackStoreV3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnackStoreV3.Repository
{
   public  class StoreDbContext:DbContext
    {
      public  DbSet<SnackModel> SnackDbSet { get; set; }
        public DbSet<UserAccounts> UserAccountsDbSet { get; set; }
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

    }
}
