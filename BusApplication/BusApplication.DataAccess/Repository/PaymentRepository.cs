using BusApplication.DataAccess.Data;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusApplication.DataAccess.Repository
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        private readonly ApplicationDbContext _db;

        public PaymentRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

        public void Update(Payment payment)
        {
            var objFromDb = _db.Payment.FirstOrDefault(p => p.Id == payment.Id);

            objFromDb.Status = payment.Status;
            objFromDb.ConfirmationDate = payment.ConfirmationDate;
            objFromDb.CanceledDate = payment.CanceledDate;
            objFromDb.ChangedBy = payment.ChangedBy;

            _db.SaveChanges();
        }
    }
}
