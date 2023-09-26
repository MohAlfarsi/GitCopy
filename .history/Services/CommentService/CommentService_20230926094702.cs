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
            comments.Add(newPost);
            return comments;
        }

        public List<Comment> GetAllComments()
        {
            return posts;
        }

        public Comment GetCommentById(int id)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);

            if(post is not null)
                return post;

            throw new Exception("Post not found!!");
        }
    }
}