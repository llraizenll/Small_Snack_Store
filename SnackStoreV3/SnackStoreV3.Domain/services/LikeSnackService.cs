using SnackStoreV3.Domain.Interfaces;
using SnackStoreV3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SnackStoreV3.Domain.services
{
    public class LikeSnackService : ILikeSnack
    {
        ISnackRepository _snackRepository;
        public LikeSnackService(ISnackRepository snackRepository)
        {
            _snackRepository=snackRepository;
        }

        public async Task<string> LikeSnacks(SnackModel snack)
        {
            var likes = snack.snackLikes;
            if(likes >= 1)
            {
                snack.snackLikes--;
            }
            else
            {
                snack.snackLikes++;
            }

            await _snackRepository.UpdateSnack(snack);

            return await Task.Run(() => "success like");
        }

    }
}
