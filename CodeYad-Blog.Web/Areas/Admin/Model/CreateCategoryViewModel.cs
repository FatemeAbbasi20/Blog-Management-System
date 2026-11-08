using CodeYad_Blog_CoreLayer.DTOs.Categories;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Codeyad_Blog.Web.Areas.Admin.Model
{
    public class CreateCategoryViewModel
    {
        [Display(Name = "Slug")]
        [Required(ErrorMessage = "{0}را وارد کنید")]
        public string Slug { get; set; }
        [DisplayName("Title")]
        [Required(ErrorMessage = "{0}را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "MetaTag(با- از هم جدا کنید)")]
        public string MetaTag { get; set; }
        [DataType(DataType.MultilineText)]
        public string MetaDescription { get; set; }
        public int? ParentId { get; set; }

        public CreateCategoryDto MapToDTO()
        {
            return new CreateCategoryDto()
            {
                MetaDescription = MetaDescription,
                MetaTag = MetaTag,
                ParentId = ParentId,
                Slug = Slug,
                Title = Title,
             
            };


        }
    }
    }
