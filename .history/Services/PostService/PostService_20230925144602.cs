using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitCopy.Services.PostService
{
    public class PostService : IPostService
    {
        
        private static List<Post> posts = new List<Post>()
        {
            new Post(),
            new Post { Id = 1, Title = "The Start", Text = "this is where it all begins"}
        };

        [HttpGet("GetAll")]
        public ActionResult<List<Post>> Get()
        {
            return posts;
        }
        
        [HttpGet("{id}")]
        public ActionResult<List<Post>> GetPostById(int id)
        {
            return posts.FirstOrDefault(p => p.Id == id);
        }

        [HttpPost]
        public ActionResult<List<Post>> AddPost(Post newPost)
        {
            posts.Add(newPost);
            return posts;
        }
        
    }
}