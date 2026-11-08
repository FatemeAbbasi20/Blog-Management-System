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

    public class Post : BaseEntity
    {


        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(400)]
        public string Description { get; set; }
        [Required]
        [MaxLength(100)]
        public string slug { get; set; }
        public int Visit { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int UserId { get; set; }
        public string ImageName { get; set; }
        public bool IsSpecial { get; set; }


        #region Relationships
        public ICollection<PostComment> PostComments { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [ForeignKey("SubCategoryId")]
        public Category SubCategory { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        #endregion

    }

}
