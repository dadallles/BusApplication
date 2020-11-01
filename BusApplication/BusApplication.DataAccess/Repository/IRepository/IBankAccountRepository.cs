using BusApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.Repository.IRepository
{
    public interface IBankAccountRepository : IRepository<BankAccount>
    {
        void Update(BankAccount bankAccount);
    }
}
