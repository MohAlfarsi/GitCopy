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
            new Post { Title = "The Start"}
        };

        [HttpGet("GetAll")]
        public ActionResult<List<Post>> Get()
        {
            return Ok(posts);
        }
        
        [HttpGet]
        public ActionResult<List<Post>> GetSingle()
        {
            return Ok(posts[1]);
        }
        
        
    }
}