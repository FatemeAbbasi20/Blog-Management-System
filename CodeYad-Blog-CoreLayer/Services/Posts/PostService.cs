using CodeYad_Blog.DataLayer.Entities;
using CodeYad_Blog_CoreLayer.DTOs.Posts;
using CodeYad_Blog_CoreLayer.Mappers;
using CodeYad_Blog_CoreLayer.Services.FileManager;
using CodeYad_Blog_CoreLayer.Utilities;
using CodeYad_Blog_DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly BlogContext _context;
        private readonly IFileManager _fileManager;
        public PostService(BlogContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        public OperationResult CreatePost(CreatePostDto Command)
        {
            if (Command.ImageFile==null) {
                return OperationResult.Error(); }

            var post= PostMapper.MapCreateDtoToPost(Command);

            if (IsSlugExist(post.slug))
            {
                return OperationResult.NotFound("slug is existed");
            }
            post.ImageName = _fileManager.SaveImageAndReturnImageName(Command.ImageFile, Directiones.PostImage);
            _context.Posts.Add(post);
            _context.SaveChanges();
            return OperationResult.Success();

        }

        public OperationResult EditPost(EditPostDto Command)
        {   
           var post= _context.Posts.FirstOrDefault(i => i.Id == Command.PostId);
        
            if (post == null)
            {
                return OperationResult.NotFound();
            }
            var oldImage = post.ImageName;
            var newSlug = Command.slug.ToSlug();
           if(post.slug!=newSlug)
            if (IsSlugExist(newSlug))
            
                return OperationResult.NotFound("slug is existed");
            
            if (Command.ImageFile != null)
            {
                post.ImageName = _fileManager.SaveFileAndReturnName(Command.ImageFile, Directiones.PostImage);
            }
            post = PostMapper.EditDtoToPost(Command,post);
            _context.SaveChanges();
            if (Command.ImageFile != null)
            {
              _fileManager.DeleteFile(oldImage, Directiones.PostImage);
            }
            return OperationResult.Success();
        }

        public List<PostDto> GetPopularPosts()
        {
         return _context.Posts.OrderByDescending(i=>i.Visit).Take(4).Select(post=>PostMapper.MapToDto(post)).ToList();
        }

        public PostFilterDto GetPostByFilter(PostFilterDto.PostFilterParams filterParams)
        {
            var result=_context.Posts.Include(i=>i.Category).Include(f=>f.SubCategory).OrderByDescending(u=>u.creationTime).AsQueryable();
            if (!String.IsNullOrWhiteSpace(filterParams.CategorySlug))
              result=  result.Where(f => f.Category.Slug == filterParams.CategorySlug||f.SubCategory.Slug==filterParams.CategorySlug);
            if (!String.IsNullOrWhiteSpace(filterParams.Title))
              result=  result.Where(f => f.Title.Contains(filterParams.Title));
            var Skip = (filterParams.PageId - 1 )* filterParams.Take;

           var model= new PostFilterDto()
            {
                Posts = result.Skip(Skip).Take(filterParams.Take).Select(post=>PostMapper.MapToDto(post)).ToList(),
                FilterParams= filterParams
            };
            model.GeneratePaging(result,filterParams.Take,filterParams.PageId);
            return model;
        }

        public PostDto GetPostById(int PostId)
        {
          var post=  _context.Posts.Include(u => u.Category).Include(u => u.SubCategory).FirstOrDefault(o => o.Id == PostId);
          return PostMapper.MapToDto(post);
            
        }

        public PostDto GetPostBySlug(string slug)
        {      
            var post = _context.Posts.Include(u=>u.Category).Include(u => u.SubCategory).Include(u => u.User)
                .FirstOrDefault(o => o.slug == slug);
            if (post == null)
                return null;
            return PostMapper.MapToDto(post);
        }

        public List<PostDto> GetRealatedPosts(int CategoryId)
        {
            return _context.Posts.Where(i=>i.CategoryId== CategoryId||i.SubCategoryId== CategoryId)
                .OrderByDescending(u=>u.creationTime).Take(6).Select(post=> PostMapper.MapToDto(post)).ToList();
           
        }

        public void IncreaseVisit(int PostId)
        {
            var post= _context.Posts.First(u => u.Id == PostId);
            post.Visit+=1;
            _context.SaveChanges();
        }

        public bool IsSlugExist(string Slug)
        {
          return  _context.Posts.Any(u => u.slug == Slug.ToSlug());
          
        }
    }
}
