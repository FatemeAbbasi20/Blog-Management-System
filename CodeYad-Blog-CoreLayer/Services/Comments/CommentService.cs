using CodeYad_Blog.DataLayer.Entities;
using CodeYad_Blog_CoreLayer.DTOs.Comments;
using CodeYad_Blog_CoreLayer.Utilities;
using CodeYad_Blog_DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly BlogContext _conext;

        public CommentService(BlogContext conext)
        {
            _conext = conext;
        }

        public OperationResult CreateComment(CreateCommentDto Command)
        {
            var Comment = new PostComment()
            {
                PostId=Command.PostId,UserId=Command.UserId,Text=Command.Text
            };
            _conext.Add(Comment);
            _conext.SaveChanges();
            return OperationResult.Success();


        }

        public List<CommentDto> GetPostComments(int PostId)
        {
           return _conext.PostComments.Include(p => p.User).Where(u => u.PostId == PostId).Select(Comment => new CommentDto()
            {
                Text = Comment.Text, PostId = PostId, CreationDate = Comment.creationTime,
                UserFullName = Comment.User.Fullname, CommentId = Comment.Id
            }).ToList();

        }
    }
}
