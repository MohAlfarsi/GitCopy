using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using GitCopy.Dtos.Post;
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
        public async Task<ActionResult<ServiceResponse<List<GetPostDto>>>> Get()
        {
            return Ok(await _postService.GetAllPosts());
        }
        

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetPostDto>>>> GetSingle(int id)
        {
            return Ok(await _postService.GetPostById(id));
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetPostDto>>>> AddPost(AddPostDto newPost)
        {
            return Ok(await _postService.AddPost(newPost));
        }
        


        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetPostDto>>>> UpdatePost(UpdatePostDto updatedPost)
        {
            var response = await _postService.UpdatePost(updatedPost);
            if(response.Data is null){
                return NotFound(response);
            }

            return Ok(response);
        }
        
    }
}