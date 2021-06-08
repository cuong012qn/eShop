using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.ViewModels.Catalog.Products;

namespace eShop.Application.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductViewModel>> GetProducts(int take = -1);

        public Task<ProductViewModel> GetProductById(string productId);
    }
}
