using BusApplication.DataAccess.Data;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusApplication.DataAccess.Repository
{
    public class BusStopRepository : Repository<BusStop>, IBusStopRepository
    {
        private readonly ApplicationDbContext _db;

        public BusStopRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetBusStopListDropDown()
        {
            return _db.BusStop
                .Where(bs => bs.IsActive == true)
                .Select(bs => new SelectListItem()
                {
                    Text = bs.Name,
                    Value = bs.Id.ToString()
                });
        }

        public void Update(BusStop busStop)
        {
            var objFromDb = _db.BusStop.FirstOrDefault(bs => bs.Id == busStop.Id);

            objFromDb.Name = busStop.Name;

            _db.SaveChanges();
        }

        public void IsActiveChange(int id)
        {
            bool status = _db.BusStop.FirstOrDefault(bs => bs.Id == id).IsActive;
            _db.BusStop.FirstOrDefault(bs => bs.Id == id).IsActive = !status;

            _db.SaveChanges();
        }

        
    }
}
