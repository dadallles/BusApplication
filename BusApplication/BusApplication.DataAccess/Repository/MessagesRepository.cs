using BusApplication.DataAccess.Data;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusApplication.DataAccess.Repository
{
    public class MessagesRepository : Repository<Messages>, IMessagesRepository
    {
        private readonly ApplicationDbContext _db;

        public MessagesRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

        public void StatusAsRead(int id)
        {
            _db.Messages.FirstOrDefault(m => m.Id == id).Status = true;

            _db.SaveChanges();
        }
    }
}
