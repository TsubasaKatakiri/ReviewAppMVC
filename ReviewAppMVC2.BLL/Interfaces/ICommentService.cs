using ReviewAppMVC2.BLL.VMs.CommentVM;
using ReviewAppMVC2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAppMVC2.BLL.Interfaces
{
    public interface ICommentService
    {
        Task<Guid> CreateCommentAsync(CommentCreate comment);
        List<CommentData> FindComment(Func<Comment, bool> expression);
    }
}
