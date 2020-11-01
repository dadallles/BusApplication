using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.Models.ViewModels
{
    public class UsersListVM
    {
        public string Id { get; set; }
        public string Nick { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Roles { get; set; }
        public string IsActive { get; set; }
    }
}
