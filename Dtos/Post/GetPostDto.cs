using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitCopy.Dtos.Post
{
    public class GetPostDto
    {
        public int Id { get; set; }
        public String Title { get; set; } = "Title";
        public String Text { get; set; } = "this will be comment filed";
        
    }
}