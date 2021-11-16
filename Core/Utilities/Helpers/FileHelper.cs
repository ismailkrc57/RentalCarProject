using System;
using System.IO;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\Images\\";
        public static string DefaultImagePath = @"\Images\default.png";

        public static IResult Upload([FromForm] IFormFile file)
        {
            string randomName = GetRandom();

            var result = BusinessRule.Run(CheckDirectoryExist(_currentDirectory), CheckFileExist(file), CheckFileType(GetType(file)));
            if (result == null)
            {
                using (FileStream fileStream = File.Create(_currentDirectory + _folderName + randomName + GetType(file)))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
                return new SuccessResult((_folderName + randomName + GetType(file)).Replace("\\", "/"));
            }
            return result;
        }

        public static IResult Delete(string filePath)
        {
            if (File.Exists(_currentDirectory + filePath.Replace("/", "\\")))
            {
                File.Delete(_currentDirectory + filePath.Replace("/", "\\"));

            }
            return new SuccessResult("file deleted");

        }

        private static IResult CheckFileExist(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                return new SuccessResult();
            }

            return new ErrorResult("file not exist!");
        }

        private static IResult CheckFileType(string type)
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return new ErrorResult("invalid file type!");
            }

            return new SuccessResult();
        }

        private static IResult CheckDirectoryExist(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return new SuccessResult();
        }

        private static string GetType(IFormFile file)
        {
            return Path.GetExtension(file.FileName).ToLower();
        }

        private static string GetRandom()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
