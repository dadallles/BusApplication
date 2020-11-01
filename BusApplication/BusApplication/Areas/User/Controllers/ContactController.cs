using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusApplication.Areas.User.Controllers
{
    [Area("User")]
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Messages message = new Messages();

            return View(message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMessage(Messages message)
        {
            if (ModelState.IsValid)
            {
                message.Date = DateTime.Now;
                message.Status = false;
                _unitOfWork.Messages.Add(message);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(message);
            }
        }
    }
}
