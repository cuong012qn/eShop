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

        List<CategoryViewModel> GetProductsByCategories(int takeCategory = -1, int takeProduct = -1);

        Task<bool> Add(CategoryViewModel category);

        Task<bool> Remove(int id);

        Task<bool> Update(int id, CategoryViewModel category);
    }
}
