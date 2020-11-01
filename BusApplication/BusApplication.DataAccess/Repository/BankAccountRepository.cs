using BusApplication.DataAccess.Data;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusApplication.DataAccess.Repository
{
    public class BankAccountRepository : Repository<BankAccount>, IBankAccountRepository
    {
        private readonly ApplicationDbContext _db;

        public BankAccountRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

        public void Update(BankAccount bankAccount)
        {
            var objFromDb = _db.BankAccount.FirstOrDefault(ba => ba.Id == bankAccount.Id);

            objFromDb.CompanyName = bankAccount.CompanyName;
            objFromDb.CompanyAddress = bankAccount.CompanyAddress;
            objFromDb.AccountNumber = bankAccount.AccountNumber;

            _db.SaveChanges();
        }
    }
}
