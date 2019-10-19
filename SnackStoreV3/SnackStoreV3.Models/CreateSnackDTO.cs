using System;
using System.Collections.Generic;
using System.Text;

namespace SnackStoreV3.Models
{
 public    class CreateSnackDTO
    {
        public string name { get; set; }
        public  int quantity { get; set; }
        public double price { get; set;  }
    }
}
