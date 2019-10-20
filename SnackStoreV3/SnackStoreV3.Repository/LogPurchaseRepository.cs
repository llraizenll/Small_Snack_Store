using Microsoft.EntityFrameworkCore;
using SnackStoreV3.Domain.Interfaces;
using SnackStoreV3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SnackStoreV3.Repository
{
    public class LogPurchaseRepository : MainStoreRepository<LogPurchaceModel>, ILogPurchaseRepository
    {
        StoreDbContext _dbContext;
        public LogPurchaseRepository(StoreDbContext dbContext) : base(dbContext)
        {
        _dbContext=dbContext;
    }
        public async Task<IEnumerable<LogPurchaceModel>> GetLogPurchase()
        {
            return await GetAllData().ToListAsync();
        }

        public async Task SavePurchase(string user, int quanity)
        {
            LogPurchaceModel obj = new LogPurchaceModel();
            obj.User = user;
            obj.Quantity = quanity;
            obj.PurchaseTime = DateTime.Now;
            Add(obj);
            await SaveAsync();
        }
    }
}
