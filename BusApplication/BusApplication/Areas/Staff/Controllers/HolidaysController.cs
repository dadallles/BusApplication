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
    public class HolidaysController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HolidaysController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Repeated()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateInsert(int? id)
        {
            Holidays holidays = new Holidays();
            if (id == null)
            {
                return View(holidays);
            }
            holidays = _unitOfWork.Holidays.Get(id.GetValueOrDefault());
            if (holidays == null)
            {
                return NotFound();
            }
            return View(holidays);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateInsert(Holidays holidays)
        {
            if (ModelState.IsValid)
            {
                if (holidays.Id == 0)
                {
                    _unitOfWork.Holidays.Add(holidays);
                }
                else
                {
                    _unitOfWork.Holidays.Update(holidays);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(holidays);
            }
        }



        #region API

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Holidays.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Holidays.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Błąd." });
            }

            _unitOfWork.Holidays.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Usunięto." });
        }

        #endregion

    }
}
