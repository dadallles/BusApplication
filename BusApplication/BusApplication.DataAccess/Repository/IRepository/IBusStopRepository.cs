using BusApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.Repository.IRepository
{
    public interface IBusStopRepository : IRepository<BusStop>
    {
        IEnumerable<SelectListItem> GetBusStopListDropDown();
        void Update(BusStop busStop);
        void IsActiveChange(int id);
    }
}
