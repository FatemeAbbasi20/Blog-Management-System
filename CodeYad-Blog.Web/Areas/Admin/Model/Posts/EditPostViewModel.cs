using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Codeyad_Blog.Web.Areas.Admin.Model.Posts
{
    public class EditPostViewModel
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0}را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "{0}را وارد کنید")]
        [UIHint("ckeditor4")]
        public string Description { get; set; }
        [Display(Name = "slug")]
        [Required(ErrorMessage = "{0}را وارد کنید")]
        public string slug { get; set; }
        [Display(Name = "انتخاب دسته بندی")]
        [Required(ErrorMessage = "{0}را وارد کنید")]
        public int CategoryId { get; set; }
        [Display(Name = "انتخاب دسته بندی")]
        [Required(ErrorMessage = "{0}را وارد کنید")]
        public int? SubCategoryId { get; set; }

        [Display(Name = "عکس")]
       
        public IFormFile ImageFile { get; set; }
        [Display(Name ="پست ویژه")]
        public bool IsSpecial { get; set; }

    }
}
