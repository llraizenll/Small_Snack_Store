using SnackStoreV3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SnackStoreV3.Domain.Interfaces
{
   public  interface IBuySnacks
    {

        Task<string> BuySnacks(SnackModel snack,int quantity);


    }
}
