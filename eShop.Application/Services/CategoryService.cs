using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Application.Interfaces;
using eShop.Data.EF;
using eShop.ViewModels.Catalog.Categories;
using Microsoft.EntityFrameworkCore;

namespace eShop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly EShopDbContext _context;

        public CategoryService(EShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryViewModel>> GetCategories()
        {
            return await _context.Categories.Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Link = "#" + x.Name
            }).ToListAsync();
        }

        public async Task<CategoryViewModel> GetCategoryById(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category != null)
            {
                return new CategoryViewModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Link = "#" + category.Name
                };
            }
            else return null;
        }
    }
}
