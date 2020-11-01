using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusApplication.DataAccess.DTOs;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using BusApplication.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BusApplication.Areas.User.Controllers
{
    [Area("User")]
    [AllowAnonymous]
    public class TicketsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private UserManager<IdentityUser> _userManager;

        public TicketsController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.IsInRole(StaticData.UserRole))
            {
                return View();
            }

            return RedirectToAction(nameof(NotLogIn));
        }

        [HttpGet]
        public IActionResult NotLogIn()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            if (User.IsInRole(StaticData.UserRole))
            {
                Tickets ticket = _unitOfWork.Tickets.GetFirstOrDefault(filter: t => t.Id == Id, includeProperties: "Payment");
                ticket.BusRoute = _unitOfWork.BusRoute.GetFirstOrDefault(br => br.Id == ticket.BusRouteId);
                ticket.ApplicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(au => au.Id == ticket.ApplicationUserId);
                ticket.Payment.ApplicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(au => au.Id == ticket.Payment.ChangedBy);

                return View(ticket);
            }

            return RedirectToAction(nameof(NotLogIn));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult CancelTicket(int TicketId)
        {
            Tickets ticket = _unitOfWork.Tickets.GetFirstOrDefault(filter: t => t.Id == TicketId, includeProperties: "Payment");
            if (ticket.Payment.Status == StaticData.PaymentStatusNew)
            {
                ticket.Payment.Status = StaticData.PaymentStatusCanceled;
                ticket.Payment.CanceledDate = DateTime.Now;
                ticket.Payment.ChangedBy = _userManager.GetUserId(User);
                _unitOfWork.Payment.Update(ticket.Payment);
                _unitOfWork.Save();

                int NumberOfTickets = ticket.NumberOfRegularTickets + ticket.NumberOfStudentsTickets;
                ticket.BusRoute = _unitOfWork.BusRoute.GetFirstOrDefault(br => br.Id == ticket.BusRouteId);
                ticket.BusRoute.AvailableSeats += NumberOfTickets;
                _unitOfWork.BusRoute.Update(ticket.BusRoute);
                _unitOfWork.Save();

                var user = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == _userManager.GetUserId(User));
                EmailSender emailSender = new EmailSender();
                emailSender.SendEmailAsync(user.Email, "Anulowałeś bilet", $"<p><b>Witaj {user.FirstName}!</b></p>Właśnie anulowałeś bilet o id: {ticket.PaymentId}.</p><br /><p>BusApplication Team</>");

                return RedirectToAction(nameof(Details), new { Id = TicketId });
            }
            else
            {
                return NotFound();
            }
        }


        #region API

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            IEnumerable<Tickets> tickets = _unitOfWork.Tickets.GetAll(filter: t => t.ApplicationUserId == _userManager.GetUserId(User), includeProperties: "Payment");
            IList<ShowTicketsOfUserDto> showTicketsOfUserDtos = new List<ShowTicketsOfUserDto>();
            foreach (var item in tickets)
            {
                DateTime RouteDate = _unitOfWork.BusRoute.GetFirstOrDefault(br => br.Id == item.BusRouteId).RouteDate;
                DateTime DepartureTime = item.Departure;
                DateTime ArrivalTime = item.Arrival;
                string Arrival = "", Departure = "";

                Departure += item.Departure.Hour + ":";
                if (item.Departure.Minute < 10)
                {
                    Departure += "0" + item.Departure.Minute;
                }
                else
                {
                    Departure += item.Departure.Minute;
                }

                Arrival += item.Arrival.Hour + ":";
                if (item.Arrival.Minute < 10)
                {
                    Arrival += "0" + item.Arrival.Minute;
                }
                else
                {
                    Arrival += item.Arrival.Minute;
                }

                ShowTicketsOfUserDto showTicketsOfUserDto = new ShowTicketsOfUserDto()
                {
                    TicketId = item.Id,
                    Date = RouteDate.Day + "/" + RouteDate.Month + "/" + RouteDate.Year,
                    StartBusStopName = item.StartBusStopName,
                    EndBusStopName = item.EndBusStopName,
                    Departure = Departure,
                    Arrival = Arrival,
                    NumberOfNormalTickets = item.NumberOfRegularTickets,
                    NumberOfStudentsTickets = item.NumberOfStudentsTickets,
                    NumberOfExtraBaggages = item.NumberOfExtraBaggages,
                    PaymentStatus = item.Payment.Status
                };

                showTicketsOfUserDtos.Add(showTicketsOfUserDto);
            }

            return Json(new { data = showTicketsOfUserDtos });
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllPending()
        {
            IEnumerable<Tickets> tickets = _unitOfWork.Tickets.GetAll(filter: t => t.ApplicationUserId == _userManager.GetUserId(User), includeProperties: "Payment");
            IList<ShowTicketsOfUserDto> showTicketsOfUserDtos = new List<ShowTicketsOfUserDto>();
            foreach (var item in tickets)
            {
                if (item.Payment.Status == StaticData.PaymentStatusNew)
                {
                    DateTime RouteDate = _unitOfWork.BusRoute.GetFirstOrDefault(br => br.Id == item.BusRouteId).RouteDate;
                    DateTime DepartureTime = item.Departure;
                    DateTime ArrivalTime = item.Arrival;
                    string Arrival = "", Departure = "";

                    Departure += item.Departure.Hour + ":";
                    if (item.Departure.Minute < 10)
                    {
                        Departure += "0" + item.Departure.Minute;
                    }
                    else
                    {
                        Departure += item.Departure.Minute;
                    }

                    Arrival += item.Arrival.Hour + ":";
                    if (item.Arrival.Minute < 10)
                    {
                        Arrival += "0" + item.Arrival.Minute;
                    }
                    else
                    {
                        Arrival += item.Arrival.Minute;
                    }

                    ShowTicketsOfUserDto showTicketsOfUserDto = new ShowTicketsOfUserDto()
                    {
                        TicketId = item.Id,
                        Date = RouteDate.Day + "/" + RouteDate.Month + "/" + RouteDate.Year,
                        StartBusStopName = item.StartBusStopName,
                        EndBusStopName = item.EndBusStopName,
                        Departure = Departure,
                        Arrival = Arrival,
                        NumberOfNormalTickets = item.NumberOfRegularTickets,
                        NumberOfStudentsTickets = item.NumberOfStudentsTickets,
                        NumberOfExtraBaggages = item.NumberOfExtraBaggages,
                        PaymentStatus = item.Payment.Status
                    };

                    showTicketsOfUserDtos.Add(showTicketsOfUserDto);
                }
            }

            return Json(new { data = showTicketsOfUserDtos });
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllApproved()
        {
            IEnumerable<Tickets> tickets = _unitOfWork.Tickets.GetAll(filter: t => t.ApplicationUserId == _userManager.GetUserId(User), includeProperties: "Payment");
            IList<ShowTicketsOfUserDto> showTicketsOfUserDtos = new List<ShowTicketsOfUserDto>();
            foreach (var item in tickets)
            {
                if (item.Payment.Status == StaticData.PaymentStatusConfirmed)
                {
                    DateTime RouteDate = _unitOfWork.BusRoute.GetFirstOrDefault(br => br.Id == item.BusRouteId).RouteDate;
                    DateTime DepartureTime = item.Departure;
                    DateTime ArrivalTime = item.Arrival;
                    string Arrival = "", Departure = "";

                    Departure += item.Departure.Hour + ":";
                    if (item.Departure.Minute < 10)
                    {
                        Departure += "0" + item.Departure.Minute;
                    }
                    else
                    {
                        Departure += item.Departure.Minute;
                    }

                    Arrival += item.Arrival.Hour + ":";
                    if (item.Arrival.Minute < 10)
                    {
                        Arrival += "0" + item.Arrival.Minute;
                    }
                    else
                    {
                        Arrival += item.Arrival.Minute;
                    }

                    ShowTicketsOfUserDto showTicketsOfUserDto = new ShowTicketsOfUserDto()
                    {
                        TicketId = item.Id,
                        Date = RouteDate.Day + "/" + RouteDate.Month + "/" + RouteDate.Year,
                        StartBusStopName = item.StartBusStopName,
                        EndBusStopName = item.EndBusStopName,
                        Departure = Departure,
                        Arrival = Arrival,
                        NumberOfNormalTickets = item.NumberOfRegularTickets,
                        NumberOfStudentsTickets = item.NumberOfStudentsTickets,
                        NumberOfExtraBaggages = item.NumberOfExtraBaggages,
                        PaymentStatus = item.Payment.Status
                    };

                    showTicketsOfUserDtos.Add(showTicketsOfUserDto);
                }
            }

            return Json(new { data = showTicketsOfUserDtos });
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllCanceled()
        {
            IEnumerable<Tickets> tickets = _unitOfWork.Tickets.GetAll(filter: t => t.ApplicationUserId == _userManager.GetUserId(User), includeProperties: "Payment");
            IList<ShowTicketsOfUserDto> showTicketsOfUserDtos = new List<ShowTicketsOfUserDto>();
            foreach (var item in tickets)
            {
                if (item.Payment.Status == StaticData.PaymentStatusCanceled)
                {
                    DateTime RouteDate = _unitOfWork.BusRoute.GetFirstOrDefault(br => br.Id == item.BusRouteId).RouteDate;
                    DateTime DepartureTime = item.Departure;
                    DateTime ArrivalTime = item.Arrival;
                    string Arrival = "", Departure = "";

                    Departure += item.Departure.Hour + ":";
                    if (item.Departure.Minute < 10)
                    {
                        Departure += "0" + item.Departure.Minute;
                    }
                    else
                    {
                        Departure += item.Departure.Minute;
                    }

                    Arrival += item.Arrival.Hour + ":";
                    if (item.Arrival.Minute < 10)
                    {
                        Arrival += "0" + item.Arrival.Minute;
                    }
                    else
                    {
                        Arrival += item.Arrival.Minute;
                    }

                    ShowTicketsOfUserDto showTicketsOfUserDto = new ShowTicketsOfUserDto()
                    {
                        TicketId = item.Id,
                        Date = RouteDate.Day + "/" + RouteDate.Month + "/" + RouteDate.Year,
                        StartBusStopName = item.StartBusStopName,
                        EndBusStopName = item.EndBusStopName,
                        Departure = Departure,
                        Arrival = Arrival,
                        NumberOfNormalTickets = item.NumberOfRegularTickets,
                        NumberOfStudentsTickets = item.NumberOfStudentsTickets,
                        NumberOfExtraBaggages = item.NumberOfExtraBaggages,
                        PaymentStatus = item.Payment.Status
                    };

                    showTicketsOfUserDtos.Add(showTicketsOfUserDto);
                }
            }

            return Json(new { data = showTicketsOfUserDtos });
        }


        #endregion

    }
}
