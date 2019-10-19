using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SnackStoreV3.Repository
{
    public class MainStoreRepository <TClass> where TClass : class
    {
        StoreDbContext _dbContext;
        protected readonly DbSet<TClass> _dataSet;
        public MainStoreRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _dataSet = dbContext.Set<TClass>();
        }


        public IQueryable<TClass> GetAllData()
        {
            return _dataSet;
        }

        public IQueryable<TClass> GetByParameter(Expression<Func<TClass, bool>> parameter)
        {
            return _dataSet.Where(parameter);
        }

        public void Add(TClass obj)
        {
            _dataSet.Add(obj);
          
        }
        public async Task SaveAsync()
        {
           await _dbContext.SaveChangesAsync();
        }

        public void RemoveSnack(TClass snack)
        {
            _dataSet.Remove(snack);
        }
      
        public void Update(TClass snack)
        {
            _dataSet.Update(snack);
        }
   



    }
}
