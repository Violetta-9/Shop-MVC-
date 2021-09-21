using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Shop.Domain.Models;

namespace Shop.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ShopUser> _signInManager;//сервис позволяет аутентифицировать пользователя и устанавливать или удалять его куки.
        private readonly UserManager<ShopUser> _userManager;//сервис по управлению пользователям
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ShopUser> userManager,
            SignInManager<ShopUser> signInManager,
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


        public class InputModel
        {
            [Required]
            [StringLength(10)]
            [Display(Name = "Имя")]
            public string FirstName { get; set; }
            [Required]
            [StringLength(10)]
            [Display(Name = "Фамилия")]
            public string LastName { get; set; }

            [Required]
            [StringLength(10)]
            [Display(Name = "Логин")]
            public string UserName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Адрес")]
            public string Addres { get; set; }

            [Required]
            [Display(Name = "Номер телефона")]
            [Phone]
            public string Phone { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "{0} должен содержать не менее {2} и не более {1} символов.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "Пароль и пароль подтверждения не совпадают.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl; 
        }

      
    }
}
