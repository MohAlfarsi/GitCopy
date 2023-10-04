using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitCopy.Dtos.Post;
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
        public async Task<ServiceResponse<List<GetPostDto>>> AddPost(AddPostDto newPost)
        {
            var serviceResponse = new ServiceResponse<List<GetPostDto>>();
            
            posts.Add(newPost);

            serviceResponse.Data = posts;
            
            return serviceResponse;
        }



        //Getting a list of posts
        public async Task<ServiceResponse<List<GetPostDto>>> GetAllPosts()
        {
            var serviceResponse = new ServiceResponse<List<GetPostDto>>();
            serviceResponse.Data = posts;

            return serviceResponse;
        }



        //Getting a post By ID
        public async Task<ServiceResponse<GetPostDto>> GetPostById(int id)
        {
            var serviceResponse = new ServiceResponse<GetPostDto>();

            var post = posts.FirstOrDefault(p => p.Id == id);

            serviceResponse.Data = post;

            return serviceResponse;

        }
    }
}