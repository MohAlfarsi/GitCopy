using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitCopy.Dtos.Post;
using GitCopy.Dtos.Comment;

namespace GitCopy
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Post, GetPostDto>();
            CreateMap<AddPostDto, Post>();
            CreateMap<UpdatePostDto, Post>();
            
            CreateMap<Comment, GetCommentDto>();
            CreateMap<AddCommentDto, Comment>();
            CreateMap<UpdateCommentDto, Comment>();

            
        }
        
    }
}