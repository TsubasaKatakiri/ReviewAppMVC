using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReviewAppMVC2.BLL.Interfaces;
using ReviewAppMVC2.BLL.VMs.ProductVM;
using ReviewAppMVC2.Models;

namespace ReviewAppMVC2.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IProductService _productService;

        public ProductController(UserManager<User> userManager, IProductService productService)
        {
            _userManager = userManager;
            _productService = productService;
        }

        //Getting all products
        [HttpGet]
        //[Route("/products")]
        public ActionResult GetAllProducts()
        {
            var products = _productService.FindProduct(null);
            return View(products);
        }

        //Getting a specific product by its id
        [HttpGet]
        //[Route("/products/{id}")]
        public ActionResult GetProductById(Guid id)
        {
            var product = _productService.FindProduct(p => p.Id == id).SingleOrDefault();
            return View(product);
        }

        //Creating new product (GET)
        [HttpGet]
        [Authorize]
        //[Route("/products/new")]
        public ActionResult CreateNewProduct()
        {
            return View(new ProductCreate());
        }

        //Creating new product (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //[Route("/products")]
        public ActionResult CreateProduct([FromForm] ProductCreate product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var productId = _productService.CreateProductAsync(product).Result;
                    //return RedirectToAction(nameof(GetProductById), productId);
                    return RedirectToAction(nameof(GetAllProducts));
                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }
    }
}
