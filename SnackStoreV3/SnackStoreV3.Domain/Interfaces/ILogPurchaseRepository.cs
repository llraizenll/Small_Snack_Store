using SnackStoreV3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SnackStoreV3.Domain.Interfaces
{
  public interface ILogPurchaseRepository
    {

        Task SavePurchase(string user, int quanity);

        Task<IEnumerable<LogPurchaceModel>> GetLogPurchase();
    }
}
