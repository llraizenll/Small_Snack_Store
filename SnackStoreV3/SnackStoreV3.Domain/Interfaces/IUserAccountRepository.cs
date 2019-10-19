using SnackStoreV3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SnackStoreV3.Domain.Interfaces
{
    public interface IUserAccountRepository
    {
        Task CreateAccount(UserAccounts accountEntity);
        Task<UserAccounts> GetByUserName(string userName);
        Task<UserAccounts> GetByUserNameAndPassword(string userName, string password);
    }
}
