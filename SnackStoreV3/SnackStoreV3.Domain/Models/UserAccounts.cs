using SnackStoreV3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SnackStoreV3.Domain.Models
{
   public  class UserAccounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; protected set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }


}
