using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("posts/[controller]")]
    public class CommentController : ControllerBase
    {
        [HttpGet]
        public string GetComments()
        {
            return "this will be the list of comments";
        }

        [HttpGet("{id}")]
        public string GetComment(int id)
        {
            return "this will be a comment";
        }
    }
}