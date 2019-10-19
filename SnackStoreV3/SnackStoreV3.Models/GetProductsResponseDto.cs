using System;
using System.Collections.Generic;
using System.Text;

namespace SnackStoreV3.Models
{
  public  class GetProductsResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public int Likes { get; set; }
    }
}
