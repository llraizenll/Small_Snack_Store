using Microsoft.EntityFrameworkCore;
using SnackStoreV3.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackStoreV3.Repository
{
    public class StoreRepository <T> where T : class
    {
       // StoreDbContext _dbContext;
        protected readonly DbSet<T> _dbContext;
        public StoreRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext.Set<T>();
        }
       public IQueryable<T> GetAll()
        {
            return _dbContext;
        }


        public async Task<Snack>  GetProductByName(string name)
        {
            return _dbContext.Snack.Where(x => x.name == name);

        }
    }
}
