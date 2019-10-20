using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SnackStoreV3.Domain.Models
{
   public  class LogPurchaceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLogPurchase { get; set; }

        public string User { get; set; }
        public DateTime  PurchaseTime{ get; set; }
        public int Quantity { get; set; }
    }
}
