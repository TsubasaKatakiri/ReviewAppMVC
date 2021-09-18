using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReviewAppMVC2.BLL.Interfaces;
using ReviewAppMVC2.BLL.VMs.CommentVM;
using ReviewAppMVC2.Models;

namespace ReviewAppMVC2.Controllers
{
    public class CommentController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICommentService _commentService;

        public CommentController(UserManager<User> userManager, ICommentService commentService)
        {
            _userManager = userManager;
            _commentService = commentService;
        }

        // GET: CommentController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: CommentController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        [HttpGet]
        [Authorize]
        //[Route("/products/{productId}/{reviewId}/create")]
        public ActionResult CreateNewComment(Guid productId, Guid reviewId)
        {
            return View(new CommentCreate() { ReviewId = reviewId, ProductId = productId });
        }

        // POST: CommentController/Create
        [HttpPost]
        [Authorize]
        //[Route("/products/{productId}/{reviewId}/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment([FromForm] CommentCreate comment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var currentUser = _userManager.GetUserAsync(User).Result;
                    comment.UserId = new Guid(currentUser.Id);

                    await _commentService.CreateCommentAsync(comment);

                    return RedirectToRoute("default", new { controller = "Product", action = "GetProductById", id = comment.ProductId });
                }
                return View(comment);
            }
            catch
            {
                return View();
            }
        }
    }
}
