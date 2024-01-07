using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siimple.BUSINESS.Helpers.FileManager
{
    public static class File
    {
        public static string Upload(this IFormFile file, string envPath, string folderName)
        {
            string filname = file.FileName;
            if (filname.Length > 64)
            {
                filname = filname.Substring(filname.Length - 64);
            }
            filname = Guid.NewGuid().ToString() + filname;


            string path = envPath + folderName + filname;
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return filname;
        }
    }
}
