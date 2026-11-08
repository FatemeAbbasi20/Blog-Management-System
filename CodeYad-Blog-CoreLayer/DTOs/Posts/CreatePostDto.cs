using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.DTOs.Posts
{
    public class CreatePostDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string slug { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int UserId { get; set; }
        public IFormFile ImageFile { get; set; }
        public bool IsSpecial { get; set; }


    }

}
