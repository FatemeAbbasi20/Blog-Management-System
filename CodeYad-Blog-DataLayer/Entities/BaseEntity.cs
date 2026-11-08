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
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime creationTime { get; set; } = DateTime.Now;
        public bool IsDelete { get; set; }
    }
}
