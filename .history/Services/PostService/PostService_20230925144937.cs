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
        
        public List<Post> AddPost(Post newPost)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public Post GetPostById(int id)
        {
            throw new NotImplementedException();
        }
    }
}