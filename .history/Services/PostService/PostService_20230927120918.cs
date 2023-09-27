using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using GitCopy.Dtos.Post;
using GitCopy.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace GitCopy.Services.PostService
{
    public class PostService : IPostService
    {
        
        private static List<Post> posts = new List<Post>()
        {
            new Post(),
            new Post { Id = 1, Title = "The Start", Text = "this is where it all begins"}
        };
        private readonly IMapper _mapper;

        public PostService(IMapper mapper)
        {

            _mapper = mapper;

        }

        // Adding a Post 
        public async Task<ServiceResponse<List<GetPostDto>>> AddPost(AddPostDto newPost)
        {
            var serviceResponse = new ServiceResponse<List<GetPostDto>>();
            var post = _mapper.Map<Post>(newPost);

            post.Id = posts.Max(p => p.Id) + 1;

            posts.Add(post);

            serviceResponse.Data = posts.Select(p => _mapper.Map<GetPostDto>(p)).ToList();
            
            return serviceResponse;
        }



        //Getting a list of posts
        public async Task<ServiceResponse<List<GetPostDto>>> GetAllPosts()
        {
            var serviceResponse = new ServiceResponse<List<GetPostDto>>();
            serviceResponse.Data = posts.Select(p => _mapper.Map<GetPostDto>(p)).ToList();

            return serviceResponse;
        }



        //Getting a post By ID
        public async Task<ServiceResponse<GetPostDto>> GetPostById(int id)
        {
            var serviceResponse = new ServiceResponse<GetPostDto>();

            var post = posts.FirstOrDefault(p => p.Id == id);

            serviceResponse.Data = _mapper.Map<GetPostDto>(post);

            return serviceResponse;

        }

        public async Task<ServiceResponse<GetPostDto>> UpdatePost(UpdatePostDto updatedPost)
        { 
            var serviceResponse = new ServiceResponse<GetPostDto>();

            try {
                var post = posts.FirstOrDefault(p => p.Id == updatedPost.Id);

                if(post is null)
                    throw new Exception($"Character with Id '{updatedPost.Id}' not found.")

                post.Title = updatedPost.Title;
                post.Text = updatedPost.Text;

                serviceResponse.Data = _mapper.Map<GetPostDto>(post);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }    
            
            return serviceResponse;

        }
    }
}