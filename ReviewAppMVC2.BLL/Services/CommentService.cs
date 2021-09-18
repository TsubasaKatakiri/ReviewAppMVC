using ReviewAppMVC2.BLL.Interfaces;
using ReviewAppMVC2.BLL.VMs.CommentVM;
using ReviewAppMVC2.DAL.Patterns;
using ReviewAppMVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAppMVC2.BLL.Services
{
    public class CommentService : ICommentService
    {
        public CommentService(IUnitOfWork db)
        {
            _db = db;
        }

        private readonly IUnitOfWork _db;

        public async Task<Guid> CreateCommentAsync(CommentCreate _comment)
        {
            try
            {
                var comment = new Comment()
                {
                    UserId = _comment.UserId,
                    Username = _comment.Username,
                    DateCreated = DateTime.Now,
                    Text = _comment.Text,
                    ReviewId = _comment.ReviewId,
                    ProductId = _comment.ProductId,
                };
                comment = await _db.Comments.CreateAsync(comment);
                return comment.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CommentData> FindComment(Func<Comment, bool> expression)
        {
            try
            {
                List<Comment> comments;
                if (expression == null)
                {
                    comments = _db.Comments.GetAll().ToList();
                }
                else
                {
                    comments = _db.Comments.GetAll().Where(expression).ToList();
                }
                return comments.Select(c =>
                {
                    return new CommentData()
                    {
                        ReviewId = c.ReviewId,
                        CommentId = c.Id,
                        DateCreated = c.DateCreated,
                        Username = c.Username,
                        ProductName = c.Review.Product.Name,
                        Text = c.Text,
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
