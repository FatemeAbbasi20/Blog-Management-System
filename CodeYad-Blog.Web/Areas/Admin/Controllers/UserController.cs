using CodeYad_Blog_CoreLayer.DTOs.Users;
using CodeYad_Blog_CoreLayer.Services.Users;
using CodeYad_Blog_CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Codeyad_Blog.Web.Areas.Admin.Controllers
{
    public class UserController : AdminControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(int PageId=1)
        {
           
            return View(_userService.GetUsersByFilter(10, PageId));
        }

        public IActionResult ShowEditModel(int userId)
        {
           var user= _userService.GetUserById(userId);
            return PartialView("_EditUser",new EditUserDto() { FullName=user.Fullname,Role=user.Role,UserId=user.UserId});

        }
        [HttpPost]
        public IActionResult Edit(EditUserDto EditModel)
        {
          var result=  _userService.EditUser(EditModel);
            if (result.Status != OperationResultStatus.Success)
            {
                ErrorAlert(result.Message);
                return RedirectToAction("index");
            }
            return (RedirectAndShowAlert(result, RedirectToAction("index")));
        }
    

    }
}
