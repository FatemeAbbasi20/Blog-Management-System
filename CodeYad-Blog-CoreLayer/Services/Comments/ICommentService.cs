using CodeYad_Blog_CoreLayer.DTOs.Comments;
using CodeYad_Blog_CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.Services.Comments
{
    public interface ICommentService
    {
        OperationResult CreateComment(CreateCommentDto Command);
        List<CommentDto> GetPostComments(int PostId);

    }
}
