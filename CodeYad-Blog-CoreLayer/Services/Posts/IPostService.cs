using CodeYad_Blog_CoreLayer.DTOs.Posts;
using CodeYad_Blog_CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CodeYad_Blog_CoreLayer.DTOs.Posts.PostFilterDto;

namespace CodeYad_Blog_CoreLayer.Services.Posts
{
    public interface IPostService
    {
        OperationResult CreatePost(CreatePostDto Command);
        OperationResult EditPost(EditPostDto Command);
        PostDto GetPostById(int PostId);
        PostDto GetPostBySlug(string slug);
        bool IsSlugExist(string Slug);
        PostFilterDto GetPostByFilter(PostFilterParams filterParams);
        List<PostDto> GetRealatedPosts(int CategoryId);
        List<PostDto> GetPopularPosts();
        void IncreaseVisit(int PostId);

    }
}
