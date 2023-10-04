using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using GitCopy.Models;

namespace GitCopy.Services.PostService
{
    public interface IPostService
    {
        Task<ServiceResponse<List<Post>>> GetAllPosts();
        Task<ServiceResponse<Post>> GetPostById(int id);
        Task<ServiceResponse<List<Post>>> AddPost(Post newPost);
    }
}