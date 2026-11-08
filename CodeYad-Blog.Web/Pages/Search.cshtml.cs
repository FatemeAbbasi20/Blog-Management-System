using CodeYad_Blog_CoreLayer.DTOs.Posts;
using CodeYad_Blog_CoreLayer.Services.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static CodeYad_Blog_CoreLayer.DTOs.Posts.PostFilterDto;

namespace Codeyad_Blog.Web.Pages.Shared
{
    public class SearchModel : PageModel
    {
        private readonly IPostService _postService;

        public SearchModel(IPostService postService)
        {
            _postService = postService;
        }
        public PostFilterDto Filter{ get; set; }

        public void OnGet(int pageId=1,string categorySlug=null,string q=null)
        {
            Filter= _postService.GetPostByFilter(new PostFilterParams()
            {
             Take=1,PageId=pageId,CategorySlug=categorySlug,Title=q
            });
        }
        public IActionResult OnGetPagination(int pageId = 1, string categorySlug = null, string q = null)
        {
            var Model = _postService.GetPostByFilter(new PostFilterParams()
            {
                Take = 1,
                PageId = pageId,
                CategorySlug = categorySlug,
                Title = q
            });
            return Partial("_SearchView", Model);
        }
    }
}
