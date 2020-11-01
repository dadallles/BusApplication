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
    public class LineNameRepository : Repository<LineName>, ILineNameRepository
    {
        private readonly ApplicationDbContext _db;

        public LineNameRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetLineNameListDropDown()
        {
             return _db.LineName
                 .Where(ln => ln.IsActive == true)
                 .Select(ln => new SelectListItem()
                 {
                     Text = ln.Name,
                     Value = ln.Id.ToString()
                 });
        }

        public void Update(LineName lineName)
        {
            var objFromDb = _db.LineName.FirstOrDefault(ln => ln.Id == lineName.Id);

            objFromDb.Name = lineName.Name;

            _db.SaveChanges();
        }

        public void IsActiveChange(int id)
        {
            bool status = _db.LineName.FirstOrDefault(ln => ln.Id == id).IsActive;
            _db.LineName.FirstOrDefault(ln => ln.Id == id).IsActive = !status;

            _db.SaveChanges();
        }

        public LineName GetLast()
        {
            int maxId = _db.LineName.Max(ln => ln.Id);
            return _db.LineName.FirstOrDefault(ln => ln.Id == maxId);
        }
    }
}
