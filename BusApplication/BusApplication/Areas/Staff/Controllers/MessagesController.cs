using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;
using BusApplication.Models.ViewModels;
using BusApplication.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MimeKit;

namespace BusApplication.Areas.Staff.Controllers
{
    [Area("Staff")]
    [Authorize(Roles = StaticData.EmployeeAndAdminRoleString)]
    public class MessagesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessagesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            MessageAnswer messageAnswer = new MessageAnswer();

            if (id == null)
            {
                return View(nameof(Index));
            }

            messageAnswer.Message = _unitOfWork.Messages.Get(id.GetValueOrDefault());
            messageAnswer.Answer = "";

            if (messageAnswer.Message == null)
            {
                return NotFound();
            }

            return View(messageAnswer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMail(MessageAnswer messageAnswer)
        {
            messageAnswer.Answer += "<br /><br />Buss Application Team";
            messageAnswer.Message.Title = "ODPOWIEDŹ - " + messageAnswer.Message.Title;

            EmailSender emailSender = new EmailSender();
            emailSender.SendEmailAsync(messageAnswer.Message.Mail, messageAnswer.Message.Title, messageAnswer.Answer);

            _unitOfWork.Messages.StatusAsRead(messageAnswer.Message.Id);

            return View(nameof(Index));
        }



        #region API Calls

        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Messages.GetAll() });
        }

        public IActionResult GetAllPending()
        {
            return Json(new { data = _unitOfWork.Messages.GetAll(filter: m => m.Status == false) });
        }

        public IActionResult GetAllApproved()
        {
            return Json(new { data = _unitOfWork.Messages.GetAll(filter: m => m.Status == true) });
        }

        #endregion

    }
}
