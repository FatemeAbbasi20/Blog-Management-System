using CodeYad_Blog.DataLayer.Entities;
using CodeYad_Blog_CoreLayer.DTOs.Categories;
using CodeYad_Blog_CoreLayer.Mappers;
using CodeYad_Blog_CoreLayer.Utilities;
using CodeYad_Blog_DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogContext _context;

        public CategoryService(BlogContext context)
        {
            _context = context;
        }

        public OperationResult CreateCategory(CreateCategoryDto Command)
        {
            if (IsSlugExist(Command.Slug))
                return OperationResult.Error("slug is existed");

            var catgory = new Category()
            {
                Title = Command.Title,
                Slug = Command.Slug.ToSlug(),
                MetaDescription = Command.MetaDescription,
                MetaTag = Command.MetaTag,
                ParentId = Command.ParentId,
            };
            _context.Categories.Add(catgory);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult EditCategory(EditCategoryDto Command)
        {
            var category = _context.Categories.FirstOrDefault(u => u.Id == Command.Id);

            if (category == null)
            
                return OperationResult.NotFound();
            
            if (Command.Slug.ToSlug() != category.Slug)
                if (IsSlugExist(Command.Slug))
                    return OperationResult.Error("slug is existed");
            category.Title =Command.Title;
            category.Slug =Command.Slug.ToSlug();
            category.MetaDescription =Command.MetaDescription;
            category.MetaTag =Command.MetaTag;             
            _context.SaveChanges();
            return OperationResult.Success();

        }

        public List<CategoryDto> GetAllCategory()
        {
            return _context.Categories.Select(category => CategoryMapper.Mapper(category)).ToList();
                 
        }
        public List<CategoryDto> GetChildCategoryies(int parentid)
        {
            return _context.Categories.Where(u => u.ParentId == parentid).Select(category => CategoryMapper.Mapper(category)).ToList();

        }

        public CategoryDto GetCategoryBy(int id)
        { 
          var category=_context.Categories.FirstOrDefault(c=>c.Id == id);
            if (category == null) 
                return null;
            return CategoryMapper.Mapper(category);
            //var cd = new CategoryDto();
            //category.Title=cd.Title;
        }

        public CategoryDto GetCategoryBy(string slug)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Slug == slug);
            if (category == null)
                return null;
            return CategoryMapper.Mapper(category);

        }

        public bool IsSlugExist(string slug)
        {
           return _context.Categories.Any(c => c.Slug == slug.ToSlug());
        }
    }
}
