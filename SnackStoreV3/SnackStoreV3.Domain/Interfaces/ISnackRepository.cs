using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SnackStoreV3.Domain.Models;

namespace SnackStoreV3.Domain.Interfaces
{
 public  interface ISnackRepository : IMainRepository<SnackModel>
    {
       Task<IEnumerable<SnackModel>> GetAllSnacks();
      //  SnackModel GetSnacksByName();

    }
}
