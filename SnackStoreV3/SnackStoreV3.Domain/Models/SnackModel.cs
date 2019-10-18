using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SnackStoreV3.Domain.Models
{
    public class SnackModel
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


