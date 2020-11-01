using BusApplication.DataAccess.Data;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusApplication.DataAccess.Repository
{
    public class HolidaysRepository : Repository<Holidays>, IHolidaysRepository
    {
        private readonly ApplicationDbContext _db;

        public HolidaysRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

        public void Update(Holidays holidays)
        {
            var ObjFromDb = _db.Holidays.FirstOrDefault(h => h.Id == holidays.Id);

            ObjFromDb.Name = holidays.Name;
            ObjFromDb.Day = holidays.Day;
            ObjFromDb.Month = holidays.Month;

            _db.SaveChanges();
        }
    }
}
