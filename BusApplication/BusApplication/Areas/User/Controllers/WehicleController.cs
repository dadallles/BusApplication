using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;

namespace BusApplication.Areas.User.Controllers
{
    [Area("User")]
    [AllowAnonymous]
    public class WehicleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WehicleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Wehicle> wehicles = _unitOfWork.Wehicle.GetAll(filter: w => w.IsActive == true);

            return View(wehicles);
        }

    }
}
