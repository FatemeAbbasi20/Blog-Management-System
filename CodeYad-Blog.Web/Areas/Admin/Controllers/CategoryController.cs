using Codeyad_Blog.Web.Areas.Admin.Model;
using CodeYad_Blog_CoreLayer.DTOs.Categories;
using CodeYad_Blog_CoreLayer.Services.Categories;
using CodeYad_Blog_CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Codeyad_Blog.Web.Areas.Admin.Controllers
{
   
    public class CategoryController : AdminControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategory());
        }

        [Route("/admin/category/add/{parentId?}")]
        public IActionResult Add(int?parentId)
        {

            return View();
        }
        [HttpPost("/admin/category/add/{parentId?}")]
    
        public IActionResult Add(int?parentId,CreateCategoryViewModel CreateviewModel)
        {
            CreateviewModel.ParentId = parentId;
            var result = _categoryService.CreateCategory(CreateviewModel.MapToDTO());
            //if (result.Status != OperationResultStatus.Success)
            //{

            //    ModelState.AddModelError(nameof(CreateviewModel.Slug), result.Message);
            //    return View();
            //}
            //SuccessAlert();
            //return RedirectToAction("index");
            return RedirectAndShowAlert(result, RedirectToAction("index"));
        }


        public IActionResult Edit(int id)
        {
            var Category = _categoryService.GetCategoryBy(id);
            if (Category == null)
            {
                return RedirectToAction("Index");
            }
            var model = new EditCategoryViewModel()
            {
                Slug = Category.Slug,
                MetaDescription = Category.MetaDescription,
                MetaTag = Category.MetaTag,
                Title = Category.Title,
                Id = Category.Id
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id, EditCategoryViewModel Editmodel)
        {
            var result = _categoryService.EditCategory(new EditCategoryDto()
            {
                Id = Editmodel.Id,
                Slug = Editmodel.Slug,
                MetaDescription = Editmodel.MetaDescription,
                MetaTag = Editmodel.MetaTag,
                Title = Editmodel.Title
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(Editmodel.Slug), result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }
        public IActionResult GetChildCategories(int parentid)
        {
            var category = _categoryService.GetChildCategoryies(parentid);
            return new JsonResult(category);

        }


    } 







    
}
