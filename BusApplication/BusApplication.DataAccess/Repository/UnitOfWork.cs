using BusApplication.DataAccess.Data;
using BusApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.Repository.IRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Wehicle = new WehicleRepository(_db);
            BusStop = new BusStopRepository(_db);
            LineName = new LineNameRepository(_db);
            BusStopList = new BusStopListRepository(_db);
            Holidays = new HolidaysRepository(_db);
            Messages = new MessagesRepository(_db);
            OperatingDays = new OperatingDaysRepository(_db);
            TicketPrice = new TicketPriceRepository(_db);
            ArrivalsDepartures = new ArrivalDeparturesRepository(_db);
            Timetable = new TimetableRepository(_db);
            BusRoute = new BusRouteRepository(_db);
            Tickets = new TicketsRepository(_db);
            Payment = new PaymentRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            ApplicationRole = new ApplicationRoleRepository(_db);
            BankAccount = new BankAccountRepository(_db);
        }

        public IWehicleRepository Wehicle { get; private set; }
        public IBusStopRepository BusStop { get; private set; }
        public ILineNameRepository LineName { get; private set; }
        public IBusStopListRepository BusStopList { get; private set; }
        public IHolidaysRepository Holidays { get; private set; }
        public IMessagesRepository Messages { get; private set; }
        public IOperatingDaysRepository OperatingDays { get; private set; }
        public ITicketPriceRepository TicketPrice { get; private set; }
        public IArrivalDeparturesRepository ArrivalsDepartures { get; private set; }
        public ITimetableRepository Timetable { get; private set; }
        public IBusRouteRepository BusRoute { get; private set; }
        public ITicketsRepository Tickets { get; private set; }
        public IPaymentRepository Payment { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IApplicationRoleRepository ApplicationRole { get; private set; }
        public IBankAccountRepository BankAccount { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
