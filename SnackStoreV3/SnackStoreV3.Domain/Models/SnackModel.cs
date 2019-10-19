using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnackStoreV3.Domain.Models
{
    public class SnackModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int snackId { get; set; }
        [Required]
        [MaxLength(50)]
        public string nameSnack { get; set; }

        public double priceSnack { get; set; }
        public int likingSnack { get; set; }
    }


}


