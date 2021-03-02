using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Core.Utilities.Helpers
{
   public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            string directory = Environment.CurrentDirectory + @"\wwwroot\";
            string fileName = CreateNewFileName(file.FileName);

            string path = Path.Combine(directory, "Images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                file.CopyTo(stream);
            }

            string filePath = Path.Combine(path, fileName);
            return filePath;
        }
        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }
        public static string Update(string sourcePath,IFormFile formFile)
        {
            var result = CreateNewFileName(sourcePath);
            if (sourcePath.Length > 0)
            {
                using (var stream=new FileStream(result,FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }
        public static string CreateNewFileName(string fileName)
        {
            string[] file = fileName.Split('.');
            string extension = file[1];
            string newFileName = string.Format(@"{0}." + extension, Guid.NewGuid());
            return newFileName;
        }
    }
}
