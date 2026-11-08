using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.DTOs.Comments
{
    public class CreateCommentDto
    {
        public string Text { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }




    }
}
