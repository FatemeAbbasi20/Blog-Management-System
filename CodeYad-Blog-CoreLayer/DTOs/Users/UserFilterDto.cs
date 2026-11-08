using CodeYad_Blog.DataLayer.Entities;
using CodeYad_Blog_CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.DTOs.Users
{
    public class UserFilterDto: BasePagination
    {
        public List<UserDto> Users { get; set; }
        
    }
}
