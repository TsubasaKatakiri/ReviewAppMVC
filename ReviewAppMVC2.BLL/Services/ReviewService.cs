using ReviewAppMVC2.BLL.Interfaces;
using ReviewAppMVC2.BLL.VMs.CommentVM;
using ReviewAppMVC2.BLL.VMs.MediaFileVM;
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
    public class ReviewService : IReviewService
    {
        public ReviewService(IUnitOfWork db, IMediaFileService mediaFileService)
        {
            _db = db;
            _mediaFileService = mediaFileService;
        }

        private readonly IUnitOfWork _db;
        private readonly IMediaFileService _mediaFileService;

        public async Task<Guid> CreateReviewAsync(ReviewCreate _review)
        {
            try
            {
                var review = new Review()
                {
                    UserId = _review.UserId,
                    Username = _review.Username,
                    ProductId = _review.ProductId,
                    DateCreated = DateTime.Now,
                    Score = _review.Score,
                    Text = _review.Text
                };
                review = await _db.Reviews.CreateAsync(review);

                if (_review.MediaFiles != null && _review.MediaFiles.Any())
                {
                    _review.MediaFiles.Select(f => {
                        f.MediaEntityId = review.Id;
                        return _mediaFileService.CreateMediaFileAsync(f);
                    });
                }

                return review.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ReviewData> FindReview(Func<Review, bool> expression)
        {
            try
            {
                List<Review> reviews;
                if (expression == null)
                {
                    reviews = _db.Reviews.GetAll().ToList();
                }
                else
                {
                    reviews = _db.Reviews.GetAll().Where(expression).ToList();
                }
                return reviews.Select(r =>
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
                        MediaFiles = r.Files.Select(f =>
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
                                ProductName = c.Review.Product.Name,
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
