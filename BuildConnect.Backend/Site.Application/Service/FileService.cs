using Microsoft.AspNetCore.Http;
using Site.Application.Common.Interface;

namespace Site.Infrastructure.Service;

public class FileService : IFileService
{
    public async Task<string> SaveFileAsync(IFormFile file, string folderName)
    {
        if (file == null || file.Length == 0)
            throw new Exception("File is empty!");

        var guidFilename = Guid.NewGuid().ToString();
        var path = Path.Combine(
            Directory.GetCurrentDirectory(), folderName,
            guidFilename + Path.GetExtension(file.FileName));

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return guidFilename;
    }

    public async Task DeleteFileAsync(string filename, string folderName)
    {
        var path = Path.Combine(
            Directory.GetCurrentDirectory(), folderName,
            filename);

        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }


    public Task<string> GetFileAsync(string fileName)
    {
        throw new NotImplementedException();
    }

    // Other methods as needed (e.g., retrieving files)
}

