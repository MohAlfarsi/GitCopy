using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using GitCopy.Models;
using Microsoft.AspNetCore.Mvc;

namespace GitCopy.Controllers
{
    [ApiController]
    [Route("posts/[controller]")]
    public class PostsController : ControllerBase
    {
        
        private static List<Post> posts = new List<Post>()
        {
            new Post(),
            new Post { Id = 1, Title = "The Start", Text = "this is where it all begins"}
        };
        private readonly IPostService _postService;

        //Constractor
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Post>> Get()
        {
            return Ok(posts);
        }
        
        [HttpGet("{id}")]
        public ActionResult<List<Post>> GetSingle(int id)
        {
            return Ok(posts.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        public ActionResult<List<Post>> AddPost(Post newPost)
        {
            posts.Add(newPost);
            return Ok(posts);
        }
        
    }
}