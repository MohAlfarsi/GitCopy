using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitCopy.Dtos.Comment
{
    public class UpdateCommentDto
    {
        public int Id { get; set; }
        public String Text  { get; set; } = "this is post 0 comments";
    }
}