using BusApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.Repository.IRepository
{
    public interface ITimetableRepository : IRepository<Timetable>
    {
        void Update(Timetable timetable);
        void IsActiveChange(int id);
    }
}
