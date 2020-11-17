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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BusApplication.Areas.User.Controllers
{
    [Area("User")]
    [AllowAnonymous]
    public class TimetableController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private UserManager<IdentityUser> _userManager;

        [BindProperty]
        public SearchRouteVM SearchRouteVM { get; set; }

        public TimetableController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            LineListForTimetableListVM lineListForTimetableListVM = new LineListForTimetableListVM();
            lineListForTimetableListVM.lineForTimetableListVMs = new List<LineForTimetableListVM>();

            IEnumerable<LineName> lineNames = _unitOfWork.LineName.GetAll(ln => ln.IsActive == true);
            IList<LineForTimetableListVM> lineForTimetableListVMs = new List<LineForTimetableListVM>();

            foreach (var item in lineNames)
            {
                IEnumerable<BusStopList> listForLine = _unitOfWork.BusStopList.GetAll(filter: bsl => bsl.LineNameId == item.Id, includeProperties: "BusStop", orderBy: bsl => bsl.OrderBy(o => o.BusStopNumber));
                string stations = "";
                foreach (var itemLine in listForLine)
                {
                    stations += itemLine.BusStop.Name + " - ";
                }
                stations = stations.Remove(stations.Length - 3);
                lineListForTimetableListVM.lineForTimetableListVMs.Add(new LineForTimetableListVM(item.Id, item.Name, stations));
            }

            return View(lineListForTimetableListVM);
        }

        [HttpGet]
        public IActionResult Details(int lineId)
        {
            LineName lineName = _unitOfWork.LineName.Get(lineId);

            if (lineName == null)
            {
                return NotFound();
            }

            LineTimetablesDetailsVM lineTimetablesDetailsVM = new LineTimetablesDetailsVM();
            lineTimetablesDetailsVM.LineName = lineName.Name;
            lineTimetablesDetailsVM.BusStopsList = new List<string>();

            IEnumerable<BusStopList> listForLine = _unitOfWork.BusStopList.GetAll(filter: bsl => bsl.LineNameId == lineName.Id, includeProperties: "BusStop", orderBy: bsl => bsl.OrderBy(o => o.BusStopNumber));
            foreach (var itemLine in listForLine)
            {
                lineTimetablesDetailsVM.BusStopsList.Add(itemLine.BusStop.Name);
            }

            IEnumerable<Timetable> timetables = _unitOfWork.Timetable.GetAll(t => t.LineNameId == lineName.Id).Where(t => t.IsActive == true);
            foreach (var item in timetables)
            {
                item.OperatingDays = _unitOfWork.OperatingDays.GetFirstOrDefault(od => od.Id == item.OperatingDaysId);
            }

            lineTimetablesDetailsVM.LineTimetableDetailsForDays = new List<LineTimetableDetailsForDaysVM>();

            foreach (var item in timetables)
            {
                if (item.OperatingDays.Monday)
                {
                    LineTimetableDetailsForDaysVM lineTimetableDetailsForDaysVM = new LineTimetableDetailsForDaysVM();
                    lineTimetableDetailsForDaysVM.OperatingDay = 1;
                    lineTimetableDetailsForDaysVM.ArrivalsDepartures = new List<string>();
                    IEnumerable<ArrivalsDepartures> arrivalsDeparturesForRoute = _unitOfWork.ArrivalsDepartures.GetAll(filter: ad => ad.TimetableId == item.Id, orderBy: ad => ad.OrderBy(o => o.Id));
                    foreach (var item2 in arrivalsDeparturesForRoute)
                    {
                        string time = "";
                        if (item2.ArrivalTime == null)
                        {
                            time = "-/" + item2.DepartureTime.Value.Hour + ":";
                            if (item2.DepartureTime.Value.Minute < 10)
                            {
                                time += "0" + item2.DepartureTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.DepartureTime.Value.Minute; 
                            }
                        }
                        else if (item2.DepartureTime == null)
                        {
                            time = item2.ArrivalTime.Value.Hour + ":";
                            if (item2.ArrivalTime.Value.Minute < 10)
                            {
                                time += "0" + item2.ArrivalTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.ArrivalTime.Value.Minute;
                            }
                            time +=  "/-";
                        }
                        else
                        {
                            time = item2.ArrivalTime.Value.Hour + ":";
                            if (item2.ArrivalTime.Value.Minute < 10)
                            {
                                time += "0" + item2.ArrivalTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.ArrivalTime.Value.Minute;
                            }
                            time += "/" + item2.DepartureTime.Value.Hour + ":";
                            if (item2.DepartureTime.Value.Minute < 10)
                            {
                                time += "0" + item2.DepartureTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.DepartureTime.Value.Minute;
                            }
                        }
                        lineTimetableDetailsForDaysVM.ArrivalsDepartures.Add(time);
                    }
                    lineTimetablesDetailsVM.LineTimetableDetailsForDays.Add(lineTimetableDetailsForDaysVM);
                }

                if (item.OperatingDays.Tuesday)
                {
                    LineTimetableDetailsForDaysVM lineTimetableDetailsForDaysVM = new LineTimetableDetailsForDaysVM();
                    lineTimetableDetailsForDaysVM.OperatingDay = 2;
                    lineTimetableDetailsForDaysVM.ArrivalsDepartures = new List<string>();
                    IEnumerable<ArrivalsDepartures> arrivalsDeparturesForRoute = _unitOfWork.ArrivalsDepartures.GetAll(filter: ad => ad.TimetableId == item.Id, orderBy: ad => ad.OrderBy(o => o.Id));
                    foreach (var item2 in arrivalsDeparturesForRoute)
                    {
                        string time = "";
                        if (item2.ArrivalTime == null)
                        {
                            time = "-/" + item2.DepartureTime.Value.Hour + ":";
                            if (item2.DepartureTime.Value.Minute < 10)
                            {
                                time += "0" + item2.DepartureTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.DepartureTime.Value.Minute;
                            }
                        }
                        else if (item2.DepartureTime == null)
                        {
                            time = item2.ArrivalTime.Value.Hour + ":";
                            if (item2.ArrivalTime.Value.Minute < 10)
                            {
                                time += "0" + item2.ArrivalTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.ArrivalTime.Value.Minute;
                            }
                            time += "/-";
                        }
                        else
                        {
                            time = item2.ArrivalTime.Value.Hour + ":";
                            if (item2.ArrivalTime.Value.Minute < 10)
                            {
                                time += "0" + item2.ArrivalTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.ArrivalTime.Value.Minute;
                            }
                            time += "/" + item2.DepartureTime.Value.Hour + ":";
                            if (item2.DepartureTime.Value.Minute < 10)
                            {
                                time += "0" + item2.DepartureTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.DepartureTime.Value.Minute;
                            }
                        }
                        lineTimetableDetailsForDaysVM.ArrivalsDepartures.Add(time);
                    }
                    lineTimetablesDetailsVM.LineTimetableDetailsForDays.Add(lineTimetableDetailsForDaysVM);
                }

                if (item.OperatingDays.Wednesday)
                {
                    LineTimetableDetailsForDaysVM lineTimetableDetailsForDaysVM = new LineTimetableDetailsForDaysVM();
                    lineTimetableDetailsForDaysVM.OperatingDay = 3;
                    lineTimetableDetailsForDaysVM.ArrivalsDepartures = new List<string>();
                    IEnumerable<ArrivalsDepartures> arrivalsDeparturesForRoute = _unitOfWork.ArrivalsDepartures.GetAll(filter: ad => ad.TimetableId == item.Id, orderBy: ad => ad.OrderBy(o => o.Id));
                    foreach (var item2 in arrivalsDeparturesForRoute)
                    {
                        string time = "";
                        if (item2.ArrivalTime == null)
                        {
                            time = "-/" + item2.DepartureTime.Value.Hour + ":";
                            if (item2.DepartureTime.Value.Minute < 10)
                            {
                                time += "0" + item2.DepartureTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.DepartureTime.Value.Minute;
                            }
                        }
                        else if (item2.DepartureTime == null)
                        {
                            time = item2.ArrivalTime.Value.Hour + ":";
                            if (item2.ArrivalTime.Value.Minute < 10)
                            {
                                time += "0" + item2.ArrivalTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.ArrivalTime.Value.Minute;
                            }
                            time += "/-";
                        }
                        else
                        {
                            time = item2.ArrivalTime.Value.Hour + ":";
                            if (item2.ArrivalTime.Value.Minute < 10)
                            {
                                time += "0" + item2.ArrivalTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.ArrivalTime.Value.Minute;
                            }
                            time += "/" + item2.DepartureTime.Value.Hour + ":";
                            if (item2.DepartureTime.Value.Minute < 10)
                            {
                                time += "0" + item2.DepartureTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.DepartureTime.Value.Minute;
                            }
                        }
                        lineTimetableDetailsForDaysVM.ArrivalsDepartures.Add(time);
                    }
                    lineTimetablesDetailsVM.LineTimetableDetailsForDays.Add(lineTimetableDetailsForDaysVM);
                }

                if (item.OperatingDays.Thursday)
                {
                    LineTimetableDetailsForDaysVM lineTimetableDetailsForDaysVM = new LineTimetableDetailsForDaysVM();
                    lineTimetableDetailsForDaysVM.OperatingDay = 4;
                    lineTimetableDetailsForDaysVM.ArrivalsDepartures = new List<string>();
                    IEnumerable<ArrivalsDepartures> arrivalsDeparturesForRoute = _unitOfWork.ArrivalsDepartures.GetAll(filter: ad => ad.TimetableId == item.Id, orderBy: ad => ad.OrderBy(o => o.Id));
                    foreach (var item2 in arrivalsDeparturesForRoute)
                    {
                        string time = "";
                        if (item2.ArrivalTime == null)
                        {
                            time = "-/" + item2.DepartureTime.Value.Hour + ":";
                            if (item2.DepartureTime.Value.Minute < 10)
                            {
                                time += "0" + item2.DepartureTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.DepartureTime.Value.Minute;
                            }
                        }
                        else if (item2.DepartureTime == null)
                        {
                            time = item2.ArrivalTime.Value.Hour + ":";
                            if (item2.ArrivalTime.Value.Minute < 10)
                            {
                                time += "0" + item2.ArrivalTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.ArrivalTime.Value.Minute;
                            }
                            time += "/-";
                        }
                        else
                        {
                            time = item2.ArrivalTime.Value.Hour + ":";
                            if (item2.ArrivalTime.Value.Minute < 10)
                            {
                                time += "0" + item2.ArrivalTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.ArrivalTime.Value.Minute;
                            }
                            time += "/" + item2.DepartureTime.Value.Hour + ":";
                            if (item2.DepartureTime.Value.Minute < 10)
                            {
                                time += "0" + item2.DepartureTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.DepartureTime.Value.Minute;
                            }
                        }
                        lineTimetableDetailsForDaysVM.ArrivalsDepartures.Add(time);
                    }
                    lineTimetablesDetailsVM.LineTimetableDetailsForDays.Add(lineTimetableDetailsForDaysVM);
                }

                if (item.OperatingDays.Friday)
                {
                    LineTimetableDetailsForDaysVM lineTimetableDetailsForDaysVM = new LineTimetableDetailsForDaysVM();
                    lineTimetableDetailsForDaysVM.OperatingDay = 5;
                    lineTimetableDetailsForDaysVM.ArrivalsDepartures = new List<string>();
                    IEnumerable<ArrivalsDepartures> arrivalsDeparturesForRoute = _unitOfWork.ArrivalsDepartures.GetAll(filter: ad => ad.TimetableId == item.Id, orderBy: ad => ad.OrderBy(o => o.Id));
                    foreach (var item2 in arrivalsDeparturesForRoute)
                    {
                        string time = "";
                        if (item2.ArrivalTime == null)
                        {
                            time = "-/" + item2.DepartureTime.Value.Hour + ":";
                            if (item2.DepartureTime.Value.Minute < 10)
                            {
                                time += "0" + item2.DepartureTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.DepartureTime.Value.Minute;
                            }
                        }
                        else if (item2.DepartureTime == null)
                        {
                            time = item2.ArrivalTime.Value.Hour + ":";
                            if (item2.ArrivalTime.Value.Minute < 10)
                            {
                                time += "0" + item2.ArrivalTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.ArrivalTime.Value.Minute;
                            }
                            time += "/-";
                        }
                        else
                        {
                            time = item2.ArrivalTime.Value.Hour + ":";
                            if (item2.ArrivalTime.Value.Minute < 10)
                            {
                                time += "0" + item2.ArrivalTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.ArrivalTime.Value.Minute;
                            }
                            time += "/" + item2.DepartureTime.Value.Hour + ":";
                            if (item2.DepartureTime.Value.Minute < 10)
                            {
                                time += "0" + item2.DepartureTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.DepartureTime.Value.Minute;
                            }
                        }
                        lineTimetableDetailsForDaysVM.ArrivalsDepartures.Add(time);
                    }
                    lineTimetablesDetailsVM.LineTimetableDetailsForDays.Add(lineTimetableDetailsForDaysVM);
                }

                if (item.OperatingDays.Saturday)
                {
                    LineTimetableDetailsForDaysVM lineTimetableDetailsForDaysVM = new LineTimetableDetailsForDaysVM();
                    lineTimetableDetailsForDaysVM.OperatingDay = 6;
                    lineTimetableDetailsForDaysVM.ArrivalsDepartures = new List<string>();
                    IEnumerable<ArrivalsDepartures> arrivalsDeparturesForRoute = _unitOfWork.ArrivalsDepartures.GetAll(filter: ad => ad.TimetableId == item.Id, orderBy: ad => ad.OrderBy(o => o.Id));
                    foreach (var item2 in arrivalsDeparturesForRoute)
                    {
                        string time = "";
                        if (item2.ArrivalTime == null)
                        {
                            time = "-/" + item2.DepartureTime.Value.Hour + ":";
                            if (item2.DepartureTime.Value.Minute < 10)
                            {
                                time += "0" + item2.DepartureTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.DepartureTime.Value.Minute;
                            }
                        }
                        else if (item2.DepartureTime == null)
                        {
                            time = item2.ArrivalTime.Value.Hour + ":";
                            if (item2.ArrivalTime.Value.Minute < 10)
                            {
                                time += "0" + item2.ArrivalTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.ArrivalTime.Value.Minute;
                            }
                            time += "/-";
                        }
                        else
                        {
                            time = item2.ArrivalTime.Value.Hour + ":";
                            if (item2.ArrivalTime.Value.Minute < 10)
                            {
                                time += "0" + item2.ArrivalTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.ArrivalTime.Value.Minute;
                            }
                            time += "/" + item2.DepartureTime.Value.Hour + ":";
                            if (item2.DepartureTime.Value.Minute < 10)
                            {
                                time += "0" + item2.DepartureTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.DepartureTime.Value.Minute;
                            }
                        }
                        lineTimetableDetailsForDaysVM.ArrivalsDepartures.Add(time);
                    }
                    lineTimetablesDetailsVM.LineTimetableDetailsForDays.Add(lineTimetableDetailsForDaysVM);
                }

                if (item.OperatingDays.SundayAndHolidays)
                {
                    LineTimetableDetailsForDaysVM lineTimetableDetailsForDaysVM = new LineTimetableDetailsForDaysVM();
                    lineTimetableDetailsForDaysVM.OperatingDay = 7;
                    lineTimetableDetailsForDaysVM.ArrivalsDepartures = new List<string>();
                    IEnumerable<ArrivalsDepartures> arrivalsDeparturesForRoute = _unitOfWork.ArrivalsDepartures.GetAll(filter: ad => ad.TimetableId == item.Id, orderBy: ad => ad.OrderBy(o => o.Id));
                    foreach (var item2 in arrivalsDeparturesForRoute)
                    {
                        string time = "";
                        if (item2.ArrivalTime == null)
                        {
                            time = "-/" + item2.DepartureTime.Value.Hour + ":";
                            if (item2.DepartureTime.Value.Minute < 10)
                            {
                                time += "0" + item2.DepartureTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.DepartureTime.Value.Minute;
                            }
                        }
                        else if (item2.DepartureTime == null)
                        {
                            time = item2.ArrivalTime.Value.Hour + ":";
                            if (item2.ArrivalTime.Value.Minute < 10)
                            {
                                time += "0" + item2.ArrivalTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.ArrivalTime.Value.Minute;
                            }
                            time += "/-";
                        }
                        else
                        {
                            time = item2.ArrivalTime.Value.Hour + ":";
                            if (item2.ArrivalTime.Value.Minute < 10)
                            {
                                time += "0" + item2.ArrivalTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.ArrivalTime.Value.Minute;
                            }
                            time += "/" + item2.DepartureTime.Value.Hour + ":";
                            if (item2.DepartureTime.Value.Minute < 10)
                            {
                                time += "0" + item2.DepartureTime.Value.Minute;
                            }
                            else
                            {
                                time += +item2.DepartureTime.Value.Minute;
                            }
                        }
                        lineTimetableDetailsForDaysVM.ArrivalsDepartures.Add(time);
                    }
                    lineTimetablesDetailsVM.LineTimetableDetailsForDays.Add(lineTimetableDetailsForDaysVM);
                }

            }

            return View(lineTimetablesDetailsVM);
        }

        [HttpGet]
        public IActionResult Search(SearchRouteVM searchRouteVM = null)
        {
            if (searchRouteVM.StartTime != null && searchRouteVM.BusStopListStartId != 0 && searchRouteVM.BusStopListEndId != 0)
            {
                int DayOfWeek = (int)searchRouteVM.StartTime.DayOfWeek;
                bool IsHoliday = false;
                IEnumerable<Holidays> holidays = _unitOfWork.Holidays.GetAll();

                foreach (var item in holidays)
                {
                    if (item.Day == searchRouteVM.StartTime.Day && item.Month == searchRouteVM.StartTime.Month)
                    {
                        IsHoliday = true;
                        break;
                    }
                }

                int Year = searchRouteVM.StartTime.Year;

                int poniedzialek_wielkanocny_dzien, poniedzialek_wielkanocny_miesiac, boze_cialo_dzien, boze_cialo_miesiac,
                    luty = (((Year % 4 == 0) && (Year % 100 != 0)) || (Year % 400 == 0)) ? 29 : 28,
                    dzien_roku = 31 + luty,
                    G = Year % 19,
                    C = Year / 100,
                    H = (C - (C / 4) - ((8 * C + 13) / 25) + 19 * G + 15) % 30,
                    I = H - (H / 28) * (1 - (29 / (H + 1)) * ((21 - G) / 11)),
                    J = (Year + (Year / 4) + I + 2 - C + (C / 4)) % 7,
                    L = I - J,
                    month = 3 + ((L + 40) / 44),
                    day = L + 28 - 31 * (month / 4);

                if (day == 31 && month == 3)
                {
                    poniedzialek_wielkanocny_dzien = 1;
                    poniedzialek_wielkanocny_miesiac = 3;
                }
                else
                {
                    poniedzialek_wielkanocny_dzien = day + 1;
                    poniedzialek_wielkanocny_miesiac = month - 1;
                }

                if (month == 3)
                {
                    dzien_roku += day;
                }
                else
                {
                    dzien_roku = dzien_roku + 31 + day;
                }

                dzien_roku += 60;

                if (luty == 28 && dzien_roku <= 151)
                {
                    boze_cialo_dzien = dzien_roku - 120;
                    boze_cialo_miesiac = 4;
                }
                else if (luty == 29 && dzien_roku <= 152)
                {
                    boze_cialo_dzien = dzien_roku - 121;
                    boze_cialo_miesiac = 4;
                }
                else if (luty == 29)
                {
                    boze_cialo_dzien = dzien_roku - 152;
                    boze_cialo_miesiac = 5;
                }
                else
                {
                    boze_cialo_dzien = dzien_roku - 151;
                    boze_cialo_miesiac = 5;
                }

                if (DayOfWeek == 0 || 
                    IsHoliday == true ||
                    (searchRouteVM.StartTime.Day == poniedzialek_wielkanocny_dzien && searchRouteVM.StartTime.Month == poniedzialek_wielkanocny_miesiac+1) ||
                    (searchRouteVM.StartTime.Day == boze_cialo_dzien && searchRouteVM.StartTime.Month == boze_cialo_miesiac+1))
                {
                    DayOfWeek = 7;
                }

                searchRouteVM.searchRouteShowRouteVMs = new List<SearchRouteShowRouteVM>();

                IList<ArrivalsDepartures> arrivalsDeparturesStart = (IList<ArrivalsDepartures>)_unitOfWork.ArrivalsDepartures.GetAll(ad => ad.BusStopId == searchRouteVM.BusStopListStartId);
                IList<ArrivalsDepartures> arrivalsDeparturesEnd = (IList<ArrivalsDepartures>)_unitOfWork.ArrivalsDepartures.GetAll(ad => ad.BusStopId == searchRouteVM.BusStopListEndId);

                foreach (var start in arrivalsDeparturesStart)
                {
                    foreach (var end in arrivalsDeparturesEnd)
                    {
                        Timetable timetableStart = _unitOfWork.Timetable.GetFirstOrDefault(t => t.Id == start.TimetableId);
                        Timetable timetableEnd = _unitOfWork.Timetable.GetFirstOrDefault(t => t.Id == end.TimetableId);
                        OperatingDays operatingDaysStart = _unitOfWork.OperatingDays.GetFirstOrDefault(od => od.Id == timetableStart.OperatingDaysId);
                        OperatingDays operatingDaysEnd = _unitOfWork.OperatingDays.GetFirstOrDefault(od => od.Id == timetableEnd.OperatingDaysId);
                        bool IsValidOperatingDay = false;

                        if (DayOfWeek == 1 && operatingDaysStart.Monday == true)
                        {
                            IsValidOperatingDay = true;
                        }
                        if (DayOfWeek == 2 && operatingDaysStart.Tuesday == true)
                        {
                            IsValidOperatingDay = true;
                        }
                        if (DayOfWeek == 3 && operatingDaysStart.Wednesday == true)
                        {
                            IsValidOperatingDay = true;
                        }
                        if (DayOfWeek == 4 && operatingDaysStart.Thursday == true)
                        {
                            IsValidOperatingDay = true;
                        }
                        if (DayOfWeek == 5 && operatingDaysStart.Friday == true)
                        {
                            IsValidOperatingDay = true;
                        }
                        if (DayOfWeek == 6 && operatingDaysStart.Saturday == true)
                        {
                            IsValidOperatingDay = true;
                        }
                        if (DayOfWeek == 7 && operatingDaysStart.SundayAndHolidays == true)
                        {
                            IsValidOperatingDay = true;
                        }

                        if (start.TimetableId == end.TimetableId && 
                            start.DepartureTime < end.ArrivalTime &&
                            IsValidOperatingDay == true &&
                            timetableStart.IsActive == true &&
                            timetableEnd.IsActive == true)
                        {
                            DateTime startDateTime = new DateTime(2000, 1, 1, start.DepartureTime.Value.Hour, start.DepartureTime.Value.Minute, 0);
                            DateTime searchRouteDateTime = new DateTime(2000, 1, 1, searchRouteVM.StartTime.Hour, searchRouteVM.StartTime.Minute, 0);

                            if (startDateTime.CompareTo(searchRouteDateTime) >= 0)
                            {
                                SearchRouteShowRouteVM searchRouteShowRouteVM = new SearchRouteShowRouteVM();
                                searchRouteShowRouteVM.TimetableId = start.TimetableId;
                                Timetable timetable = _unitOfWork.Timetable.GetFirstOrDefault(t => t.Id == start.TimetableId);
                                LineName lineName = _unitOfWork.LineName.GetFirstOrDefault(ln => ln.Id == timetable.LineNameId);
                                searchRouteShowRouteVM.LineName = lineName.Name;
                                searchRouteShowRouteVM.StartBusStopName = _unitOfWork.BusStop.GetFirstOrDefault(bs => bs.Id == searchRouteVM.BusStopListStartId).Name;
                                string departure = start.DepartureTime.Value.Hour + ":";
                                if (start.DepartureTime.Value.Minute < 10)
                                {
                                    departure += "0" + start.DepartureTime.Value.Minute;
                                }
                                else
                                {
                                    departure += start.DepartureTime.Value.Minute;
                                }
                                searchRouteShowRouteVM.DepartureTime = departure;
                                searchRouteShowRouteVM.EndBusStopName = _unitOfWork.BusStop.GetFirstOrDefault(bs => bs.Id == searchRouteVM.BusStopListEndId).Name;
                                string arrival = end.ArrivalTime.Value.Hour + ":";
                                if (end.ArrivalTime.Value.Minute < 10)
                                {
                                    arrival += "0" + end.ArrivalTime.Value.Minute;
                                }
                                else
                                {
                                    arrival += end.ArrivalTime.Value.Minute;
                                }
                                searchRouteShowRouteVM.ArrivalTime = arrival;

                                searchRouteVM.searchRouteShowRouteVMs.Add(searchRouteShowRouteVM);
                            }
                        }
                    }
                }

            }

            DateTime DateTimeNow = DateTime.Now;
            searchRouteVM = new SearchRouteVM()
            {
                BusStopListStart = _unitOfWork.BusStop.GetBusStopListDropDown(),
                BusStopListEnd = _unitOfWork.BusStop.GetBusStopListDropDown(),
                StartTime = new DateTime(DateTimeNow.Year, DateTimeNow.Month, DateTimeNow.Day, DateTimeNow.Hour, DateTimeNow.Minute, 0),
                searchRouteShowRouteVMs = searchRouteVM.searchRouteShowRouteVMs
            };

            return View(searchRouteVM);
        }

        [HttpGet]
        public IActionResult ShowBusStops(ShowBusStopsListBetweenBusStopsVM showBusStopsListBetweenBusStopsVM)
        {
            IEnumerable<ArrivalsDepartures> arrivalsDeparturesByTimetableId = _unitOfWork.ArrivalsDepartures.GetAll
                (
                filter: ad => ad.TimetableId == showBusStopsListBetweenBusStopsVM.TimetableId,
                orderBy: ad => ad.OrderBy(o => o.ArrivalTime),
                includeProperties: "BusStop"
                );

            BusStopListBetweenBusStopsVM busStopListBetweenBusStopsVM = new BusStopListBetweenBusStopsVM();
            busStopListBetweenBusStopsVM.busStopBetweenBusStopsVMs = new List<BusStopBetweenBusStopsVM>();
            bool IsStartBusStop = false;
            foreach (var item in arrivalsDeparturesByTimetableId)
            {
                if (item.BusStopId == showBusStopsListBetweenBusStopsVM.BusStopListStartId)
                {
                    IsStartBusStop = true;
                }

                if (IsStartBusStop)
                {
                    BusStopBetweenBusStopsVM busStopBetweenBusStopsVM = new BusStopBetweenBusStopsVM();
                    busStopBetweenBusStopsVM.BusStopName = item.BusStop.Name;

                    string departure = "";
                    if (item.DepartureTime != null)
                    {
                        departure += item.DepartureTime.Value.Hour + ":";
                        if (item.DepartureTime.Value.Minute < 10)
                        {
                            departure += "0" + item.DepartureTime.Value.Minute;
                        }
                        else
                        {
                            departure += item.DepartureTime.Value.Minute;
                        }
                    }

                    string arrival = "";
                    if (item.ArrivalTime != null)
                    {
                        arrival += item.ArrivalTime.Value.Hour + ":";
                        if (item.ArrivalTime.Value.Minute < 10)
                        {
                            arrival += "0" + item.ArrivalTime.Value.Minute;
                        }
                        else
                        {
                            arrival += item.ArrivalTime.Value.Minute;
                        }
                    }

                    busStopBetweenBusStopsVM.ArrivalTime = arrival;
                    busStopBetweenBusStopsVM.DepartureTime = departure;

                    busStopListBetweenBusStopsVM.busStopBetweenBusStopsVMs.Add(busStopBetweenBusStopsVM);
                }

                if (item.BusStopId == showBusStopsListBetweenBusStopsVM.BusStopListEndId)
                {
                    break;
                }
            }

            return View(busStopListBetweenBusStopsVM);
        }

        [HttpGet]
        public IActionResult StartPurchase(StartPurchaseDto startPurchaseDto)
        {
            if (User.IsInRole(StaticData.UserRole))
            {
                IEnumerable<BusRoute> BusRoutes = _unitOfWork.BusRoute.GetAll(br => br.TimetableId == startPurchaseDto.TimetableId);

                BusRoute busRoute = null;
                foreach (var item in BusRoutes)
                {
                    if (item.RouteDate.Year == startPurchaseDto.StartTime.Year && item.RouteDate.Month == startPurchaseDto.StartTime.Month && item.RouteDate.Day == startPurchaseDto.StartTime.Day)
                    {
                        busRoute = item;
                        break;
                    }
                }

                Timetable timetable = _unitOfWork.Timetable.GetFirstOrDefault(t => t.Id == startPurchaseDto.TimetableId);
                Wehicle wehicle = _unitOfWork.Wehicle.GetFirstOrDefault(w => w.Id == timetable.WehicleId);

                if (busRoute == null)
                {
                    busRoute = new BusRoute()
                    {
                        RouteDate = new DateTime(startPurchaseDto.StartTime.Year, startPurchaseDto.StartTime.Month, startPurchaseDto.StartTime.Day),
                        AvailableSeats = wehicle.NumberOfSeats,
                        TimetableId = startPurchaseDto.TimetableId
                    };

                    _unitOfWork.BusRoute.Add(busRoute);
                    _unitOfWork.Save();
                }

                ChooseTicketsParametersVM chooseTicketsParametersVM = new ChooseTicketsParametersVM();
                chooseTicketsParametersVM.BusRoute = busRoute;
                chooseTicketsParametersVM.StartBusStopName = _unitOfWork.BusStop.GetFirstOrDefault(bs => bs.Id == startPurchaseDto.BusStopListStartId).Name;
                chooseTicketsParametersVM.EndBusStopName = _unitOfWork.BusStop.GetFirstOrDefault(bs => bs.Id == startPurchaseDto.BusStopListEndId).Name;
                IList<ArrivalsDepartures> arrivalsDepartures = (IList<ArrivalsDepartures>)_unitOfWork.ArrivalsDepartures.GetAll(filter: ad => ad.TimetableId == timetable.Id, orderBy: t => t.OrderBy(o => o.ArrivalTime));
                bool IsFirst = false;
                bool IsLast = false;
                bool StartCounting = false;
                bool StopCounting = false;
                int NumberOfBusStops = 1;
                for (int i = 0; i < arrivalsDepartures.Count; i++)
                {
                    if (arrivalsDepartures[i].BusStopId == startPurchaseDto.BusStopListStartId)
                    {
                        chooseTicketsParametersVM.DepartureTime = new DateTime(2000, 1, 1, arrivalsDepartures[i].DepartureTime.Value.Hour, arrivalsDepartures[i].DepartureTime.Value.Minute, 0);
                        if (i == 0)
                        {
                            IsFirst = true;
                        }
                        StartCounting = true;
                    }

                    if (arrivalsDepartures[i].BusStopId == startPurchaseDto.BusStopListEndId)
                    {
                        chooseTicketsParametersVM.ArrivalTime = new DateTime(2000, 1, 1, arrivalsDepartures[i].ArrivalTime.Value.Hour, arrivalsDepartures[i].ArrivalTime.Value.Minute, 0);
                        if (i == arrivalsDepartures.Count-1)
                        {
                            IsLast = true;
                        }
                        StopCounting = true;
                    }

                    if (StartCounting == true && StopCounting == false)
                    {
                        NumberOfBusStops++;
                    }
                    int xx = 1;
                }
                if (IsFirst == true && IsLast == true)
                {
                    chooseTicketsParametersVM.Price = _unitOfWork.TicketPrice.GetFirstOrDefault(tp => tp.Id == timetable.TicketPriceId).PricePerEntireRoute;
                    chooseTicketsParametersVM.IsEntireRoute = true;
                }
                else
                {
                    chooseTicketsParametersVM.Price = _unitOfWork.TicketPrice.GetFirstOrDefault(tp => tp.Id == timetable.TicketPriceId).PricePerSegment * NumberOfBusStops;
                    chooseTicketsParametersVM.IsEntireRoute = false;
                }
                chooseTicketsParametersVM.NumberOfBusStops = NumberOfBusStops;
                chooseTicketsParametersVM.ExtraBaggagePrice = StaticData.ExtraBaggagePrice;
                chooseTicketsParametersVM.NumberOfNormalTickets = 0;
                chooseTicketsParametersVM.NumberOfStudentsTickets = 0;
                chooseTicketsParametersVM.NumberOfExtraBaggages = 0;
                chooseTicketsParametersVM.Wehicle = wehicle;

                return View(chooseTicketsParametersVM);
            }
            else
            {
                return RedirectToAction(nameof(NotLogIn));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult EndPurchase(EndPurchaseDto endPurchaseDto)
        {
            if (User.IsInRole(StaticData.UserRole))
            {
                BusRoute busRoute = _unitOfWork.BusRoute.GetFirstOrDefault(br => br.Id == endPurchaseDto.BusRouteId);
                int NumberOfTickets = endPurchaseDto.NumberOfNormalTickets + endPurchaseDto.NumberOfStudentsTickets;

                //valid data from form
                if (NumberOfTickets > busRoute.AvailableSeats || endPurchaseDto.NumberOfExtraBaggages > NumberOfTickets || NumberOfTickets < 1)
                {
                    return RedirectToAction(nameof(PurchaseError));
                }

                busRoute.AvailableSeats -= NumberOfTickets;
                _unitOfWork.Save();

                Timetable timetable = _unitOfWork.Timetable.GetFirstOrDefault(t => t.Id == busRoute.TimetableId);
                TicketPrice ticketPrice = _unitOfWork.TicketPrice.GetFirstOrDefault(tp => tp.Id == timetable.TicketPriceId);

                float TicketsValue;
                if (endPurchaseDto.IsEntireRoute)
                {
                    TicketsValue = (float)(endPurchaseDto.NumberOfNormalTickets * ticketPrice.PricePerEntireRoute + 
                                    endPurchaseDto.NumberOfStudentsTickets * ticketPrice.PricePerEntireRoute * 0.5 + 
                                    endPurchaseDto.NumberOfExtraBaggages * StaticData.ExtraBaggagePrice); 
                }
                else
                {
                    TicketsValue = (float)(endPurchaseDto.NumberOfNormalTickets * ticketPrice.PricePerSegment * endPurchaseDto.NumberOfBusStops +
                                    endPurchaseDto.NumberOfStudentsTickets * ticketPrice.PricePerSegment * 0.5 * endPurchaseDto.NumberOfBusStops +
                                    endPurchaseDto.NumberOfExtraBaggages * StaticData.ExtraBaggagePrice);
                }

                Tickets ticket = new Tickets()
                {
                    NumberOfRegularTickets = endPurchaseDto.NumberOfNormalTickets,
                    NumberOfStudentsTickets = endPurchaseDto.NumberOfStudentsTickets,
                    NumberOfExtraBaggages = endPurchaseDto.NumberOfExtraBaggages,
                    BusRouteId = busRoute.Id,
                    Payment = new Payment()
                    {
                        Value = TicketsValue,
                        Status = StaticData.PaymentStatusNew
                    },
                    ApplicationUserId = _userManager.GetUserId(User),
                    PurchaseDates = DateTime.UtcNow,
                    Arrival = endPurchaseDto.ArrivalTime,
                    Departure = endPurchaseDto.DepartureTime,
                    EndBusStopName = endPurchaseDto.EndBusStopName,
                    StartBusStopName = endPurchaseDto.StartBusStopName

                };

                _unitOfWork.Tickets.Add(ticket);
                _unitOfWork.Save();

                var bankAccount = _unitOfWork.BankAccount.GetFirstOrDefault();
                var user = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == _userManager.GetUserId(User));
                EmailSender emailSender = new EmailSender();
                emailSender.SendEmailAsync(user.Email, "Kupiłeś bilet", $"<p><b>Witaj {user.FirstName}!</b></p>Właśnie kupiłeś bilet o id: {ticket.PaymentId}</p><p>Teraz wykonaj przelew:</p><p>Nazwa odbiorcy: {bankAccount.CompanyName}</p><p>Adres odbiorcy: {bankAccount.CompanyAddress}</p><p>Nr. konta: {bankAccount.AccountNumber}</p><p>Kwota: {ticket.Payment.Value} zł</p><br /><p>BusApplication Team</p>");

                EndOfPurchaseAndPaymentDataShowVM endOfPurchaseAndPaymentDataShowVM = new EndOfPurchaseAndPaymentDataShowVM()
                {
                    BankAccount = _unitOfWork.BankAccount.GetFirstOrDefault(),
                    TicketsValue = TicketsValue,
                    PaymentId = ticket.Payment.Id
                };

                return View(endOfPurchaseAndPaymentDataShowVM);
            }
            else
            {
                return RedirectToAction(nameof(NotLogIn));
            }
        }

        [HttpGet]
        public IActionResult NotLogIn()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PurchaseError()
        {
            return View();
        }


        #region API

        [HttpGet]
        public IActionResult ShowBusStopsList(ShowBusStopsListBetweenBusStopsVM showBusStopsListBetweenBusStopsVM)
        {
            IEnumerable<ArrivalsDepartures> arrivalsDeparturesByTimetableId = _unitOfWork.ArrivalsDepartures.GetAll
                (
                filter: ad => ad.TimetableId == showBusStopsListBetweenBusStopsVM.TimetableId,
                orderBy: ad => ad.OrderBy(o => o.ArrivalTime),
                includeProperties: "BusStop"
                );

            BusStopListBetweenBusStopsVM busStopListBetweenBusStopsVM = new BusStopListBetweenBusStopsVM();
            busStopListBetweenBusStopsVM.busStopBetweenBusStopsVMs = new List<BusStopBetweenBusStopsVM>();
            bool IsStartBusStop = false;
            foreach (var item in arrivalsDeparturesByTimetableId)
            {
                if (item.BusStopId == showBusStopsListBetweenBusStopsVM.BusStopListStartId)
                {
                    IsStartBusStop = true;
                }

                if (IsStartBusStop)
                {
                    BusStopBetweenBusStopsVM busStopBetweenBusStopsVM = new BusStopBetweenBusStopsVM();
                    busStopBetweenBusStopsVM.BusStopName = item.BusStop.Name;

                    string departure = "";
                    if (item.DepartureTime != null)
                    {
                        departure += item.DepartureTime.Value.Hour + ":";
                        if (item.DepartureTime.Value.Minute < 10)
                        {
                            departure += "0" + item.DepartureTime.Value.Minute;
                        }
                        else
                        {
                            departure += item.DepartureTime.Value.Minute;
                        }
                    }

                    string arrival = "";
                    if (item.ArrivalTime != null)
                    {
                        arrival += item.ArrivalTime.Value.Hour + ":";
                        if (item.ArrivalTime.Value.Minute < 10)
                        {
                            arrival += "0" + item.ArrivalTime.Value.Minute;
                        }
                        else
                        {
                            arrival += item.ArrivalTime.Value.Minute;
                        }
                    }

                    busStopBetweenBusStopsVM.ArrivalTime = arrival;
                    busStopBetweenBusStopsVM.DepartureTime = departure;

                    busStopListBetweenBusStopsVM.busStopBetweenBusStopsVMs.Add(busStopBetweenBusStopsVM);
                }

                if (item.BusStopId == showBusStopsListBetweenBusStopsVM.BusStopListEndId)
                {
                    break;
                }
            }

            return Json(new { data = busStopListBetweenBusStopsVM.busStopBetweenBusStopsVMs });
        }

        #endregion


    }
}
