using CodeYad_Blog_CoreLayer.DTOs;
using CodeYad_Blog_CoreLayer.DTOs.Users;
using CodeYad_Blog_CoreLayer.Services.Users;
using CodeYad_Blog_CoreLayer.Utilities;
using CodeYad_Blog_DataLayer.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;

namespace CodeYad_Blog_Web.Pages.Auth
{
    [ValidateAntiForgeryToken]
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userservice;

        public RegisterModel(IUserService userservice)
        {
            _userservice = userservice;
        }

        #region model
        [Required(ErrorMessage ="{0}را وارد کنید")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "{0}را وارد کنید")]
        [MinLength(6,ErrorMessage ="حداقل 6 کارکتر وارد کنید")]
        public string Password { get; set; }
        [Required(ErrorMessage = "{0}را وارد کنید")]
        public string Fullname { get; set; }
        #endregion
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = _userservice.RegisterUser(new UserRegisterDto()
            {   Fullname = Fullname,
                Password = Password,
                UserName = UserName
    

            });

            if (result.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError("UserName", result.Message);
                return Page();
            }
            return RedirectToPage("Login");



        }
    }
}
