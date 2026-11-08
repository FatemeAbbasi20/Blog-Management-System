using CodeYad_Blog_CoreLayer.DTOs;
using CodeYad_Blog_CoreLayer.DTOs.Posts;
using CodeYad_Blog_CoreLayer.Services;
using CodeYad_Blog_CoreLayer.Services.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeYad_Blog.Web.Pages
{
     
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPostService _postService;
        private readonly IMainPageService _mainPageService;

        public IndexModel(ILogger<IndexModel> logger, IMainPageService mainPageService, IPostService postService)
        {
            _logger = logger;
            _mainPageService = mainPageService;
            _postService = postService;
        }


        public MainPageDto MainPageData { get; set; }

        public void OnGet()
        {
            MainPageData = _mainPageService.GetData();
           
        }
        public IActionResult OnGetLatestPosts(string categorySlug)
        {
            var Filter = _postService.GetPostByFilter(new PostFilterDto.PostFilterParams(){
                CategorySlug = categorySlug,PageId = 1,Take=6
        });
            return Partial("_LatestPosts", Filter.Posts);
        }
        public IActionResult OnGetPopularPosts()
        {
            return Partial("_PopularPosts", _postService.GetPopularPosts());

        }
    }
}
