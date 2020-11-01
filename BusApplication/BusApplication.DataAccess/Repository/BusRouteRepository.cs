using BusApplication.DataAccess.Data;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusApplication.DataAccess.Repository
{
    public class BusRouteRepository : Repository<BusRoute>, IBusRouteRepository
    {
        private readonly ApplicationDbContext _db;

        public BusRouteRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

        public void Update(BusRoute busRoute)
        {
            var objFromDb = _db.BusRoute.FirstOrDefault(br => br.Id == busRoute.Id);

            objFromDb.AvailableSeats = busRoute.AvailableSeats;

            _db.SaveChanges();
        }
    }
}
