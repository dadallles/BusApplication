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
    public class TimetableRepository : Repository<Timetable>, ITimetableRepository
    {
        private readonly ApplicationDbContext _db;

        public TimetableRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

        public void IsActiveChange(int id)
        {
            bool status = _db.Timetable.FirstOrDefault(t => t.Id == id).IsActive;
            _db.Timetable.FirstOrDefault(t => t.Id == id).IsActive = !status;

            _db.SaveChanges();
        }

        public void Update(Timetable timetable)
        {
            var objFromDb = _db.Timetable.FirstOrDefault(t => t.Id == timetable.Id);

            objFromDb.TicketPriceId = timetable.TicketPriceId;
            objFromDb.OperatingDaysId = timetable.OperatingDaysId;

            _db.SaveChanges();
        }
    }
}
