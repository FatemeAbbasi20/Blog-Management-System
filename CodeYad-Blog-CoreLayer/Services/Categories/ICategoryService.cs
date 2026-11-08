using CodeYad_Blog_CoreLayer.DTOs.Categories;
using CodeYad_Blog_CoreLayer.DTOs.Users;
using CodeYad_Blog_CoreLayer.Utilities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CodeYad_Blog_CoreLayer.Services.Categories
{
    public interface ICategoryService
    {
        OperationResult CreateCategory(CreateCategoryDto Command);
        OperationResult EditCategory(EditCategoryDto Command);
        List<CategoryDto> GetAllCategory();
        List<CategoryDto> GetChildCategoryies(int parentid);
        CategoryDto GetCategoryBy(int id);
        CategoryDto GetCategoryBy(string slug);
        bool IsSlugExist(string slug);
     


    }

}
