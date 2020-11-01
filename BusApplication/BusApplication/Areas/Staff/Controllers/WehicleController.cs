using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using BusApplication.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BusApplication.Areas.Staff.Controllers
{
    [Area("Staff")]
    [Authorize(Roles = StaticData.EmployeeAndAdminRoleString)]
    public class WehicleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public WehicleController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateInsert(int? id)
        {
            Wehicle wehicle = new Wehicle();
            if (id == null)
            {
                return View(wehicle);
            }
            wehicle = _unitOfWork.Wehicle.Get(id.GetValueOrDefault());
            if (wehicle == null)
            {
                return NotFound();
            }
            return View(wehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateInsert(Wehicle wehicle)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (wehicle.Id == 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\wehicles");
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }
                    wehicle.ImageUrl = @"\images\wehicles\" + fileName + extension;

                    wehicle.IsActive = true;
                    _unitOfWork.Wehicle.Add(wehicle);
                }
                else
                {
                    var wehicleFromDb = _unitOfWork.Wehicle.Get(wehicle.Id);
                    if (files.Count > 0)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        var uploads = Path.Combine(webRootPath, @"images\wehicles");
                        var extension_new = Path.GetExtension(files[0].FileName);

                        var imagePath = Path.Combine(webRootPath, wehicleFromDb.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }

                        using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension_new), FileMode.Create))
                        {
                            files[0].CopyTo(fileStreams);
                        }
                        wehicle.ImageUrl = @"\images\wehicles\" + fileName + extension_new;
                    }
                    else
                    {
                        wehicle.ImageUrl = wehicleFromDb.ImageUrl;
                    }

                    wehicle.IsActive = true;
                    _unitOfWork.Wehicle.Update(wehicle);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(nameof(Index));
            }
        }


        #region API

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Wehicle.GetAll() });
        }

        [HttpPut]
        public IActionResult ChangeStatus(int id)
        {
            var objFromDb = _unitOfWork.Wehicle.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Nie znaleziono pojazdu." });
            }

            _unitOfWork.Wehicle.IsActiveChange(id);

            return Json(new { success = true, message = "Zmieniono status." });
        }

        #endregion

    }
}
