using ReviewAppMVC.BLL.Interfaces;
using ReviewAppMVC.BLL.VMs;
using ReviewAppMVC.BLL.VMs.MediaFileVMs;
using ReviewAppMVC.DAL.Patterns;
using ReviewAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAppMVC.BLL.Services
{
    public class ProductService : IProductService
    {
        public ProductService(IUnitOfWork db, IMediaFileService mediaFileService)
        {
            _db = db;
            _mediaFileService = mediaFileService;
        }

        private readonly IUnitOfWork _db;
        private readonly IMediaFileService _mediaFileService;

        public async Task<Guid> CreateProductAsync(ProductCreate _product)
        {
            try
            {
                var product = new Product()
                {
                    Name = _product.Name,
                    Category = _product.Category,
                    Description = _product.Description,
                    Price = _product.Price,
                };
                product = await _db.Products.CreateAsync(product);

                if(_product.MediaFiles!=null && _product.MediaFiles.Any())
                {
                    _product.MediaFiles.Select(f => {
                        f.MediaEntityId = product.Id;
                        return _mediaFileService.CreateMediaFileAsync(f);
                    });
                }

                return product.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductCreate> FindProduct(Func<Product, bool> expression)
        {
            try
            {
                List<Product> products;
                if (expression == null){
                    products = _db.Products.GetAll().ToList();
                }
                else
                {
                    products = _db.Products.GetAll().Where(expression).ToList();
                }
                return products.Select(p =>
                {
                    return new ProductCreate()
                    {
                        Name = p.Name,
                        Category = p.Category,
                        Description = p.Description,
                        Price = p.Price,
                        MediaFiles = p.Files.Select(f =>
                        {
                            return new MediaFileCreate()
                            {
                                Name = f.Name,
                                Extension = f.Extension,
                                Path = f.Path,
                                DateCreated = f.DateCreated,
                                MediaEntityId = f.MediaEntityId
                            };
                        }).ToList()
                    };
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
