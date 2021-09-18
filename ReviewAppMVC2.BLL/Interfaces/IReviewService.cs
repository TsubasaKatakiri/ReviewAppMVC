using ReviewAppMVC2.BLL.VMs.ReviewVM;
using ReviewAppMVC2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAppMVC2.BLL.Interfaces
{
    public interface IReviewService
    {
        Task<Guid> CreateReviewAsync(ReviewCreate review);
        List<ReviewData> FindReview(Func<Review, bool> expression);
    }
}
