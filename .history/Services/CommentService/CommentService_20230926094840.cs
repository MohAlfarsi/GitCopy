using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitCopy.Models;

namespace GitCopy.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private static List<Comment> comments = new List<Comment>()
        {
            new Comment(),
            new Comment { Id = 1, Text = "The begining can always be hard."}
        };


        public List<Comment> AddComment(Comment newComment)
        {
            comments.Add(newComment);
            return comments;
        }

        public List<Comment> GetAllComments()
        {
            return comments;
        }

        public Comment GetCommentById(int id)
        {
            var comment = comments.FirstOrDefault(c => c.Id == id);

            if(comment is not null)
                return comment;

            throw new Exception("Comment not found!!");
        }
    }
}