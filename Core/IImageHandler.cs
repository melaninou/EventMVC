using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core
{
    public interface IImageHandler
    {
        Task<bool> UploadImage(IFormFile file, string filePath);
    }
}
