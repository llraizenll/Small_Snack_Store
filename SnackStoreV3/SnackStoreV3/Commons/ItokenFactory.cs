using SnackStoreV3.Domain.Models;
using SnackStoreV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackStoreV3.Commons
{
    public interface ItokenFactory
    {

        string UserIdClaim { get; }
        string RoleClaim { get; }
        string GenerateToken(string userId, Role role);
        string GetUser(); 
        string GetRole();
        
    }
}
