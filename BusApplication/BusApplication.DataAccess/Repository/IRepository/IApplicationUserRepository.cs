using BusApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.Repository.IRepository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        void LockUser(ApplicationUser applicationUser);
        void UnlockUser(ApplicationUser applicationUser);
        void Update(ApplicationUser applicationUser);
    }
}
