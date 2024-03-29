﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core
{
    public class ImageHandler : IImageHandler
    {
        private readonly IImageWriter _imageWriter;
        public ImageHandler(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }

        public async Task<bool> UploadImage(IFormFile file, string filePath)
        {
            var result = await _imageWriter.UploadImage(file, filePath);
            return result;
        }
    }
}
