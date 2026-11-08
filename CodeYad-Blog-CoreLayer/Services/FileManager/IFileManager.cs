using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog_CoreLayer.Services.FileManager
{
    public interface IFileManager
    {
        String SaveFileAndReturnName(IFormFile file, String SavePath);
        String SaveImageAndReturnImageName(IFormFile file, String SavePath);
        void DeleteFile(string fileName ,String savePath);

    }
}
