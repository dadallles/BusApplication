using BusApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.Repository.IRepository
{
    public interface ILineNameRepository : IRepository<LineName>
    {
        IEnumerable<SelectListItem> GetLineNameListDropDown();
        void Update(LineName lineName);
        void IsActiveChange(int id);
        LineName GetLast();
    }
}
