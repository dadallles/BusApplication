using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BusApplication.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusApplication.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
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

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var userId = _userManager.GetUserId(User);
            var userApp = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == userId);

            Username = userName;

            Input = new InputModel
            {
                FirstName = userApp.FirstName,
                LastName = userApp.LastName,
                City = userApp.City,
                PostalCode = userApp.PostalCode,
                Street = userApp.Street,
                HouseNumber = userApp.HouseNumber,
                FlatNumber = userApp.FlatNumber,
                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Błąd ładowania użytkownika o ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
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

            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            //if (Input.PhoneNumber != phoneNumber)
            //{
            //    var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
            //    if (!setPhoneResult.Succeeded)
            //    {
            //        StatusMessage = "Błąd.";
            //        return RedirectToPage();
            //    }
            //}

            var userId = _userManager.GetUserId(User);
            var userApp = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == userId);
            userApp.FirstName = Input.FirstName;
            userApp.LastName = Input.LastName;
            userApp.City = Input.City;
            userApp.PostalCode = Input.PostalCode;
            userApp.Street = Input.Street;
            userApp.HouseNumber = Input.HouseNumber;
            userApp.FlatNumber = Input.FlatNumber;
            userApp.PhoneNumber = Input.PhoneNumber;
            _unitOfWork.Save();

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Zaktualizowano dane!";
            return RedirectToPage();
        }
    }
}
