using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.Helpers.FileHelpers
{
    public class RootFileHelper : IFileHelper
    {
        private readonly string defaultFile;
        private readonly string folder = "\\images\\";
        private readonly string path = Directory.GetCurrentDirectory() + "\\wwwroot";

        public RootFileHelper()
        {
            defaultFile = (folder + "default_img.png").Replace("\\", "/");
        }

        public IDataResult<string> CreateFile(IFormFile file)
        {
            if (file == null) return new SuccessDataResult<string>(defaultFile, "");

            var extension = Path.GetExtension(file.FileName);
            var guid = Guid.NewGuid().ToString() + DateTime.Now.Millisecond + "_" + DateTime.Now.Hour + "_" +
                       DateTime.Now.Minute;
            var imagePath = folder + guid + extension;

            while (File.Exists(path + imagePath))
            {
                guid = Guid.NewGuid().ToString() + DateTime.Now.Millisecond + "_" + DateTime.Now.Hour + "_" +
                       DateTime.Now.Minute;
                imagePath = folder + guid + extension;
            }

            using (var fileStream = File.Create(path + imagePath))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
                imagePath = imagePath.Replace("\\", "/");

                return new SuccessDataResult<string>(imagePath, "");
            }
        }

        public IResult DeleteFile(string filePath)
        {
            if (filePath.Replace("\\", "/") != defaultFile && File.Exists(path + filePath))
                File.Delete(path + filePath);

            return new SuccessResult();
        }

        public IDataResult<string> UpdateFile(IFormFile file, string filePath)
        {
            DeleteFile(filePath);
            return CreateFile(file);
        }
    }
}