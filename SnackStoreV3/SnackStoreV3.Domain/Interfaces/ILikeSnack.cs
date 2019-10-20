using SnackStoreV3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SnackStoreV3.Domain.Interfaces
{
   public interface ILikeSnack
    {

        Task<string> LikeSnacks(SnackModel snack);

      

    }
}
