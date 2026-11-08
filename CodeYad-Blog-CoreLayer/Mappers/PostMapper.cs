using CodeYad_Blog.DataLayer.Entities;
using CodeYad_Blog_CoreLayer.DTOs.Categories;
using CodeYad_Blog_CoreLayer.DTOs.Posts;
using CodeYad_Blog_CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.Mappers
{
    public class PostMapper
    {
        public static Post MapCreateDtoToPost(CreatePostDto dto)
        {
            return new Post()
            {
                Title = dto.Title,
                Description = dto.Description,
                slug=dto.slug.ToSlug(),
                Visit=0,
                IsDelete=false,
                CategoryId=dto.CategoryId,
                UserId=dto.UserId,
                SubCategoryId=dto.SubCategoryId,
                IsSpecial=dto.IsSpecial,
            };
        }

        public static Post EditDtoToPost(EditPostDto dto,Post post)
        {
            post.Description = dto.Description;
            post.slug = dto.slug.ToSlug(); 
            post.CategoryId=dto.CategoryId;
                post.Title = dto.Title;
            post.SubCategoryId=dto.SubCategoryId;
           post.IsSpecial=dto.IsSpecial;
            return post; 
        }
        public static PostDto MapToDto(Post post)
        {
            return new PostDto()
            {
                Title = post.Title,
                Description = post.Description,
                slug = post.slug,
                CategoryId = post.CategoryId,
                SubCategoryId = post.SubCategoryId,
                UserFullName = post.User?.Fullname,
                ImageName = post.ImageName,
                Category = post.Category==null?null:CategoryMapper.Mapper(post.Category),
                SubCategory = post.SubCategory==null?null: CategoryMapper.Mapper(post.SubCategory),
                PostId= post.Id,
                Visit=post.Visit,
                IsSpecial=post.IsSpecial,
                CreationDate=post.creationTime
            };
        }


    }
}
