using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BusApplication.Models;
using BusApplication.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace BusApplication.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Pole nie może być puste")]
            [EmailAddress(ErrorMessage = "Błędny e-mail")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Pole nie może być puste")]
            [StringLength(100, ErrorMessage = "{0} musi mieć pomiędzy {2} - {1} znaków.", MinimumLength = 8)]
            [DataType(DataType.Password)]
            [Display(Name = "Hasło")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Potwierdź hasło")]
            [Compare("Password", ErrorMessage = "Podane hasła są rózne.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Nazwa użytkownika")]
            [Required(ErrorMessage = "Pole nie może być puste")]
            public string UserName { get; set; }

            [Display(Name = "Imię")]
            [Required(ErrorMessage = "Pole nie może być puste")]
            public string FirstName { get; set; }

            [Display(Name = "Nazwisko")]
            [Required(ErrorMessage = "Pole nie może być puste")]
            public string LastName { get; set; }

            [Display(Name = "Miasto")]
            [Required(ErrorMessage = "Pole nie może być puste")]
            public string City { get; set; }

            [Display(Name = "Kod pocztowy")]
            [Required(ErrorMessage = "Pole nie może być puste")]
            [RegularExpression(@"^[0-9][0-9]-[0-9][0-9][0-9]", ErrorMessage = "Błędny kod pocztowy.")]
            public string PostalCode { get; set; }

            [Display(Name = "Ulica")]
            [Required(ErrorMessage = "Pole nie może być puste")]
            public string Street { get; set; }

            [Display(Name = "Nr. domu")]
            [Required(ErrorMessage = "Pole nie może być puste")]
            public int HouseNumber { get; set; }

            [Display(Name = "Nr. mieszkania")]
            public int? FlatNumber { get; set; }

            [Display(Name = "Telefon")]
            [Required(ErrorMessage = "Pole nie może być puste")]
            [RegularExpression(@"^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]", ErrorMessage = "Błędny numer.")]
            public string PhoneNumber { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                //create user
                var user = new ApplicationUser 
                { 
                    UserName = Input.UserName, 
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    City = Input.City,
                    PostalCode = Input.PostalCode,
                    Street = Input.Street,
                    HouseNumber = Input.HouseNumber,
                    FlatNumber = Input.FlatNumber,
                    PhoneNumber = Input.PhoneNumber
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    //add user role to new user
                    await _userManager.AddToRoleAsync(user, StaticData.UserRole);

                    _logger.LogInformation("Utworzono nowe konto.");

                    //email comfirmation
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Aktywuj swoje konto",  $"<p><b>Witaj {user.FirstName}!</b></p><p>Aktywuj swoje konto <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>klikając tutaj</a>.</p>");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        //autmatic log in
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
