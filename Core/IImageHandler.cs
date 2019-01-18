using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core
{
    public interface IImageHandler
    {
        Task<bool> UploadImage(IFormFile file, string filePath);
    }
}
