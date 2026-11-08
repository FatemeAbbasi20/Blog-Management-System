using CodeYad_Blog_CoreLayer.DTOs;
using CodeYad_Blog_CoreLayer.Mappers;
using CodeYad_Blog_DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.Services
{
    public interface IMainPageService
    {
        MainPageDto GetData();
    }
    public class MainPageService : IMainPageService
    {
        private readonly BlogContext _context;

        public MainPageService(BlogContext context)
        {
            _context = context;
        }

        public MainPageDto GetData()
        {
            var SpacialPosts = _context.Posts.OrderByDescending(c=>c.Id). Include(c => c.Category).Include(i => i.SubCategory)
                .Where(c => c.IsSpecial).Take(4).Select(Post => PostMapper.MapToDto(Post)).ToList();

            var LatestPosts= _context.Posts.Include(i => i.Category).Include(i=>i.SubCategory)
                .OrderByDescending(i=>i.Id).Take(6).Select(Post => PostMapper.MapToDto(Post)).ToList();

            var Categories = _context.Categories.OrderByDescending(o => o.Id).Take(60).Include(o => o.Posts).
                Include(p => p.SubPosts).Select(Category => new MainPageCategoryDto()
            {
                Slug = Category.Slug,
                Title = Category.Title,
                PostChild = Category.Posts.Count + Category.SubPosts.Count,
                IsMainCategory = Category.ParentId == null
            }).ToList();

            return new MainPageDto
            {
                Categories = Categories,
                SpecialPosts = SpacialPosts,
                LatestPosts = LatestPosts
            };
        }
    }
}
