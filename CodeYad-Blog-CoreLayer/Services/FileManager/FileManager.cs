using CodeYad_Blog_CoreLayer.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.Services.FileManager
{
    public class FileManager : IFileManager
    {
       

        public string SaveFileAndReturnName(IFormFile file, string SavePath)
        {
            if (file == null) throw new Exception("file is null");
           var fileName= $"{Guid.NewGuid()}{file.FileName}";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), SavePath.Replace("/", "\\"));
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            var fullPath= Path.Combine(filePath, fileName);
            using var strm = new FileStream(fullPath, FileMode.Create);
            file.CopyTo(strm);
            return fileName;
        }
        public void DeleteFile(string fileName, string savePath)
        {  var filePath=Path.Combine(Directory.GetCurrentDirectory(), savePath, fileName);
           if(File.Exists(filePath))
                File.Delete(filePath);   
        }

        public string SaveImageAndReturnImageName(IFormFile file, string SavePath)
        {
            var isNotImage = !ImageValidation.Validate(file.FileName);
            if (isNotImage)
                throw new Exception();
            return SaveFileAndReturnName(file, SavePath);
        }
    }
}
