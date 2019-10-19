using Microsoft.EntityFrameworkCore;
using SnackStoreV3.Domain.Interfaces;
using SnackStoreV3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SnackStoreV3.Repository
{
 public class UserAccountRepository :MainStoreRepository<UserAccounts>, IUserAccountRepository
    {
        public UserAccountRepository(StoreDbContext context) : base(context)
        {

        }
        public async Task CreateAccount(UserAccounts accountEntity)
        {
            Add(accountEntity);
            await SaveAsync();
        }

        public async Task<UserAccounts> GetByUserName(string userName)
        {
            return await GetByParameter(p => p.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task<UserAccounts> GetByUserNameAndPassword(string userName, string password)
        {
            return await GetByParameter(p => p.UserName == userName && p.Password == password).FirstOrDefaultAsync();
        }

    }
}
