using ReviewAppMVC.BLL.VMs.CommentVMs;
using ReviewAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAppMVC.BLL.Interfaces
{
    public interface ICommentService
    {
        Task<Guid> CreateCommentAsync(CommentCreate comment);
        List<CommentData> FindComment(Func<Comment, bool> expression);
    }
}
