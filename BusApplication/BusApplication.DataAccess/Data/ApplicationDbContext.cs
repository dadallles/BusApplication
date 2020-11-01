using System;
using System.Collections.Generic;
using System.Text;
using BusApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusApplication.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BusStop> BusStop { get; set; }
        public DbSet<BusStopList> BusStopList { get; set; }
        public DbSet<LineName> LineName { get; set; }
        public DbSet<Wehicle> Wehicle { get; set; }
        public DbSet<Timetable> Timetable { get; set; }
        public DbSet<ArrivalsDepartures> ArrivalsDepartures { get; set; }
        public DbSet<BusRoute> BusRoute { get; set; }
        public DbSet<Holidays> Holidays { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<OperatingDays> OperatingDays { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<TicketPrice> TicketPrice { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }


    }
}
