using Codeyad_Blog.Web.Areas.Admin.Model.Posts;
using CodeYad_Blog_CoreLayer.DTOs.Posts;
using CodeYad_Blog_CoreLayer.Services.Categories;
using CodeYad_Blog_CoreLayer.Services.Posts;
using CodeYad_Blog_CoreLayer.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CodeYad_Blog_CoreLayer.DTOs.Posts.PostFilterDto;


namespace Codeyad_Blog.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Policy ="AdminPolicy")]
    public class PostController : AdminControllerBase
    {
        private readonly IPostService _service;
        private readonly ICategoryService _categoryService;
        public PostController(IPostService service)
        {
            _service = service;
        }

        public IActionResult Index(int pageId=1,string title="",string categorySlug="")
        {
            var param=new PostFilterParams() { Take=2,PageId=pageId,Title=title,CategorySlug=categorySlug};
            var model=_service.GetPostByFilter(param);
            return View(model);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CreatePostViewModel createViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = _service.CreatePost(new CreatePostDto()
            {
                CategoryId = createViewModel.CategoryId,
                slug = createViewModel.slug,
                Description = createViewModel.Description,
                Title = createViewModel.Title,
                SubCategoryId = createViewModel.SubCategoryId==0?null:createViewModel.SubCategoryId,
                ImageFile = createViewModel.ImageFile,
                UserId = User.GetUserId(),
                IsSpecial=createViewModel.IsSpecial

            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(createViewModel.slug,result.Message);
            }
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var post = _service.GetPostById(id);
            var model = new EditPostViewModel()
            {
                Title=post.Title, Description=post.Description,slug=post.slug,CategoryId=post.CategoryId,
                SubCategoryId=post.SubCategoryId,IsSpecial=post.IsSpecial,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,EditPostViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = _service.EditPost(new EditPostDto()
            {
                CategoryId = editViewModel.CategoryId,
                slug = editViewModel.slug,
                Description = editViewModel.Description,
                Title = editViewModel.Title,
                SubCategoryId = editViewModel.SubCategoryId == 0 ? null : editViewModel.SubCategoryId,
                ImageFile = editViewModel.ImageFile,
                PostId=id,
                IsSpecial=editViewModel.IsSpecial,
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(editViewModel.slug, result.Message);
            }
            return RedirectToAction("Index");
        }

    }
}
