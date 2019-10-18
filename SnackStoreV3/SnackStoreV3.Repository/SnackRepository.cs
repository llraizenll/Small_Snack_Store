using System;
using System.Collections.Generic;
using System.Text;
using SnackStoreV3.Domain.Models;
using SnackStoreV3.Domain.Interfaces;
using System.Threading.Tasks;


namespace SnackStoreV3.Repository
{

    public class SnackRepository : MainStoreRepository<SnackModel>, ISnackRepository
    {
        StoreDbContext _context;
        public SnackRepository(StoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SnackModel>> GetAllSnacks()
        {

            return await GetAllData();  //return await GetAllSnacks();
        }
      //  SnackModel GetSnacksByName();

    }
}
