
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SnackStoreV3.Domain.Interfaces
{
    public interface IMainRepository<TClass> where TClass:class
    {
      
        
        //void Create(TClass entity);
        //void Update(TClass entity);
        //void Delete(TClass entity);

        IQueryable<TClass> GetAllData();
      //  IQueryable<TClass> GetByParameter(Expression<Func<TClass, bool>> parameter);
    }
}
