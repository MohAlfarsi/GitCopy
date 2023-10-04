using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using GitCopy.Dtos.Post;
using GitCopy.Models;

namespace GitCopy.Services.PostService
{
    public interface IPostService
    {
        Task<ServiceResponse<List<GetPostDto>>> GetAllPosts();
        Task<ServiceResponse<GetPostDto>> GetPostById(int id);
        Task<ServiceResponse<List<GetPostDto>>> AddPost(AddPostDto newPost);
        Task<ServiceResponse<GetPostDto>> UpdatePost(AddPostDto newPost);
    }
}