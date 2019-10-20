using SnackStoreV3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SnackStoreV3.Domain.Interfaces
{
    public interface ILogPriceRepository
    {
        Task ChangePrice(string nameSnack, double oldPrice, double newPrice);

        Task<IEnumerable<LogChangePricesModel>> GetLogChangePrices();


    }
}
