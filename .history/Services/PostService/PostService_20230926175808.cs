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
        public async Task<ServiceResponse<List<Post>>> AddPost(Post newPost)
        {
            var serviceResponse = new serviceResponse<List<Post>>();
            posts.Add(newPost);
            serviceResponse.Data = posts;
            return serviceResponse;
        }

        //Getting a list of posts
        public async Task<ServiceResponse<List<Post>>> GetAllPosts()
        {
            return posts;
        }

        //Getting a post By ID
        public async Task<ServiceResponse<Post>> GetPostById(int id)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);

            if(post is not null)
                return post;

            throw new Exception("Post not found!!");
        }
    }
}