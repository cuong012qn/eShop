using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Data.EF;
using eShop.Data.Models;

namespace eShop.Data
{
    public class Seeding
    {
        private readonly EShopDbContext _context;
        public Seeding(EShopDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            //Seed category
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category
                {
                    Name = "Nike"
                });

                _context.Categories.Add(new Category
                {
                    Name = "Adidas"
                });

                _context.Categories.Add(new Category
                {
                    Name = "Running"
                });

                _context.Categories.Add(new Category
                {
                    Name = "Basketball"
                });

                _context.SaveChanges();
            }

            if (!_context.Products.Any())
            {
                List<Product> products = new List<Product>();

                products.Add(new Product()
                {
                    Name = "Nike Air Force 1 '07 LV8",
                    DateCreated = DateTime.Now,
                    Description = "The Nike Air Force 1 '07 LV8 updates the hoops-inspired '82 original with at least 20% recycled content by weight and a cork-infused outsole. With its pomegranate plant motif that includes real plant-dyed colour, an embroidered botanical design and scientific infographic, it's a natural twist on a classic we all know and love.",
                    Stock = 1,
                    ProductCount = 200,
                    PromotionPrice = null,
                    UnitPrice = 2929000,
                    Id = Guid.NewGuid().ToString()
                });

                _context.Products.AddRange(products);

                //air-force-1-07-lv8-shoe.png
                _context.ProductImages.Add(new ProductImage
                {
                    Id = Guid.NewGuid().ToString(),
                    Caption = "Product Images",
                    DateCreated = DateTime.Today,
                    ImagePath = "air-force-1-07-lv8-shoe.png",
                    ProductId = products.First().Id
                });

                _context.ProductImages.Add(new ProductImage
                {
                    Id = Guid.NewGuid().ToString(),
                    Caption = "Product Images",
                    DateCreated = DateTime.Today,
                    ImagePath = "air-force-1-07-lv8-shoe-top.png",
                    ProductId = products.First().Id
                });

                _context.SaveChanges();

                _context.ProductCategories.Add(new ProductCategory()
                {
                    ProductId = products.First().Id,
                    CategoryId = 1
                });

                _context.SaveChanges();
            }
        }
    }
}
