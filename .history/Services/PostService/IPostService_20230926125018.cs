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
        Task<List<Post>> GetAllPosts();
        Post GetPostById(int id);
        Task<List<Post>> AddPost(Post newPost);
    }
}