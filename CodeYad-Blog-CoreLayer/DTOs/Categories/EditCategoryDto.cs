namespace CodeYad_Blog_CoreLayer.DTOs.Categories
{
    public class EditCategoryDto
    {
        public string Slug { get; set; }
        public string Title { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public int Id { get; set; }
    }
}