using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.ViewModels.Catalog.Products;

namespace eShop.ViewModels.Catalog.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
