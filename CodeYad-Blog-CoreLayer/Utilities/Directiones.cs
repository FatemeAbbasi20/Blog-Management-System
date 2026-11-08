using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.Utilities
{
    public class Directiones
    {
        public const string PostImage = "wwwroot/Images/Posts";
        public static string GetPostImage(string imageName) =>$"{PostImage.Replace("wwwroot","")}/{ imageName}";

        public const string PostContentImage = "wwwroot/Images/Posts/Content";
        public static string GetPostContentImage(string imageName) => $"{PostContentImage.Replace("wwwroot","")}/{imageName}";


    }
}
