using CodeYad_Blog_CoreLayer.DTOs.Users;
using CodeYad_Blog_CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.Services.Users
{
    public interface IUserService
    {
        OperationResult RegisterUser(UserRegisterDto registerDto);
        UserDto LoginUser(LoginUserDto LoginDto);
        UserFilterDto GetUsersByFilter(int PageId,int Take);
        UserDto GetUserById(int UserId);
        OperationResult EditUser(EditUserDto Command);

    }
}
