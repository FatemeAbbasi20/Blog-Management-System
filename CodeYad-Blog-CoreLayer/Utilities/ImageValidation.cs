using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.Utilities
{
    public class ImageValidation
    {
        public static bool Validate(string imageName)
        {
            var extention = Path.GetExtension(imageName);

            if (extention == null)
                return false;
            return extention.ToLower() == "png" || extention.ToLower() == "jpg";
        }
        public static bool Validate(IFormFile file)
        {
            try
            {
                using var image = System.Drawing.Image.FromStream(file.OpenReadStream());
                return true;
            }
            catch
            {
                return false;
            }
        }
    } 
 }
