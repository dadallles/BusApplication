using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IWehicleRepository Wehicle { get; }
        IBusStopRepository BusStop { get; }
        ILineNameRepository LineName { get; }
        IBusStopListRepository BusStopList { get; }
        IHolidaysRepository Holidays { get; }
        IMessagesRepository Messages { get; }
        IOperatingDaysRepository OperatingDays { get; }
        ITicketPriceRepository TicketPrice { get; }
        IArrivalDeparturesRepository ArrivalsDepartures { get; }
        ITimetableRepository Timetable { get; }
        IBusRouteRepository BusRoute { get; }
        ITicketsRepository Tickets { get; }
        IPaymentRepository Payment { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IApplicationRoleRepository ApplicationRole { get; }
        IBankAccountRepository BankAccount { get; }

        void Save();

    }
}
