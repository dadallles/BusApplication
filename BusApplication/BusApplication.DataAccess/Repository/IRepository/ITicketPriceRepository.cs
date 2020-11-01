using BusApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.Repository.IRepository
{
    public interface ITicketPriceRepository : IRepository<TicketPrice>
    {
        void Update(TicketPrice ticketPrice);
        float EntireRoute(int id);
        float PerSegment(int id);
    }
}
