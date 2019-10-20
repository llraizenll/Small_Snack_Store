using SnackStoreV3.Domain.Interfaces;
using SnackStoreV3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SnackStoreV3.Repository
{
  public class LogPriceRepository : MainStoreRepository<LogChangePricesModel>, ILogPriceRepository
    {
        StoreDbContext _context;
        public LogPriceRepository(StoreDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task ChangePrice(string nameSnack, double oldPrice, double newPrice)
        {

            LogChangePricesModel obj = new LogChangePricesModel();
            obj.ProductName = nameSnack;
            obj.OldPrice = oldPrice;
            obj.NewPrice = newPrice;
            Add(obj);
            await SaveAsync();


        }

        public async Task<IEnumerable<LogChangePricesModel>> GetLogChangePrices()
        {
            return await GetAllData().ToListAsync();
        }
    }
}
