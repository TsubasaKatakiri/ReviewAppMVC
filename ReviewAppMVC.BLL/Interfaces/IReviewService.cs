using ReviewAppMVC.BLL.VMs.ReviewVMs;
using ReviewAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAppMVC.BLL.Interfaces
{
    public interface IReviewService
    {
        Task<Guid> CreateReviewAsync(ReviewCreate review);
        List<ReviewData> FindReview(Func<Review, bool> expression);
    }
}
