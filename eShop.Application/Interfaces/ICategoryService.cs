using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Data.Models;
using eShop.ViewModels.Catalog.Categories;

namespace eShop.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetCategories();

        Task<CategoryViewModel> GetCategoryById(int id);
    }
}
