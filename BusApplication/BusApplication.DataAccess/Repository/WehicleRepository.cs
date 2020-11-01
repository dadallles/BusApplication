using BusApplication.DataAccess.Data;
using BusApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusApplication.DataAccess.Repository.IRepository
{
    public class WehicleRepository : Repository<Wehicle>, IWehicleRepository
    {
        private readonly ApplicationDbContext _db;

        public WehicleRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetWehicleListDropDown()
        {
            return _db.Wehicle
                .Where(w => w.IsActive == true)
                .Select(w => new SelectListItem()
                {
                    Text = w.Brand + ' ' + w.Model,
                    Value = w.Id.ToString()
                });
        }

        public void Update(Wehicle wehicle)
        {
            var objFromDb = _db.Wehicle.FirstOrDefault(w => w.Id == wehicle.Id);

            objFromDb.Brand = wehicle.Brand;
            objFromDb.Model = wehicle.Model;
            objFromDb.ImageUrl = wehicle.ImageUrl;
            objFromDb.NumberOfSeats = wehicle.NumberOfSeats;
            objFromDb.YearOfManufacture = wehicle.YearOfManufacture;
            objFromDb.Description = wehicle.Description;
            objFromDb.PremiumClass = wehicle.PremiumClass;
            objFromDb.Toilet = wehicle.Toilet;
            objFromDb.AirConditioning = wehicle.AirConditioning;
            objFromDb.IsActive = wehicle.IsActive;
            
            _db.SaveChanges();
        }

        public void IsActiveChange(int id)
        {
            bool status = _db.Wehicle.FirstOrDefault(w => w.Id == id).IsActive;
            _db.Wehicle.FirstOrDefault(w => w.Id == id).IsActive = !status;

            _db.SaveChanges();
        }
    }
}
