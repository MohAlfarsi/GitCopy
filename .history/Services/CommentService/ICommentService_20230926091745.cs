using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitCopy.Services.CommentService
{
    public interface ICommentService
    {
        List<Comment> GetAllComments();
        Comment GetCommentById(int id);
        List<Comment> AddComment(Comment newComment);
    }
}