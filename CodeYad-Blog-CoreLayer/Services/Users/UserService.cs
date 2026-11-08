using CodeYad_Blog.DataLayer.Entities;
using CodeYad_Blog_CoreLayer.DTOs.Users;
using CodeYad_Blog_CoreLayer.Services.Users;
using CodeYad_Blog_CoreLayer.Utilities;
using CodeYad_Blog_DataLayer.Context;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace CodeYad_Blog_CoreLayer.Services.Users
{
    public class UserService : IUserService
    {
        private readonly BlogContext _context;

        public UserService(BlogContext context)
        {
            _context = context;
        }

       

        public OperationResult RegisterUser(UserRegisterDto registerDto)
        {
                var IsUserNameExist = _context.Users.Any(u => u.UserName == registerDto.UserName);
                if (IsUserNameExist)

                    return OperationResult.Error("نام کاربری تکراری است");


                var passwordHash = registerDto.Password.EncodeToMd5();
                _context.Users.Add(new User()
                {
                    Fullname = registerDto.Fullname,
                    UserName = registerDto.UserName,
                    Password = passwordHash,
                    Role = UserRole.User,
                    IsDelete = false,
                    creationTime = DateTime.Now
                });
                _context.SaveChanges();
                return OperationResult.Success();
        }
        public UserDto LoginUser(LoginUserDto LoginDto)
        {
            var PasswordHash=LoginDto.Password.EncodeToMd5();
            var user = _context.Users.FirstOrDefault(u => u.UserName == LoginDto.UserName && u.Password == PasswordHash);
            if (user == null)
                return null;
            var userDto = new UserDto()
            {
                Fullname=user.Fullname,
                UserName = user.UserName,
                Password = user.Password,
                Role = user.Role,
                 RegisterDate=user.creationTime,
                 UserId=user.Id

            };
             return  userDto;



        }

        public UserFilterDto GetUsersByFilter(int Take, int PageId)
        {
            var user = _context.Users.OrderByDescending(c => c.creationTime).Where(v => !v.IsDelete);

            var skip = (PageId - 1) * Take;
            var model = new UserFilterDto()
            {
                Users = user.Skip(skip).Take(Take).Select(user => new UserDto()
                {
                 Fullname = user.Fullname,Password= user.Password,UserName=user.UserName,
                 UserId = user.Id,RegisterDate=user.creationTime,Role=user.Role
                }).ToList()
               
            };
            model.GeneratePaging(user, Take, PageId);
            return model;

        }

        public UserDto GetUserById(int UserId)
        {
         var result=  _context.Users.FirstOrDefault(o=>o.Id== UserId);
            if (result == null)
                return null;
          return new UserDto()
            {
                Password = result.Password,
                Fullname = result.Fullname,
                UserName = result.UserName,
                UserId = result.Id,
                Role = result.Role,
                RegisterDate = result.creationTime
            };
           
        }

        public OperationResult EditUser(EditUserDto Command)
        {
           var user=_context.Users.FirstOrDefault(U=>U.Id== Command.UserId);
            if (user == null)
                return OperationResult.NotFound();
            user.Fullname = Command.FullName;
            user.Role = Command.Role;
            _context.SaveChanges();
            return OperationResult.Success(); 
        }

    }
}