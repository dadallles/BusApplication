using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusApplication.DataAccess.Data;
using BusApplication.DataAccess.DTOs;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using BusApplication.Models.ViewModels;
using BusApplication.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusApplication.Areas.Staff.Controllers
{
    [Area("Staff")]
    [Authorize(Roles = StaticData.EmployeeAndAdminRoleString)]
    public class LineNameController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public LineNameVM lineNameVM { get; set; }

        public LineNameController(IUnitOfWork unitOfWork)
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
        public IActionResult AddNewLine()
        {
            NumberOfBusStops numberOfBusStops = new NumberOfBusStops();

            return View(numberOfBusStops);
        }

        [HttpGet]
        public IActionResult Insert(NumberOfBusStops numberOfBusStops)
        {
            LineNameVM lineNameVM = new LineNameVM()
            {
                NumberOfBusStops = numberOfBusStops.number,
                lineName = new LineName(),
                busStopList = new List<BusStopList>(),
                BusStopListItem = _unitOfWork.BusStop.GetBusStopListDropDown(),
                IsReversedToo = false
            };
            return View(lineNameVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(LineNameVM lineNameVM)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork.LineName.GetFirstOrDefault(ln => ln.Name == lineNameVM.lineName.Name) != null)
                {
                    return RedirectToAction(nameof(RepeatedName));
                }
                else
                {
                    lineNameVM.lineName.IsActive = true;
                    _unitOfWork.LineName.Add(lineNameVM.lineName);
                    _unitOfWork.Save();
                    
                    int iter = 1;
                    foreach (var item in lineNameVM.busStopList)
                    {
                        if (_unitOfWork.BusStop.Get(item.BusStopId).Name == "Brak")
                        {
                            break;
                        }
                        BusStopList busStopList = new BusStopList();
                        busStopList.BusStopNumber = iter;
                        busStopList.BusStopId = item.BusStopId;
                        busStopList.LineNameId = _unitOfWork.LineName.GetLast().Id;
                        _unitOfWork.BusStopList.Add(busStopList);
                        _unitOfWork.Save();
                        iter++;
                    }

                    if (lineNameVM.IsReversedToo)
                    {
                        LineName lineNameReversed = new LineName()
                        {
                            Name = lineNameVM.ReversedLineName,
                            IsActive = true
                        };

                        _unitOfWork.LineName.Add(lineNameReversed);
                        _unitOfWork.Save();

                        iter = 1;
                        for (int i = lineNameVM.busStopList.Count-1; i >= 0 ; i--)
                        {
                            if (_unitOfWork.BusStop.Get(lineNameVM.busStopList[i].BusStopId).Name == "Brak")
                            {
                                break;
                            }
                            BusStopList busStopList = new BusStopList();
                            busStopList.BusStopNumber = iter;
                            busStopList.BusStopId = lineNameVM.busStopList[i].BusStopId;
                            busStopList.LineNameId = _unitOfWork.LineName.GetLast().Id;
                            _unitOfWork.BusStopList.Add(busStopList);
                            _unitOfWork.Save();
                            iter++;
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(lineNameVM);
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            LineName lineName = _unitOfWork.LineName.Get(id);
            if (lineName == null)
            {
                return NotFound();
            }
            return View(lineName);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(LineName lineName)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork.LineName.GetFirstOrDefault(ln => ln.Name == lineName.Name) != null)
                {
                    return RedirectToAction(nameof(RepeatedName));
                }
                else
                {
                    _unitOfWork.LineName.Update(lineName);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(lineName);
            }
        }



        #region API

        //for datatable in index action
        [HttpGet]
        public IActionResult GetAllAsList()
        {
            IEnumerable<LineName> lineNames = _unitOfWork.LineName.GetAll();
            IList<LineInfoAsListDto> lineInfoAsListDtoList = new List<LineInfoAsListDto>();
            foreach (var item in lineNames)
            {
                IEnumerable<BusStopList> listForLine = _unitOfWork.BusStopList.GetAll(filter: bsl => bsl.LineNameId == item.Id, includeProperties: "BusStop", orderBy: bsl => bsl.OrderBy(o => o.BusStopNumber));
                string stations = "";
                foreach (var itemLine in listForLine)
                {
                    stations += itemLine.BusStop.Name + " - ";
                }
                stations = stations.Remove(stations.Length - 3);
                lineInfoAsListDtoList.Add(new LineInfoAsListDto(item.Id, item.Name, item.IsActive, stations));
            }

            return Json(new { data = lineInfoAsListDtoList });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<LineName> lineNames = _unitOfWork.LineName.GetAll();
            IList<LineInfoDto> lineInfoDtoList = new List<LineInfoDto>();
            foreach (var item in lineNames)
            {
                IEnumerable<BusStopList> listForLine = _unitOfWork.BusStopList.GetAll(filter: bsl => bsl.LineNameId == item.Id, includeProperties: "BusStop", orderBy: bsl => bsl.OrderBy(o => o.BusStopNumber));
                IList<BusStopDto> busStopDto = new List<BusStopDto>();
                foreach (var itemLine in listForLine)
                {
                    busStopDto.Add(new BusStopDto(itemLine.BusStopNumber, itemLine.BusStop.Name));
                }
                lineInfoDtoList.Add(new LineInfoDto(item.Id, item.Name, item.IsActive, busStopDto));
            }

            return Json(new { data = lineInfoDtoList });
        }

        [HttpPut]
        public IActionResult ChangeStatus(int id)
        {
            var objFromDb = _unitOfWork.LineName.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Nie znaleziono linii." });
            }

            _unitOfWork.LineName.IsActiveChange(id);

            return Json(new { success = true, message = "Zmieniono status." });
        }

        #endregion

    }
}
