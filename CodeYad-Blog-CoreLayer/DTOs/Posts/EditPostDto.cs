using Microsoft.AspNetCore.Http;

namespace CodeYad_Blog_CoreLayer.DTOs.Posts
{
    public class EditPostDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string slug { get; set; }
        public int CategoryId { get; set; }
        public int PostId { get; set; }
        public int? SubCategoryId { get; set; }
        public IFormFile ImageFile { get; set; }
        public bool IsSpecial { get; set; }
    }

}
