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
       // StoreDbContext _dbContext;
        protected readonly DbSet<TClass> _dataSet;
        public MainStoreRepository(StoreDbContext dbContext)
        {
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
        //void Create(TClass entity);
        //void Update(TClass entity);
        //void Delete(TClass entity);




    }
}
