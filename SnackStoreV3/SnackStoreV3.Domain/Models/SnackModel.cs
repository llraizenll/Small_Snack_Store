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
        public string snackName { get; set; }

        public double snackLikes { get; set; }
        public int likingSnack { get; set; }
    }


}


