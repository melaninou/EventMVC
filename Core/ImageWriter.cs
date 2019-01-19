using System.IO;
using System.Threading.Tasks;
using Aids;
using Microsoft.AspNetCore.Http;

namespace Core
{
    public class ImageWriter : IImageWriter
    {
        public async Task<bool> UploadImage(IFormFile file, string filePath)
        {
            if (CheckIfImageFile(file))
            {
                return await WriteFile(file, filePath);
            }

            return false;
        }

        /// <summary>
        /// Method to check if file is image file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return WriterHelper.GetImageFormat(fileBytes) != WriterHelper.ImageFormat.unknown;
        }

        /// <summary>
        /// Method to write file onto the disk
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<bool> WriteFile(IFormFile file, string filePath)
        {
            try
            {
                EnsureFolderExists(filePath);
                using (var bits = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }
            }
            catch 
            {
                return false;
            }

            return true;
        }

        private static void EnsureFolderExists(string filePath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }
        }
    }
}
