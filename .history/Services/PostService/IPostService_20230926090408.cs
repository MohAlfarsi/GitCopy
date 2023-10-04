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
        List<Post> GetAllPosts();
        Post GetPostById(String id);
        List<Post> AddPost(Post newPost);
    }
}