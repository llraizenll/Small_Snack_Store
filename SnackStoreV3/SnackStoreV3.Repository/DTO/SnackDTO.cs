using System;
using System.Collections.Generic;
using System.Text;

namespace SnackStoreV3.Repository.DTO
{
    public class SnackDTO
    {
    
        public int snackId { get; set; }

        public string nameSnack { get; set; }

        public double priceSnack { get; set; }
        public int likingSnack { get; set; }
    }
}
