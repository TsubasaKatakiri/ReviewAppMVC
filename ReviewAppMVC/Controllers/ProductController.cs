using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReviewAppMVC.BLL.Services;

namespace ReviewAppMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService productService;
        public IActionResult Index()
        {
            return View();
        }
    }
}
