using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SnackStoreV3.Repository.Models
{
   public class Snack
    {
        [Key]
        public Guid snackId { get; set; }
        [Required]
        [MaxLength(50)]
        public string nameSnack { get; set; }

        public double priceSnack { get; set; }
        public int likingSnack { get; set; }

    }
}
