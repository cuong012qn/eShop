using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Application.Interfaces;
using eShop.Data.EF;
using eShop.Data.Models;
using eShop.ViewModels.Catalog.Categories;
using eShop.ViewModels.Catalog.Products;
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

        public List<CategoryViewModel> GetProductsByCategories(
            int takeCategory = -1, int takeProduct = -1)
        {
            int totalCategory = takeCategory < 0 ? 100 : takeCategory;
            int totalProduct = takeProduct < 0 ? 100 : takeProduct;

            return _context.ProductCategories
                .Include(x => x.Product)
                .Include(x => x.Category)
                .OrderByDescending(x => x.Category.Id)
                .Take(totalCategory)
                .AsEnumerable()
                .GroupBy(x => x.CategoryId)
                .Select(x => new CategoryViewModel()
                {
                    Id = x.Key,
                    Name = x.First().Category.Name,
                    Link = "#" + x.First().Category.Name,
                    Products = x.Select(k => new ProductViewModel()
                    {
                        Id = k.Product.Id,
                        Name = k.Product.Name,
                        DateCreated = k.Product.DateCreated,
                        Description = k.Product.Description,
                        Stock = k.Product.Stock,
                        UnitPrice = k.Product.UnitPrice,
                        ProductCount = k.Product.ProductCount,
                        PromotionPrice = k.Product.PromotionPrice
                    }).OrderBy(k => k.DateCreated).Take(totalProduct).ToList()
                })
                .ToList();
        }

        public async Task<bool> Add(CategoryViewModel category)
        {
            try
            {
                _context.Categories.Add(new Category()
                {
                    Id = category.Id,
                    Name = category.Name
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> Remove(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                try
                {
                    _context.Categories.Remove(category);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> Update(int id, CategoryViewModel category)
        {
            var findCategory = await _context.Categories.FindAsync(id);
            if (findCategory != null)
            {
                try
                {
                    findCategory.Name = category.Name;
                    _context.Categories.Update(findCategory);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }

            return false;
        }
    }
}
