using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.Models.ViewModels
{
    public class UserDetailsVM
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IList<IdentityRole> Roles { get; set; }
    }
}
