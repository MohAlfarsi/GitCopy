using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace GitCopy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        
        private static List<Comment> Comments = new List<Comment>()
        {
            new Comment(),
            new Comment { Id = 1, Text = "The begining can always be hard."}
        };
        private readonly ICommentService _CommentService;


        //Constractor
        public CommentsController(ICommentService CommentService)
        {
            _CommentService = CommentService;
        }


        [HttpGet("GetAll")]
        public ActionResult<List<Comment>> Get()
        {
            return Ok(_CommentService.GetAllComments());
        }
        

        [HttpGet("{id}")]
        public ActionResult<List<Comment>> GetSingle(int id)
        {
            return Ok(_CommentService.GetCommentById(id));
        }


        [HttpPost]
        public ActionResult<List<Comment>> AddComment(Comment newComment)
        {
            return Ok(_CommentService.AddComment(newComment));
        }
        
    }
}