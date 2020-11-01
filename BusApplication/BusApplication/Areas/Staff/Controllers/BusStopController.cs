using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using BusApplication.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BusApplication.Areas.Staff.Controllers
{
    [Area("Staff")]
    [Authorize(Roles = StaticData.EmployeeAndAdminRoleString)]
    public class BusStopController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BusStopController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RepeatedName()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateInsert(int? id)
        {
            BusStop busStop = new BusStop();
            if (id == null)
            {
                return View(busStop);
            }
            busStop = _unitOfWork.BusStop.Get(id.GetValueOrDefault());
            if (busStop == null)
            {
                return NotFound();
            }
            return View(busStop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateInsert(BusStop busStop)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork.BusStop.GetFirstOrDefault(bs => bs.Name == busStop.Name) != null)
                {
                    return RedirectToAction(nameof(RepeatedName));
                }
                else if (busStop.Id == 0)
                {
                    busStop.IsActive = true;
                    _unitOfWork.BusStop.Add(busStop);
                }
                else
                {
                    _unitOfWork.BusStop.Update(busStop);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(busStop);
            }
        }



        #region API

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.BusStop.GetAll() });
        }

        [HttpPut]
        public IActionResult ChangeStatus(int id)
        {
            var objFromDb = _unitOfWork.BusStop.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Nie znaleziono przystanku." });
            }

            _unitOfWork.BusStop.IsActiveChange(id);

            return Json(new { success = true, message = "Zmieniono status." });
        }

        #endregion
    }
}
