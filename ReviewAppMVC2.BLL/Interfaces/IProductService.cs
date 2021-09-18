using ReviewAppMVC2.BLL.VMs.ProductVM;
using ReviewAppMVC2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAppMVC2.BLL.Interfaces
{
    public interface IProductService
    {
        Task<Guid> CreateProductAsync(ProductCreate product);
        List<ProductData> FindProduct(Func<Product, bool> expression);
    }
}
