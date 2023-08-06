using Microsoft.AspNetCore.Http;
using Site.Application.Common.Interface;


namespace Site.Infrastructure.Service;

public class FileService : IFileService
{

    private readonly string _contentDirectory;

    public FileService()
    {
        _contentDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Content");
        if (!Directory.Exists(_contentDirectory))
        {
            Directory.CreateDirectory(_contentDirectory);
        }
    }

    public async Task<string> SaveFileAsync(IFormFile file, string folderName)
    {
        var originalFileName = file.FileName;
        var fileType = originalFileName.Contains(".")
            ? originalFileName.Substring(originalFileName.LastIndexOf('.') + 1)
            : string.Empty;

        var guid = Guid.NewGuid().ToString();
        var fileName = $"{guid}.{fileType}";
        var filePath = Path.Combine(_contentDirectory, fileName);

        using (var fileStream = file.OpenReadStream())
        using (var fileOutput = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            await fileStream.CopyToAsync(fileOutput);
        }

        return fileName;
    }

    public async Task<string> GetFileAsync(string fileName)
    {
        var filePath = Path.Combine(_contentDirectory, fileName);
        if (!File.Exists(filePath))
            return null;

        var bytes = await File.ReadAllBytesAsync(filePath);
        return Convert.ToBase64String(bytes);
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
    // Other methods as needed (e.g., retrieving files)
}

