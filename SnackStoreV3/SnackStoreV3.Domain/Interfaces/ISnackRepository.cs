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
      // Task<IEnumerable<SnackModel>> GetAllSnacks();
        //  SnackModel GetSnacksByName();

        Task<IEnumerable<SnackModel>> GetAllProducts();
        Task<IEnumerable<SnackModel>> GetAllProductsChunk(PaginationDTO pagination);

    }
}
