using System;
using System.Collections.Generic;
using System.Text;

namespace SnackStoreV3.Models
{
    public class RegisterAccountDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

    }
    public enum Role
    {
        Admin = 0,
        User = 1
    }
}
