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
    [Route("posts/[Post]")]
    public class PostsController : ControllerBase
    {
        
        private static Post post = new Post();

        [HttpGet]
        public ActionResult<Post> Get()
        {
            return Ok(post);
        }
        
    }
}