using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReviewAppMVC2.BLL.Interfaces;
using ReviewAppMVC2.BLL.VMs.ReviewVM;
using ReviewAppMVC2.Models;

namespace ReviewAppMVC2.Controllers
{
    public class ReviewController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IReviewService _reviewService;

        public ReviewController(UserManager<User> userManager, IReviewService reviewService)
        {
            _userManager = userManager;
            _reviewService = reviewService;
        }

        //// GET: ReviewController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: ReviewController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //Creating new review (GET)
        [HttpGet]
        [Authorize]
        //[Route("/products/{id}/create")]
        public ActionResult CreateNewReview(Guid id)
        {
            return View(new ReviewCreate() { ProductId = id });
        }

        //Creating new review (POST)
        [HttpPost]
        [Authorize]
        //[Route("/products/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview([FromForm] ReviewCreate review)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var currentUser = _userManager.GetUserAsync(User).Result;
                    review.UserId = new Guid(currentUser.Id);

                    await _reviewService.CreateReviewAsync(review);

                    return RedirectToRoute("default", new { controller="Product", action="GetProductById", id = review.ProductId });
                }
                return View(review);
            }
            catch
            {
                return View();
            }
        }
    }
}
