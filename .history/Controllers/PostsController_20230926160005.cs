using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace GitCopy.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<ActionResult<List<Post>>> Get()
        {
            return Ok(_postService.GetAllPosts());
        }
        

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Post>>> GetSingle(int id)
        {
            return Ok(_postService.GetPostById(id));
        }


        [HttpPost]
        public async Task<ActionResult<List<Post>>> AddPost(Post newPost)
        {
            return Ok(_postService.AddPost(newPost));
        }
        
    }
}