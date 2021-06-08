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
                products.Add(new Product()
                {
                    Name = "Zion 1 PF",
                    DateCreated = DateTime.Now,
                    Description = "With a down-to-earth persona and abilities that are out of this world, Zion is unlike anybody else.On court, the gentle spirit who's all about family transforms into an unmatched force of unstoppable athleticism and speed.The Zion 1 kicks off his signature line with a design inspired by his duality of humility and superhuman ability.Full-length Air Strobel cushioning is stacked with a Zoom Air unit in the forefoot—a sensational mix of plush underfoot comfort and rapid responsiveness.It's light, stable and strong, with aggressive traction to help Zion grip the court and control his power.This PF version uses an extra-durable outsole that's designed for outdoor courts.",
                    ProductCount = 100,
                    Stock = 1,
                    UnitPrice = 3519000,
                    PromotionPrice = null,
                    Id = Guid.NewGuid().ToString()
                });
                products.Add(new Product()
                {
                    Name = "Zoom Freak 2",
                    DateCreated = DateTime.Now,
                    Description = "Giannis possesses a freakish combination of height, length and speed rarely seen in the league. The Zoom Freak 2 harnesses his power and helps enable him to generate force to help drive him down the court. A moulded overlay caps the outer toe area to help contain Giannis's devastating Euro step move.",
                    Stock = 1,
                    ProductCount = 1000,
                    UnitPrice = 3519000,
                    PromotionPrice = null,
                    Id = Guid.NewGuid().ToString()
                });
                products.Add(new Product()
                {
                    DateCreated = DateTime.Now,
                    Description = "Diversify your training and get a leg up on the competition. Box jumps, bear crawls, burpees? Take it all in stride and push towards excellence in these adidas running shoes. Their 360º Torsion System supports explosive movement any direction. Springy Bounce cushioning ensures comfort through even the most gruelling sessions.",
                    Name = "ALPHATORSION 2.0 SHOES",
                    Id = Guid.NewGuid().ToString(),
                    ProductCount = 500,
                    Stock = 1,
                    UnitPrice = 2850000,
                    PromotionPrice = null
                });
                _context.Products.AddRange(products);

                //air-force-1-07-lv8-shoe.png

                #region ProductImages
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

                _context.ProductImages.Add(new ProductImage()
                {
                    ProductId = products[1].Id,
                    DateCreated = DateTime.Now,
                    Caption = "Top",
                    Id = Guid.NewGuid().ToString(),
                    ImagePath = "zion-1-pf-basketball-shoe-top.png"
                });
                _context.ProductImages.Add(new ProductImage()
                {
                    ProductId = products[1].Id,
                    DateCreated = DateTime.Now,
                    Caption = "Top",
                    Id = Guid.NewGuid().ToString(),
                    ImagePath = "zion-1-pf-basketball-shoe-front.png"
                });

                _context.ProductImages.Add(new ProductImage()
                {
                    ProductId = products[2].Id,
                    DateCreated = DateTime.Now,
                    Caption = "Top",
                    Id = Guid.NewGuid().ToString(),
                    ImagePath = "zion-1-pf-basketball-shoe-top.png"
                });
                _context.ProductImages.Add(new ProductImage()
                {
                    ProductId = products[2].Id,
                    DateCreated = DateTime.Now,
                    Caption = "Top",
                    Id = Guid.NewGuid().ToString(),
                    ImagePath = "zion-1-pf-basketball-shoe-front.png"
                });

                _context.ProductImages.Add(new ProductImage()
                {
                    Caption = "",
                    DateCreated = DateTime.Now,
                    Id = Guid.NewGuid().ToString(),
                    ImagePath = "Alphatorsion_2.0_Shoes_Black_GZ8738_02_standard-top.png",
                    ProductId = products[3].Id
                });
                _context.ProductImages.Add(new ProductImage()
                {
                    Caption = "",
                    DateCreated = DateTime.Now,
                    Id = Guid.NewGuid().ToString(),
                    ImagePath = "Alphatorsion_2.0_Shoes_Black_GZ8738_02_standard-front.png",
                    ProductId = products[3].Id
                });
                #endregion

                #region ProductCategories
                _context.ProductCategories.Add(new ProductCategory()
                {
                    ProductId = products.First().Id,
                    CategoryId = 1
                });
                _context.ProductCategories.Add(new ProductCategory()
                {
                    ProductId = products[1].Id,
                    CategoryId = 1,
                });
                _context.ProductCategories.Add(new ProductCategory()
                {
                    ProductId = products[1].Id,
                    CategoryId = 4,
                });
                _context.ProductCategories.Add(new ProductCategory()
                {
                    CategoryId = 1,
                    ProductId = products[2].Id,
                });
                _context.ProductCategories.Add(new ProductCategory()
                {
                    CategoryId = 4,
                    ProductId = products[2].Id,
                });
                _context.ProductCategories.Add(new ProductCategory()
                {
                    ProductId = products[3].Id,
                    CategoryId = 2
                });
                _context.ProductCategories.Add(new ProductCategory()
                {
                    ProductId = products[3].Id,
                    CategoryId = 3
                });
                _context.SaveChanges();
                #endregion

            }
        }
    }
}
