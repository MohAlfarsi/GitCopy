using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitCopy.Models;

namespace GitCopy.Services.PostService
{
    public class PostService : IPostService
    {
        
        private static List<Post> posts = new List<Post>()
        {
            new Post(),
            new Post { Id = 1, Title = "The Start", Text = "this is where it all begins"}
        };

        // Adding a Post 
        public List<Post> AddPost(Post newPost)
        {
            posts.Add(newPost);
            return posts;
        }

        //Getting a list of posts
        public List<Post> GetAllPosts()
        {
            return posts;
        }

        //
        public Post GetPostById(String id)
        {
            var post = posts.FirstOrDefault(p => p.Title == id);

            if(post is not null)
                return post;

            throw new Exception("Post not found!!");
        }
    }
}