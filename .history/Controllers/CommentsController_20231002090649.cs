using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitCopy.Dtos.Comment;
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

        private readonly ICommentService _commentService;


        //Constractor
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
 

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCommentDto>>>> Get()
        {
            return Ok(await _commentService.GetAllComments());
        }
        

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCommentDto>>> GetSingle(int id)
        {
            return Ok(await _commentService.GetCommentById(id));
        }


        [HttpComment]
        public async Task<ActionResult<ServiceResponse<List<GetCommentDto>>>> AddComment(AddCommentDto newComment)
        {
            return Ok(await _commentService.AddComment(newComment));
        }
        


        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetCommentDto>>>> UpdateComment(UpdateCommentDto updatedComment)
        {
            var response = await _commentService.UpdateComment(updatedComment);
            if(response.Data is null){
                return NotFound(response);
            }

            return Ok(response);
        }
        

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCommentDto>>> DeleteComment(int id)
        {
            var response = await _commentService.DeleteComment(id);
            if(response.Data is null){
                return NotFound(response);
            }

            return Ok(response);
        }

        
    }
}