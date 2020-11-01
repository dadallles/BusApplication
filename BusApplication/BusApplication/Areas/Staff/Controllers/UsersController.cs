using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using BusApplication.Models.ViewModels;
using BusApplication.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusApplication.Areas.Staff.Controllers
{
    [Area("Staff")]
    [Authorize(Roles = StaticData.AdminRole)]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;

        public UsersController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(string Id)
        {
            ApplicationUser applicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == Id);
            IList<IdentityRole> applicationRoles = new List<IdentityRole>();

            IdentityUser identityUser = await _userManager.FindByIdAsync(userId: applicationUser.Id);
            IdentityRole roleAdmin = await _roleManager.FindByNameAsync(StaticData.AdminRole);
            IdentityRole roleEmployee = await _roleManager.FindByNameAsync(StaticData.EmployeeRole);
            IdentityRole roleUser = await _roleManager.FindByNameAsync(StaticData.UserRole);

            bool IsAdminRole = await _userManager.IsInRoleAsync(identityUser, roleAdmin.Name) ? true : false;
            bool IsEmployeeRole = await _userManager.IsInRoleAsync(identityUser, roleEmployee.Name) ? true : false;
            bool IsUserRole = await _userManager.IsInRoleAsync(identityUser, roleUser.Name) ? true : false;

            if (IsAdminRole)
            {
                applicationRoles.Add(roleAdmin);
            }
            else
            {
                applicationRoles.Add(null);
            }

            if (IsEmployeeRole)
            {
                applicationRoles.Add(roleEmployee);
            }
            else
            {
                applicationRoles.Add(null);
            }

            if (IsUserRole)
            {
                applicationRoles.Add(roleUser);
            }
            else
            {
                applicationRoles.Add(null);
            }

            UserDetailsVM userDetailsVM = new UserDetailsVM()
            {
                ApplicationUser = applicationUser,
                Roles = applicationRoles
            };

            return View(userDetailsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdminRole(string Id)
        {
            IdentityUser identityUser = await _userManager.FindByIdAsync(userId: Id);

            await _userManager.AddToRoleAsync(identityUser, StaticData.AdminRole);

            return RedirectToAction(nameof(Details), new { Id = Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DropAdminRole(string Id)
        {
            IdentityUser identityUser = await _userManager.FindByIdAsync(userId: Id);

            await _userManager.RemoveFromRoleAsync(identityUser, StaticData.AdminRole);

            return RedirectToAction(nameof(Details), new { Id = Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployeeRole(string Id)
        {
            IdentityUser identityUser = await _userManager.FindByIdAsync(userId: Id);

            await _userManager.AddToRoleAsync(identityUser, StaticData.EmployeeRole);

            return RedirectToAction(nameof(Details), new { Id = Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DropEmployeeRole(string Id)
        {
            IdentityUser identityUser = await _userManager.FindByIdAsync(userId: Id);

            await _userManager.RemoveFromRoleAsync(identityUser, StaticData.EmployeeRole);

            return RedirectToAction(nameof(Details), new { Id = Id });
        }




        #region API

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ApplicationUser> applicationUsers = _unitOfWork.ApplicationUser.GetAll(au => au.UserName != "Admin");
            IList<UsersListVM> usersListVMs = new List<UsersListVM>();

            foreach (var item in applicationUsers)
            {
                string RoleList = "";
                IdentityUser identityUser = await _userManager.FindByIdAsync(userId: item.Id);
                IdentityRole roleAdmin = await _roleManager.FindByNameAsync(StaticData.AdminRole);
                IdentityRole roleEmployee = await _roleManager.FindByNameAsync(StaticData.EmployeeRole);
                IdentityRole roleUser = await _roleManager.FindByNameAsync(StaticData.UserRole);

                RoleList += await _userManager.IsInRoleAsync(identityUser, roleAdmin.Name) ? "Admin, " : "";
                RoleList += await _userManager.IsInRoleAsync(identityUser, roleEmployee.Name) ? " Pracownik, " : "";
                RoleList += await _userManager.IsInRoleAsync(identityUser, roleUser.Name) ? " Użytkownik, " : "";
                RoleList = RoleList.Remove(RoleList.Length - 2);

                UsersListVM usersListVM = new UsersListVM()
                {
                    Id = item.Id,
                    Nick = item.UserName,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Roles = RoleList,
                    IsActive = item.LockoutEnd == null ? "Tak" : "Nie"
                };

                usersListVMs.Add(usersListVM);
            }

            return Json(new { data = usersListVMs });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdmin()
        {
            IEnumerable<ApplicationUser> applicationUsers = _unitOfWork.ApplicationUser.GetAll(au => au.UserName != "Admin");
            IList<UsersListVM> usersListVMs = new List<UsersListVM>();

            foreach (var item in applicationUsers)
            {
                string RoleList = "";
                IdentityUser identityUser = await _userManager.FindByIdAsync(userId: item.Id);
                IdentityRole roleAdmin = await _roleManager.FindByNameAsync(StaticData.AdminRole);
                IdentityRole roleEmployee = await _roleManager.FindByNameAsync(StaticData.EmployeeRole);
                IdentityRole roleUser = await _roleManager.FindByNameAsync(StaticData.UserRole);

                RoleList += await _userManager.IsInRoleAsync(identityUser, roleAdmin.Name) ? "Admin, " : "";
                RoleList += await _userManager.IsInRoleAsync(identityUser, roleEmployee.Name) ? " Pracownik, " : "";
                RoleList += await _userManager.IsInRoleAsync(identityUser, roleUser.Name) ? " Użytkownik, " : "";
                RoleList = RoleList.Remove(RoleList.Length - 2);

                bool IsInRole = await _userManager.IsInRoleAsync(identityUser, roleAdmin.Name) ? true : false;
                if (IsInRole == false)
                {
                    continue;
                }

                UsersListVM usersListVM = new UsersListVM()
                {
                    Id = item.Id,
                    Nick = item.UserName,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Roles = RoleList,
                    IsActive = item.LockoutEnd == null ? "Tak" : "Nie"
                };

                usersListVMs.Add(usersListVM);
            }

            return Json(new { data = usersListVMs });

        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            IEnumerable<ApplicationUser> applicationUsers = _unitOfWork.ApplicationUser.GetAll(au => au.UserName != "Admin");
            IList<UsersListVM> usersListVMs = new List<UsersListVM>();

            foreach (var item in applicationUsers)
            {
                string RoleList = "";
                IdentityUser identityUser = await _userManager.FindByIdAsync(userId: item.Id);
                IdentityRole roleAdmin = await _roleManager.FindByNameAsync(StaticData.AdminRole);
                IdentityRole roleEmployee = await _roleManager.FindByNameAsync(StaticData.EmployeeRole);
                IdentityRole roleUser = await _roleManager.FindByNameAsync(StaticData.UserRole);

                RoleList += await _userManager.IsInRoleAsync(identityUser, roleAdmin.Name) ? "Admin, " : "";
                RoleList += await _userManager.IsInRoleAsync(identityUser, roleEmployee.Name) ? " Pracownik, " : "";
                RoleList += await _userManager.IsInRoleAsync(identityUser, roleUser.Name) ? " Użytkownik, " : "";
                RoleList = RoleList.Remove(RoleList.Length - 2);

                bool IsInRole = await _userManager.IsInRoleAsync(identityUser, roleEmployee.Name) ? true : false;
                if (IsInRole == false)
                {
                    continue;
                }

                UsersListVM usersListVM = new UsersListVM()
                {
                    Id = item.Id,
                    Nick = item.UserName,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Roles = RoleList,
                    IsActive = item.LockoutEnd == null ? "Tak" : "Nie"
                };

                usersListVMs.Add(usersListVM);
            }

            return Json(new { data = usersListVMs });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            IEnumerable<ApplicationUser> applicationUsers = _unitOfWork.ApplicationUser.GetAll(au => au.UserName != "Admin");
            IList<UsersListVM> usersListVMs = new List<UsersListVM>();

            foreach (var item in applicationUsers)
            {
                string RoleList = "";
                IdentityUser identityUser = await _userManager.FindByIdAsync(userId: item.Id);
                IdentityRole roleAdmin = await _roleManager.FindByNameAsync(StaticData.AdminRole);
                IdentityRole roleEmployee = await _roleManager.FindByNameAsync(StaticData.EmployeeRole);
                IdentityRole roleUser = await _roleManager.FindByNameAsync(StaticData.UserRole);

                RoleList += await _userManager.IsInRoleAsync(identityUser, roleAdmin.Name) ? "Admin, " : "";
                RoleList += await _userManager.IsInRoleAsync(identityUser, roleEmployee.Name) ? " Pracownik, " : "";
                RoleList += await _userManager.IsInRoleAsync(identityUser, roleUser.Name) ? " Użytkownik, " : "";
                RoleList = RoleList.Remove(RoleList.Length - 2);

                bool IsInRole = await _userManager.IsInRoleAsync(identityUser, roleUser.Name) ? true : false;
                if (IsInRole == false)
                {
                    continue;
                }

                UsersListVM usersListVM = new UsersListVM()
                {
                    Id = item.Id,
                    Nick = item.UserName,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Roles = RoleList,
                    IsActive = item.LockoutEnd == null ? "Tak" : "Nie"
                };

                usersListVMs.Add(usersListVM);
            }

            return Json(new { data = usersListVMs });
        }

        [HttpGet]
        public async Task<IActionResult> ChangeStatus(string id)
        {
            var objFromDb = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (objFromDb.LockoutEnd != null)
            {
                _unitOfWork.ApplicationUser.UnlockUser(objFromDb);
                await _emailSender.SendEmailAsync(objFromDb.Email, "Konto odblokowane", $"<p><b>Witaj {objFromDb.FirstName}!</b></p><p>Twoje konto zostało odblokowane.</p><br /><p>BusApplication Team</p>");

                return RedirectToAction(nameof(Index));
            }
            else
            {
                _unitOfWork.ApplicationUser.LockUser(objFromDb);
                await _emailSender.SendEmailAsync(objFromDb.Email, "Konto zablokowane", $"<p><b>Witaj {objFromDb.FirstName}!</b></p><p>Twoje konto zostało zablokowane.</p><p>Skontaktuj się z administrascją.</p><br /><p>BusApplication Team</p>");


                return RedirectToAction(nameof(Index));
            }
            
        }


        #endregion

    }
}
