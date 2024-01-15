using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Entities.Models.Identities
{
    public class AppUser:IdentityUser<int>
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<Order> Orders { get; set; }

        
        
    }
}