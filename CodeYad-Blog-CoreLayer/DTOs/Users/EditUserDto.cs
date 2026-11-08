using CodeYad_Blog.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.DTOs.Users
{
    public class EditUserDto
    {
        public string FullName { get; set; }
        public int UserId { get; set; }
        public UserRole Role { get; set; }
    }
}
