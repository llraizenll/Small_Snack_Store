using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SnackStoreV3.Domain.Models;

using SnackStoreV3.Models;

namespace SnackStoreV3.Domain.Interfaces
{
 public  interface ISnackRepository : IMainRepository<SnackModel>
    {
 

        Task<IEnumerable<SnackModel>> GetAllSnacks();
        Task<IEnumerable<SnackModel>> GetAllSnacksPagination(PaginationDTO pagination);

        Task<SnackModel> GetSnackByName(string name);

        Task CreateSnack(SnackModel product);
    }
}
