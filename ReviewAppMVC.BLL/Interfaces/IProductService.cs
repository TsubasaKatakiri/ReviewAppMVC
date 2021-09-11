using ReviewAppMVC.BLL.VMs;
using ReviewAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAppMVC.BLL.Interfaces
{
    public interface IProductService
    {
        Task<Guid> CreateProductAsync(ProductCreate product);
        List<ProductCreate> FindProduct(Func<Product, bool> expression);
    }
}
