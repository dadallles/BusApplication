using BusApplication.DataAccess.Data;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.Repository
{
    public class ArrivalDeparturesRepository : Repository<ArrivalsDepartures>, IArrivalDeparturesRepository
    {
        private readonly ApplicationDbContext _db;

        public ArrivalDeparturesRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

    }
}
