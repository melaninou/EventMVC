using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core
{
    public interface IImageHandler
    {
        Task<string> UploadImage(IFormFile file, string folderNameFromUserID);
    }
}
