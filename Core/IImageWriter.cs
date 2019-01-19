using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core
{
    public interface IImageWriter
    {
        Task<bool> UploadImage(IFormFile file, string filePath);
    }
}
