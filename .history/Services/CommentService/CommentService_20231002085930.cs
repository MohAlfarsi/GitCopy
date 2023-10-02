using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitCopy.Dtos.Comment;
using GitCopy.Models;

namespace GitCopy.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private static List<Comment> comments = new List<Comment>()
        {
            new Comment(),
            new Comment { Id = 1, Text = "The begining can always be hard."}
        };

        private readonly IMapper _mapper;

        public CommentService(IMapper mapper)
        {

            _mapper = mapper;

        }

        // Adding a Comment 
        public async Task<ServiceResponse<List<GetCommentDto>>> AddComment(AddCommentDto newComment)
        {
            var serviceResponse = new ServiceResponse<List<GetCommentDto>>();
            var comment = _mapper.Map<Comment>(newComment);

            comment.Id = comments.Max(p => p.Id) + 1;

            comments.Add(comment);

            serviceResponse.Data = comments.Select(p => _mapper.Map<GetCommentDto>(p)).ToList();
            
            return serviceResponse;
        }


        //Deleteing a comment
        public async Task<ServiceResponse<List<GetCommentDto>>> DeleteComment(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCommentDto>>();

            try {
                var comment = comments.FirstOrDefault(p => p.Id == id);

                if(comment is null)
                    throw new Exception($"Character with Id '{id}' not found.");

                comments.Remove(comment);

                serviceResponse.Data = comments.Select( p => _mapper.Map<GetCommentDto>(p)).ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }    
            
            return serviceResponse;
        }



        //Getting a list of comments
        public async Task<ServiceResponse<List<GetCommentDto>>> GetAllComments()
        {
            var serviceResponse = new ServiceResponse<List<GetCommentDto>>();
            serviceResponse.Data = comments.Select(p => _mapper.Map<GetCommentDto>(p)).ToList();

            return serviceResponse;
        }



        //Getting a comment By ID
        public async Task<ServiceResponse<GetCommentDto>> GetCommentById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCommentDto>();

            var comment = comments.FirstOrDefault(p => p.Id == id);

            serviceResponse.Data = _mapper.Map<GetCommentDto>(comment);

            return serviceResponse;

        }


        //Updating a comment
        public async Task<ServiceResponse<GetCommentDto>> UpdateComment(UpdateCommentDto updatedComment)
        { 
            var serviceResponse = new ServiceResponse<GetCommentDto>();

            try {
                var comment = comments.FirstOrDefault(p => p.Id == updatedComment.Id);

                if(comment is null)
                    throw new Exception($"Character with Id '{updatedComment.Id}' not found.");

                comment.Text = updatedComment.Text;

                serviceResponse.Data = _mapper.Map<GetCommentDto>(comment);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }    
            
            return serviceResponse;

        }
    }
}