using CodeYad_Blog_CoreLayer.DTOs;
using CodeYad_Blog_CoreLayer.DTOs.Users;
using CodeYad_Blog_CoreLayer.Services.Users;
using CodeYad_Blog_CoreLayer.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CodeYad_Blog_Web.Pages.Auth
{
    [ValidateAntiForgeryToken]
    public class LoginModel : PageModel
    {
        private IUserService _userService;
        #region model
        [BindProperty]
        [Required(ErrorMessage = "{0}را وارد کنید")]

        public string UserName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "{0}را وارد کنید")]
        [MinLength(6,ErrorMessage ="حداقل 6 کارکتر وارد کنید")]

        public string Password { get; set; }
        #endregion

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user= _userService.LoginUser(new LoginUserDto()
            {
                Password=Password,UserName=UserName
            });

            if (user == null)
            {
                ModelState.AddModelError("UserName", "کاربر با مشخصات وراد شده یافت نشد ");
                return Page();
            }

            List<Claim> Claims = new List<Claim>() 
            { new Claim("test","test"),
            new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
             new Claim(ClaimTypes.Name,user.Fullname),
             new Claim(ClaimTypes.Role,user.Role.ToString()),
            };
            var identity= new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = true,
            };
            HttpContext.SignInAsync(claimPrincipal, properties);
            return RedirectToPage("../Index");

        }
    }
}
