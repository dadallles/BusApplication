﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using BusApplication.DataAccess.Repository.IRepository;
using BusApplication.Models;

namespace BusApplication.Areas.Identity.Pages.Account.Manage
{
    public partial class EmailModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork _unitOfWork;

        public EmailModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IEmailSender emailSender,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Nowy email")]
            public string NewEmail { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var email = await _userManager.GetEmailAsync(user);
            Email = email;

            Input = new InputModel
            {
                NewEmail = email,
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Błąd ładowania użytkownika o  ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostChangeEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Błąd ładowania użytkownika o  ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.NewEmail != email)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                var userApp = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == userId);

                if (userApp != null)
                {
                    IEnumerable<ApplicationUser> applicationUsers = _unitOfWork.ApplicationUser.GetAll(u => u.Id != userId);
                    foreach (var item in applicationUsers)
                    {
                        if (item.Email == Input.NewEmail)
                        {
                            StatusMessage = "Istnieje już profil o takim emailu!";
                            return RedirectToPage();
                        }
                    }

                    userApp.Email = Input.NewEmail;
                    _unitOfWork.Save();
                }

                //var code = await _userManager.GenerateChangeEmailTokenAsync(user, Input.NewEmail);
                //var callbackUrl = Url.Page(
                //    "/Account/ConfirmEmailChange",
                //    pageHandler: null,
                //    values: new { userId = userId, email = Input.NewEmail, code = code },
                //    protocol: Request.Scheme);
                //await _emailSender.SendEmailAsync(
                //    Input.NewEmail,
                //    "Aktywuj swoje konto", 
                //    $"<p><b>Witaj {user.UserName}!</b></p><p>Aktywuj swoje konto <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>klikając tutaj</a>.</p>");

                //StatusMessage = "Wysłano link aktywacyjny.";

                StatusMessage = "Zaktualizowano email!";
                return RedirectToPage();
            }

            StatusMessage = "Nie zmieniono emaila.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Błąd ładowania użytkownika o ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Aktywuj swoje konto",
                $"<p><b>Witaj {user.UserName}!</b></p><p>Aktywuj swoje konto <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>klikając tutaj</a>.</p>");

            StatusMessage = "Wysłano link aktywacyjny";
            return RedirectToPage();
        }
    }
}
