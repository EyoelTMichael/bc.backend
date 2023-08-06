

using Microsoft.AspNetCore.Http;

namespace Site.Application.Common.Interface;
public interface IFileService
{
    //Task<string> SaveFileAsync(IFormFile file, string folderName);
    Task<string> SaveFileAsync(IFormFile file, string folderName);
    Task<string> GetFileAsync(string fileName);
    Task DeleteFileAsync(string filename, string folderName);
    // Other methods as needed (e.g., retrieving files)
}
