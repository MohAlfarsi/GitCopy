using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitCopy.Dtos.Comment;

namespace GitCopy.Services.CommentService
{
    public interface ICommentService
    {
        Task<ServiceResponse<List<GetCommentDto>>> GetAllComments();
        Task<ServiceResponse<GetCommentDto>> GetCommentById(int id);
        Task<ServiceResponse<List<GetCommentDto>>> AddComment(AddCommentDto newComment);
        Task<ServiceResponse<GetCommentDto>> UpdateComment(UpdateCommentDto newComment);
        Task<ServiceResponse<List<GetCommentDto>>> DeleteComment(int id);
    }
}