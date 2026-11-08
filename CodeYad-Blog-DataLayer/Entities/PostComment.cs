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
    public class PostComment : BaseEntity
    {
        
        [Required]
        [MaxLength(300)]
        public string Text { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }

       

        #region Relationships
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }

        #endregion
    }
}