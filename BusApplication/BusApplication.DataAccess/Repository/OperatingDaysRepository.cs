using BusApplication.DataAccess.Data;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusApplication.DataAccess.Repository
{
    public class OperatingDaysRepository : Repository<OperatingDays>, IOperatingDaysRepository
    {
        private readonly ApplicationDbContext _db;

        public OperatingDaysRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

        public void Update(OperatingDays operatingDays)
        {
            var objFromDb = _db.OperatingDays.FirstOrDefault(od => od.Id == operatingDays.Id);

            objFromDb.Monday = operatingDays.Monday;
            objFromDb.Tuesday = operatingDays.Tuesday;
            objFromDb.Wednesday = operatingDays.Wednesday;
            objFromDb.Thursday = operatingDays.Thursday;
            objFromDb.Friday = operatingDays.Friday;
            objFromDb.Saturday = operatingDays.Saturday;
            objFromDb.SundayAndHolidays = operatingDays.SundayAndHolidays;

            _db.SaveChanges();
        }
    }
}
