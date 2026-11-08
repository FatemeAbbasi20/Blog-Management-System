using CodeYad_Blog_CoreLayer.DTOs.Categories;
using Microsoft.VisualBasic;
using System;

namespace CodeYad_Blog_CoreLayer.DTOs.Posts
{
    public class PostDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string slug { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public string UserFullName { get; set; }
        public string ImageName { get; set; }
        public int Visit { get; set; }
        public int PostId { get; set; }
        public CategoryDto Category { get; set; }
        public CategoryDto SubCategory { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsSpecial { get; set; }
    }

}
