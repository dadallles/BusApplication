using BusApplication.DataAccess.Data;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusApplication.DataAccess.Repository
{
    public class TicketPriceRepository : Repository<TicketPrice>, ITicketPriceRepository
    {
        private readonly ApplicationDbContext _db;

        public TicketPriceRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

        public float EntireRoute(int id)
        {
            float price = 0;
            var objFromDb = _db.TicketPrice.FirstOrDefault(tp => tp.Id == id);

            if (objFromDb != null)
            {
                price = objFromDb.PricePerEntireRoute;
            }

            return price;
        }

        public float PerSegment(int id)
        {
            float price = 0;
            var objFromDb = _db.TicketPrice.FirstOrDefault(tp => tp.Id == id);

            if (objFromDb != null)
            {
                price = objFromDb.PricePerSegment;
            }

            return price;
        }

        public void Update(TicketPrice ticketPrice)
        {
            var objFromDb = _db.TicketPrice.FirstOrDefault(tp => tp.Id == ticketPrice.Id);

            objFromDb.PricePerEntireRoute = ticketPrice.PricePerEntireRoute;
            objFromDb.PricePerSegment = ticketPrice.PricePerSegment;

            _db.SaveChanges();
        }
    }
}
