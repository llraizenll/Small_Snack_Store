using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SnackStoreV3.Domain.Models
{
    public class LogChangePricesModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLogPrice { get; set; }

        public string ProductName { get; set; }

        public double OldPrice { get; set; }
        public double NewPrice { get; set; }


    }
}
