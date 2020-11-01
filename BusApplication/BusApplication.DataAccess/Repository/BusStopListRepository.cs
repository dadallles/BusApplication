using BusApplication.DataAccess.Data;
using BusApplication.DataAccess.DTOs;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusApplication.DataAccess.Repository
{
    public class BusStopListRepository : Repository<BusStopList>, IBusStopListRepository
    {
        private readonly ApplicationDbContext _db;

        public BusStopListRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

        
    }
}
