using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using BusApplication.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusApplication.Areas.Staff.Controllers
{
    [Area("Staff")]
    [Authorize(Roles = StaticData.AdminRole)]
    public class BankAccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BankAccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            BankAccount bankAccount = _unitOfWork.BankAccount.GetFirstOrDefault();

            return View(bankAccount);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            BankAccount bankAccount = _unitOfWork.BankAccount.GetFirstOrDefault();

            return View(bankAccount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(BankAccount NewBankAccount)
        {
            _unitOfWork.BankAccount.Update(NewBankAccount);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

    }
}
