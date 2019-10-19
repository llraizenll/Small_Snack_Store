using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackStoreV3.Models
{
    public class GetProductsDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public Sorter SortBy { get; set; } = Sorter.snackName;
        public Order Order { get; set; } = Order.Asc;
    }
    public enum Sorter
    {
        snackName = 0,
        snackLikes = 1
    }

    public enum Order
    {
        Asc = 0,
        Desc = 1
    }
}
