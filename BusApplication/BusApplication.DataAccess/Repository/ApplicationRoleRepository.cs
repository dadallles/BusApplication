using BusApplication.DataAccess.Data;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.Repository
{
    public class ApplicationRoleRepository : Repository<ApplicationRole>, IApplicationRoleRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationRoleRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }
    }
}
