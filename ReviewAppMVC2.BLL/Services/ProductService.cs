using ReviewAppMVC2.BLL.Interfaces;
using ReviewAppMVC2.BLL.VMs.CommentVM;
using ReviewAppMVC2.BLL.VMs.MediaFileVM;
using ReviewAppMVC2.BLL.VMs.ProductVM;
using ReviewAppMVC2.BLL.VMs.ReviewVM;
using ReviewAppMVC2.DAL.Patterns;
using ReviewAppMVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAppMVC2.BLL.Services
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

                if (_product.MediaFiles != null && _product.MediaFiles.Any())
                {
                    _product.MediaFiles.Select(f =>
                    {
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

        public List<ProductData> FindProduct(Func<Product, bool> expression)
        {
            try
            {
                List<Product> products;
                if (expression == null)
                {
                    products = _db.Products.GetAll().ToList();
                }
                else
                {
                    products = _db.Products.GetAll().Where(expression).ToList();
                }
                return products.Select(p =>
                {
                    return new ProductData()
                    {
                        ProductId = p.Id,
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
                        }).ToList(),
                        Reviews = p.Reviews.Select(r =>
                        {
                            return new ReviewData()
                            {
                                ReviewId = r.Id,
                                ProductId = r.ProductId,
                                DateCreated = r.DateCreated,
                                Username = r.Username,
                                Score = r.Score,
                                Text = r.Text,
                                ProductName = r.Product.Name,
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
                                }).ToList(),
                                Comments = r.Comments.Select(c =>
                                {
                                    return new CommentData()
                                    {
                                        ReviewId = c.ReviewId,
                                        CommentId = c.Id,
                                        DateCreated = c.DateCreated,
                                        Username = c.Username,
                                        Text = c.Text,
                                        ProductName = c.Review.Product.Name
                                    };
                                }).OrderByDescending(o => o.DateCreated).ToList(),
                            };
                        }).OrderByDescending(o=>o.DateCreated).ToList()
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
