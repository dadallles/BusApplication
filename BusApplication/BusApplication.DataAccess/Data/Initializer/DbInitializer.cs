using BusApplication.Models;
using BusApplication.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusApplication.DataAccess.Data.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
            }

            if (_db.Roles.Any(r => r.Name == StaticData.AdminRole)) return;

            _roleManager.CreateAsync(new IdentityRole(StaticData.AdminRole)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(StaticData.EmployeeRole)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(StaticData.UserRole)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "Admin",
                Email = "dadales@o2.pl",
                EmailConfirmed = true,
                FirstName = "Dawid",
                LastName = "Dawidowicz",
                City = "Częstochowa",
                PostalCode = "44-777",
                Street = "Pierwsza",
                HouseNumber = 12,
                FlatNumber = 2,
                PhoneNumber = "123123123"

            }, "Password123!@#").GetAwaiter().GetResult();

            ApplicationUser user = _db.ApplicationUser.Where(u => u.Email == "dadales@o2.pl").FirstOrDefault();
            _userManager.AddToRoleAsync(user, StaticData.AdminRole).GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(user, StaticData.EmployeeRole).GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(user, StaticData.UserRole).GetAwaiter().GetResult();
            _db.SaveChanges();

            _db.BusStop.Add(new BusStop()
            {
                Name = "Brak",
                IsActive = true
            });
            _db.SaveChanges();

            _db.BankAccount.Add(new BankAccount()
            {
                CompanyName = "Bus Application",
                CompanyAddress = "ul. Busów, 22-434 Częstochowa",
                AccountNumber = "12 2312 5645 8978 4758 2698 1397"
            });
            _db.SaveChanges();

            #region holidays
            Holidays hol1 = new Holidays()
            {
                Name = "Nowy Rok",
                Day = 1,
                Month = 1
            };
            _db.Holidays.Add(hol1);
            _db.SaveChanges();

            Holidays hol2 = new Holidays()
            {
                Name = "Święto Trzech Króli",
                Day = 6,
                Month = 1
            };
            _db.Holidays.Add(hol2);
            _db.SaveChanges();

            Holidays hol3 = new Holidays()
            {
                Name = "1 Maja",
                Day = 1,
                Month = 5
            };
            _db.Holidays.Add(hol3);
            _db.SaveChanges();

            Holidays hol4 = new Holidays()
            {
                Name = "3 Maja",
                Day = 3,
                Month = 5
            };
            _db.Holidays.Add(hol4);
            _db.SaveChanges();

            Holidays hol5 = new Holidays()
            {
                Name = "Zielone świątki",
                Day = 23,
                Month = 5
            };
            _db.Holidays.Add(hol5);
            _db.SaveChanges();

            Holidays hol6 = new Holidays()
            {
                Name = "Wniebowzięcie Najświętszej Maryi Panny",
                Day = 15,
                Month = 8
            };
            _db.Holidays.Add(hol6);
            _db.SaveChanges();

            Holidays hol7 = new Holidays()
            {
                Name = "Wszystkich świętych",
                Day = 1,
                Month = 11
            };
            _db.Holidays.Add(hol7);
            _db.SaveChanges();

            Holidays hol8 = new Holidays()
            {
                Name = "Święto Niepodległości",
                Day = 11,
                Month = 11
            };
            _db.Holidays.Add(hol8);
            _db.SaveChanges();

            Holidays hol9 = new Holidays()
            {
                Name = "1 dzień Bożego Narodzenia",
                Day = 25,
                Month = 12
            };
            _db.Holidays.Add(hol9);
            _db.SaveChanges();

            Holidays hol10 = new Holidays()
            {
                Name = "2 dzień Bożego Narodzenia",
                Day = 26,
                Month = 12
            };
            _db.Holidays.Add(hol10);
            _db.SaveChanges();
            #endregion

        }
    }
}