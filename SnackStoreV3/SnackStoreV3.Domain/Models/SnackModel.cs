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
        [MaxLength(20)]
        public string snackName { get; set; }
        public int snackLikes { get;  set; }
        public double snackPrice { get; set; }
        public int snackQuantity{ get;  set; }

    }


}


