using System;
using System.Collections.Generic;
using System.Text;
using SnackStoreV3.Domain.Models;
using SnackStoreV3.Domain.Interfaces;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SnackStoreV3.Models;

namespace SnackStoreV3.Repository
{

    public class SnackRepository : MainStoreRepository<SnackModel>, ISnackRepository
    {
        StoreDbContext _context;
        LogPriceRepository logChangePrice;
        public SnackRepository(StoreDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<SnackModel>> GetAllSnacks()
        {
            return await GetAllData().OrderBy(a => a.snackName).ToListAsync();
        }

        public async Task<IEnumerable<SnackModel>> GetAllSnacksPagination(PaginationDTO pagination)
        {
            IQueryable<SnackModel> query;
            var property = TypeDescriptor.GetProperties(typeof(SnackModel)).Find(pagination.SortBy, true);
            if (pagination.Order == "Asc")
                query = GetAllData().OrderBy(a => property.GetValue(a));         
            else
                query = GetAllData().OrderByDescending(a => property.GetValue(a));
            return await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();
        }

        public async Task<SnackModel> GetSnackByName(string name)
        {
            return await GetAllData().Where(x => x.snackName == name).FirstOrDefaultAsync();
        }
        public async Task CreateSnack(SnackModel snack)
        {
           
            Add(snack);
            await SaveAsync();
           
        }
        public async Task<SnackModel> GetSnacksById(int id)
        {
            return await GetAllData().Where(x => x.snackId == id).FirstOrDefaultAsync();
        }
        public async Task DeleteSnack(SnackModel snack)
        {
            RemoveSnack(snack);
            await SaveAsync();
        }

        public async Task UpdatePriceSnack(SnackModel snack, double newPrice)
        {
            var oldPrice = snack.snackPrice;
            var name = snack.snackName;
            snack.snackPrice = newPrice;
                Update(snack);
            
            await SaveAsync();
            //await logChangePrice.ChangePrice(name, oldPrice, newPrice);

        }

    }
}
