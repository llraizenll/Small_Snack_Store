using SnackStoreV3.Domain.Interfaces;
using SnackStoreV3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SnackStoreV3.Domain.services
{
    public class BuySnackService : IBuySnacks
    {
        ISnackRepository _snackRepository;
        public BuySnackService(ISnackRepository snackRepository)
        {
            _snackRepository=snackRepository;
        }
      
        public async Task<string> BuySnacks(SnackModel snack, int quantity)
        {

            var actualStock = snack.snackQuantity;
            if (actualStock < quantity) {
                return await Task.Run(() => "The quantity exceeds the actual stock:" + actualStock);
            }
            var newStock = actualStock - quantity;
            snack.snackQuantity = newStock;
            await _snackRepository.UpdateSnack(snack);

            return await Task.Run(() => "Sucess purchase");
        }
    }
}
