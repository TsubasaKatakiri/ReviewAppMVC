using ReviewAppMVC.BLL.Interfaces;
using ReviewAppMVC.BLL.VMs.CommentVMs;
using ReviewAppMVC.DAL.Patterns;
using ReviewAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAppMVC.BLL.Services
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
                    DateCreated=DateTime.Now,
                    Text=_comment.Text,
                    ReviewId=_comment.ReviewId
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
                        DateCreated=c.DateCreated,
                        Username=c.User.UserName,
                        ProductName=c.Review.Product.Name,
                        Text=c.Text,
                        ReviewId=c.ReviewId
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
