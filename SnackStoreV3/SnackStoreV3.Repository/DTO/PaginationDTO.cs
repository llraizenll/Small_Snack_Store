using System;
using System.Collections.Generic;
using System.Text;

namespace SnackStoreV3.Repository.DTO
{
  public  class PaginationDTO
    {

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string Order { get; set; }
    }
}
