using CodeYad_Blog.DataLayer.Entities;
using CodeYad_Blog_CoreLayer.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.Mappers
{
    public class CategoryMapper
    { 
        public static CategoryDto Mapper(Category category)
        {
            return new CategoryDto()
            {
                Title = category.Title,
                Slug = category.Slug,
                MetaDescription = category.MetaDescription,
                MetaTag = category.MetaTag,
                Id = category.Id,
                ParentId= category.ParentId,

            };
        }



    }
}
