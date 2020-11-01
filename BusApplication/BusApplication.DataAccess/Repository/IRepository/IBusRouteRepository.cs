using BusApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.Repository.IRepository
{
    public interface IBusRouteRepository : IRepository<BusRoute>
    {
        void Update(BusRoute busRoute);
    }
}
