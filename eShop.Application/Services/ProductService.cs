using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Application.Interfaces;
using eShop.Data.EF;
using eShop.ViewModels.Catalog.Categories;
using eShop.ViewModels.Catalog.Products;
using Microsoft.EntityFrameworkCore;

namespace eShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly EShopDbContext _context;

        public ProductService(EShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> GetProducts()
        {
            return await _context.Products
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    DateCreated = x.DateCreated,
                    Description = x.Description,
                    Name = x.Name,
                    ProductCount = x.ProductCount,
                    PromotionPrice = x.PromotionPrice,
                    Stock = x.Stock,
                    UnitPrice = x.UnitPrice,
                    Categories = x.ProductCategories
                        .Where(pc=> pc.ProductId.Equals(x.Id))
                        .Select(categoryVm => new CategoryViewModel()
                        {
                            Id = categoryVm.Category.Id,
                            Name =  categoryVm.Category.Name,
                            Link = "#" + categoryVm.Category.Name
                        }).ToList()
                }).ToListAsync();
        }

        public async Task<ProductViewModel> GetProductById(string productId)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product != null)
            {
                return new ProductViewModel();
            }
            return null;
        }
    }
}
