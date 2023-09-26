using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace GitCopy.Controllers
{
    [ApiController]
    [Route("posts/[controller]")]
    public class CommentsController : ControllerBase
    {
        
        private static List<Post> posts = new List<Post>()
        {
            new Post(),
            new Post { Id = 1, Title = "The Start", Text = "this is where it all begins"}
        };
        private readonly IPostService _postService;


        //Constractor
        public CommentsController(IPostService postService)
        {
            _postService = postService;
        }


        [HttpGet("GetAll")]
        public ActionResult<List<Post>> Get()
        {
            return Ok(_postService.GetAllComments());
        }
        

        [HttpGet("{id}")]
        public ActionResult<List<Post>> GetSingle(int id)
        {
            return Ok(_postService.GetCommentById(id));
        }


        [HttpPost]
        public ActionResult<List<Post>> AddPost(Post newPost)
        {
            return Ok(_postService.AddPost(newPost));
        }
        
    }
}