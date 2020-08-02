using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SA.Models
{
    public class AplicationUser:IdentityUser
    {
        public string Name { get; set; }
        
        
    }
}
