using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitCopy.Models;

namespace GitCopy.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private static List<Comment> Comments = new List<Comment>()
        {
            new Comment(),
            new Comment { Id = 1, Text = "The begining can always be hard."}
        };


        public List<Comment> AddComment(Comment newComment)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAllComments()
        {
            throw new NotImplementedException();
        }

        public Comment GetCommentById(int id)
        {
            throw new NotImplementedException();
        }
    }
}