using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.DTOs.Users
{
    public class UserRegisterDto
    {
        public string UserName { get; set; }


        public string Password { get; set; }
     
        public string Fullname { get; set; }
       
    }
}
