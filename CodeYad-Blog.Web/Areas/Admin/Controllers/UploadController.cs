using CodeYad_Blog_CoreLayer.Services.FileManager;
using CodeYad_Blog_CoreLayer.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codeyad_Blog.Web.Areas.Admin.Controllers {

    public class UploadController : Controller
    {
        private readonly IFileManager _fileManager;

        public UploadController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        [Route("/Upload/Article")]
        [Authorize]
        public IActionResult Article(IFormFile upload)
        {
            if (upload == null)
                return BadRequest();
            var fileName = _fileManager.SaveFileAndReturnName(upload, Directiones.PostContentImage);
            return Json(new { Uploaded = true, url = Directiones.GetPostContentImage(fileName) });
        }
    }    
}
