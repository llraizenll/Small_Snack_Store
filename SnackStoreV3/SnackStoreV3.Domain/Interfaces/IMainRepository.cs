
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SnackStoreV3.Domain.Interfaces
{
    public interface IMainRepository<TClass> where TClass:class
    {

        IQueryable<TClass> GetAllData();
        IQueryable<TClass> GetByParameter(Expression<Func<TClass, bool>> expression);
        void Add(TClass snack);
        Task SaveAsync();
        void RemoveSnack(TClass snack);
        void Update(TClass snack);
       

    }
}
