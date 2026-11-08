using Microsoft.AspNetCore.Mvc;
using System;

namespace Codeyad_Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : AdminControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
