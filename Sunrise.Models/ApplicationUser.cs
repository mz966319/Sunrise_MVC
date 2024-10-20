using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? userType { get; set; }
        public string? FullName { get; set; }
    }
}
