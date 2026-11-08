using CodeYad_Blog.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeYad_Blog.DataLayer.Entities
{
    public class User : BaseEntity
    {
      
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        [MaxLength(100)]
        public string Fullname { get; set; }
        public UserRole Role { get; set; }

        #region Relationships
        public ICollection<Post> Posts { get; set; }
        public ICollection<PostComment> PostComments { get; set; }
        #endregion

    }
    public enum UserRole
    {
        Admin,
        User,
        Writer


    }
}
