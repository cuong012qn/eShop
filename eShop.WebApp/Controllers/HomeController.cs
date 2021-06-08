using eShop.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eShop.Application.Interfaces;
using eShop.Data.EF;
using eShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly EShopDbContext _context;

        public HomeController(ILogger<HomeController> logger,
            IProductService productService,
            ICategoryService categoryService,
            EShopDbContext context)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Categories"] = await _categoryService.GetCategories();
            var products = await _productService.GetProducts();


            
            return View(products);
        }
    }
}
