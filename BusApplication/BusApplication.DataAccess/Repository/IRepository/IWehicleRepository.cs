using BusApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.Repository.IRepository
{
    public interface IWehicleRepository : IRepository<Wehicle>
    {
        IEnumerable<SelectListItem> GetWehicleListDropDown();
        void Update(Wehicle wehicle);
        void IsActiveChange(int id);
    }
}
