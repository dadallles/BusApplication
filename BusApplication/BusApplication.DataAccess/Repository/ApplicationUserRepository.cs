using BusApplication.DataAccess.Data;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusApplication.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

        public void LockUser(ApplicationUser applicationUser)
        {
            var objFromDb = _db.ApplicationUser.FirstOrDefault(au => au.Id == applicationUser.Id);

            objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);

            _db.SaveChanges();
        }

        public void UnlockUser(ApplicationUser applicationUser)
        {
            var objFromDb = _db.ApplicationUser.FirstOrDefault(au => au.Id == applicationUser.Id);

            objFromDb.LockoutEnd = null;

            _db.SaveChanges();
        }

        public void Update(ApplicationUser applicationUser)
        {
            var objFromDb = _db.ApplicationUser.FirstOrDefault(au => au.Id == applicationUser.Id);

            objFromDb.UserName = applicationUser.UserName;
            objFromDb.Email = applicationUser.Email;
            objFromDb.PhoneNumber = applicationUser.PhoneNumber;
            objFromDb.FirstName = applicationUser.FirstName;
            objFromDb.LastName = applicationUser.LastName;
            objFromDb.City = applicationUser.City;
            objFromDb.PostalCode = applicationUser.PostalCode;
            objFromDb.Street = applicationUser.Street;
            objFromDb.HouseNumber = applicationUser.HouseNumber;
            objFromDb.FlatNumber = applicationUser.FlatNumber;

            _db.SaveChanges();
        }
    }
}
