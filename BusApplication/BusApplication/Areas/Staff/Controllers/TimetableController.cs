using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusApplication.DataAccess.DTOs;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using BusApplication.Models.ViewModels;
using BusApplication.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusApplication.Areas.Staff.Controllers
{
    [Area("Staff")]
    [Authorize(Roles = StaticData.EmployeeAndAdminRoleString)]
    public class TimetableController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TimetableController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddNewRoute()
        {
            AddNewRouteToTimetableVM addNewRouteToTimetableVM = new AddNewRouteToTimetableVM()
            {
                Timetable = new Timetable(),
                LineName = _unitOfWork.LineName.GetLineNameListDropDown(),
                Wehicle = _unitOfWork.Wehicle.GetWehicleListDropDown(),
                OperatingDays = new OperatingDays(),
                TicketPrice = new TicketPrice(),
            };

            return View(addNewRouteToTimetableVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertNewRoute(AddNewRouteToTimetableVM addNewRouteToTimetableVM)
        {
            if (ModelState.IsValid)
            {
                addNewRouteToTimetableVM.Timetable.IsActive = true;
                addNewRouteToTimetableVM.Timetable.LineName = _unitOfWork.LineName.Get(addNewRouteToTimetableVM.Timetable.LineNameId);
                addNewRouteToTimetableVM.Timetable.Wehicle = _unitOfWork.Wehicle.Get(addNewRouteToTimetableVM.Timetable.WehicleId);
                _unitOfWork.Timetable.Add(addNewRouteToTimetableVM.Timetable);
                _unitOfWork.Save();

                LineName lineName = _unitOfWork.LineName.Get(addNewRouteToTimetableVM.Timetable.LineNameId);
                IEnumerable<BusStopList> listForLine = _unitOfWork.BusStopList.GetAll(filter: bsl => bsl.LineNameId == lineName.Id, includeProperties: "BusStop", orderBy: bsl => bsl.OrderBy(o => o.BusStopNumber));
                ArrivalDepartureBusStopListVM arrivalDepartureBusStopListVM = new ArrivalDepartureBusStopListVM(new List<ArrivalDepartureBusStopVM>(), addNewRouteToTimetableVM.Timetable.Id);

                foreach (var itemLine in listForLine)
                {
                    arrivalDepartureBusStopListVM.arrivalDepartureBusStopListVM.Add(new ArrivalDepartureBusStopVM(itemLine.BusStopId, itemLine.BusStop.Name, null, null));
                }

                return View(arrivalDepartureBusStopListVM);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(ArrivalDepartureBusStopListVM arrivalsDeparturesBusStopListVM)
        {
            if (ModelState.IsValid)
            {
                for(int i = 0; i < arrivalsDeparturesBusStopListVM.arrivalDepartureBusStopListVM.Count; i++)
                {
                    if (i == 0)
                    {
                        if (arrivalsDeparturesBusStopListVM.arrivalDepartureBusStopListVM[i].DepartureTime == null)
                        {
                            IList<Timetable> timetables = (IList<Timetable>)_unitOfWork.Timetable.GetAll();
                            Timetable timetable = _unitOfWork.Timetable.GetFirstOrDefault(t => t.Id == timetables[timetables.Count - 1].Id);
                            _unitOfWork.Timetable.Remove(timetable);
                            _unitOfWork.Save();

                            return RedirectToAction(nameof(Index));
                        }
                    }
                    else if (i == arrivalsDeparturesBusStopListVM.arrivalDepartureBusStopListVM.Count - 1)
                    {
                        if (arrivalsDeparturesBusStopListVM.arrivalDepartureBusStopListVM[i].ArrivalTime == null)
                        {
                            IList<Timetable> timetables = (IList<Timetable>)_unitOfWork.Timetable.GetAll();
                            Timetable timetable = _unitOfWork.Timetable.GetFirstOrDefault(t => t.Id == timetables[timetables.Count - 1].Id);
                            _unitOfWork.Timetable.Remove(timetable);
                            _unitOfWork.Save();

                            return RedirectToAction(nameof(Index));
                        }
                    }
                    else
                    {
                        if (arrivalsDeparturesBusStopListVM.arrivalDepartureBusStopListVM[i].ArrivalTime == null || 
                            arrivalsDeparturesBusStopListVM.arrivalDepartureBusStopListVM[i].DepartureTime == null)
                        {
                            IList<Timetable> timetables = (IList<Timetable>)_unitOfWork.Timetable.GetAll();
                            Timetable timetable = _unitOfWork.Timetable.GetFirstOrDefault(t => t.Id == timetables[timetables.Count - 1].Id);
                            _unitOfWork.Timetable.Remove(timetable);
                            _unitOfWork.Save();

                            return RedirectToAction(nameof(Index));
                        }
                    }

                    ArrivalsDepartures arrivalDeparture = new ArrivalsDepartures()
                    {
                        ArrivalTime = arrivalsDeparturesBusStopListVM.arrivalDepartureBusStopListVM[i].ArrivalTime,
                        DepartureTime = arrivalsDeparturesBusStopListVM.arrivalDepartureBusStopListVM[i].DepartureTime,
                        BusStopId = arrivalsDeparturesBusStopListVM.arrivalDepartureBusStopListVM[i].BusStopId,
                        TimetableId = arrivalsDeparturesBusStopListVM.TimetableId
                    };
                    _unitOfWork.ArrivalsDepartures.Add(arrivalDeparture);
                    _unitOfWork.Save();
                }

                return RedirectToAction(nameof(Index));
            }
            else
            {
                IList<Timetable> timetables = (IList<Timetable>)_unitOfWork.Timetable.GetAll();
                Timetable timetable = _unitOfWork.Timetable.GetFirstOrDefault(t => t.Id == timetables[timetables.Count - 1].Id);
                _unitOfWork.Timetable.Remove(timetable);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index), arrivalsDeparturesBusStopListVM);
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Timetable timetable = _unitOfWork.Timetable.GetFirstOrDefault(t => t.Id == id);
            if (timetable == null)
            {
                return NotFound();
            }

            EditRouteVM editRouteVM = new EditRouteVM()
            {
                OperatingDays = _unitOfWork.OperatingDays.GetFirstOrDefault(op => op.Id == timetable.OperatingDaysId),
                TicketPrice = _unitOfWork.TicketPrice.GetFirstOrDefault(tp => tp.Id == timetable.TicketPriceId)
            };

            return View(editRouteVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(EditRouteVM editRouteVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.OperatingDays.Update(editRouteVM.OperatingDays);
                _unitOfWork.TicketPrice.Update(editRouteVM.TicketPrice);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(editRouteVM);
            }
        }





        #region API

        [HttpGet]
        public IActionResult GetAll()
        {
            IList<ArrivalsDepartures> ArrivalsDepartures = (IList<ArrivalsDepartures>)_unitOfWork.ArrivalsDepartures.GetAll();
            IList<Timetable> TimetableList = (IList<Timetable>)_unitOfWork.Timetable.GetAll();
            IList<Timetable> Timetables = new List<Timetable>();
            foreach (var item in TimetableList)
            {
                if (ArrivalsDepartures.Any(a => a.TimetableId == item.Id))
                {
                    Timetables.Add(item);
                }
            }

            IList<TimetableIndexDto> TimetableIndexDtos = new List<TimetableIndexDto>();
            foreach (var item in Timetables)
            {
                string operDays = "";
                OperatingDays operDay = _unitOfWork.OperatingDays.GetFirstOrDefault(od => od.Id == item.OperatingDaysId);
                ArrivalsDepartures Departure = _unitOfWork.ArrivalsDepartures.GetFirstOrDefault(ad => ad.TimetableId == item.Id);

                if (operDay.Monday)
                {
                    operDays += "poniedziałek, ";
                }
                if (operDay.Thursday)
                {
                    operDays += "wtorek, ";
                }
                if (operDay.Wednesday)
                {
                    operDays += "środa, ";
                }
                if (operDay.Thursday)
                {
                    operDays += "czwartek, ";
                }
                if (operDay.Friday)
                {
                    operDays += "piątek, ";
                }
                if (operDay.Saturday)
                {
                    operDays += "sobota, ";
                }
                if (operDay.SundayAndHolidays)
                {
                    operDays += "niedziele/święta, ";
                }

                operDays = operDays.Remove(operDays.Length - 2);

                string departureTime = Departure.DepartureTime.Value.Hour.ToString() + " : ";
                if (Departure.DepartureTime.Value.Minute < 10)
                {
                    departureTime += "0" + Departure.DepartureTime.Value.Minute.ToString();
                }
                else
                {
                    departureTime += Departure.DepartureTime.Value.Minute.ToString();
                }

                TimetableIndexDto timetableIndexDto = new TimetableIndexDto()
                {
                    Id = item.Id,
                    LineName = _unitOfWork.LineName.Get(item.LineNameId).Name,
                    Wehicle = _unitOfWork.Wehicle.Get(item.WehicleId).Brand + " " + _unitOfWork.Wehicle.Get(item.Wehicle.Id).Model,
                    OperatingDays = operDays,
                    DepartureTime = departureTime,
                    PricePerEntireRoute = _unitOfWork.TicketPrice.Get(item.TicketPriceId).PricePerEntireRoute,
                    PricePerSegment = _unitOfWork.TicketPrice.Get(item.TicketPriceId).PricePerSegment,
                    IsActive = item.IsActive
                };
                TimetableIndexDtos.Add(timetableIndexDto);
            }

            return Json(new { data = TimetableIndexDtos });
        }

        [HttpPut]
        public IActionResult ChangeStatus(int id)
        {
            var objFromDb = _unitOfWork.Timetable.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Nie znaleziono kursu." });
            }

            _unitOfWork.Timetable.IsActiveChange(id);

            return Json(new { success = true, message = "Zmieniono status." });
        }

        #endregion

    }
}
