using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitCopy.Models;

namespace GitCopy.Services.CommentService
{
    public class CommentService : ICommentService
    {
        List<Comment> GetAllComments();
        Post GetCommentById(int id);
        List<Post> AddComment(Post newPost);
    }
}